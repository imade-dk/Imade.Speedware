import { css, html, nothing, property, repeat, state } from '@umbraco-cms/backoffice/external/lit';
import type { CSSResultGroup } from '@umbraco-cms/backoffice/external/lit';
import type { UUIComboboxElement, UUIComboboxEvent } from '@umbraco-cms/backoffice/external/uui';
import { UmbChangeEvent } from '@umbraco-cms/backoffice/event';
import { UmbLitElement } from '@umbraco-cms/backoffice/lit-element';
import { UmbFormControlMixin } from '@umbraco-cms/backoffice/validation';
import type {
	UmbPropertyEditorConfigCollection,
	UmbPropertyEditorUiElement,
} from '@umbraco-cms/backoffice/property-editor';
import {
	SHOW_DEBUG_SETTING_ALIAS,
	SHOW_SELECTED_SETTING_ALIAS,
	VALIDATION_LIMIT_SETTING_ALIAS,
} from './settings.js';
import type { PickerItem } from './types.js';

export abstract class SpeedwarePickerBaseElement
	extends UmbFormControlMixin<string, typeof UmbLitElement, string>(UmbLitElement, '')
	implements UmbPropertyEditorUiElement
{
	#value = '';
	#limitMin = 0;
	#limitMax = 0;
	@state() protected _selectedIds: number[] = [];

	@property({ attribute: false })
	public set value(v: unknown) {
		// Umbraco may (re)assign undefined/null for a property with no stored value.
		// Treat that as "nothing to restore" and keep this instance's own selection
		// instead of wiping it; real clears are always written as '[]' by #removeItem.
		if (v === undefined || v === null) {
			if (this.#value === '') this._selectedIds = [];
			return;
		}
		const normalized = Array.isArray(v) ? JSON.stringify(v) : ((v as string) ?? '');
		const ids = SpeedwarePickerBaseElement.#parseIds(v);
		// Reject non-empty strings that don't represent a valid JSON array. This
		// guards against corrupted stored values (e.g. a C# List<int>.ToString()
		// artifact) being passed through Umbraco and incorrectly clearing the
		// in-memory selection state.
		if (normalized !== '' && ids.length === 0 && normalized !== '[]') {
			return;
		}
		this.#value = normalized;
		super.value = normalized;
		this._selectedIds = ids;
		// Re-validate the amount limits once validation is active (after the first save/submit attempt).
		if (!this.pristine) this._runValidators();
	}
	public get value(): string {
		return this.#value;
	}

	@state() private _showDebug = false;
	@state() private _showSelected = true;

	@property({ attribute: false })
	public set config(config: UmbPropertyEditorConfigCollection | undefined) {
		this._showDebug = config?.getValueByAlias<boolean>(SHOW_DEBUG_SETTING_ALIAS) === true;
		// Pickers without this setting (or with it unset) keep showing their tags.
		this._showSelected = config?.getValueByAlias<boolean>(SHOW_SELECTED_SETTING_ALIAS) !== false;
		// Range editor value; 0 / empty means "no limit" (both 0 = unrestricted). Pickers without the setting are unrestricted.
		const limit = config?.getValueByAlias<{ min?: number; max?: number }>(VALIDATION_LIMIT_SETTING_ALIAS);
		this.#limitMin = limit?.min ?? 0;
		this.#limitMax = limit?.max ?? 0;
		this.requestUpdate();
	}

	constructor() {
		super();
		this.addValidator(
			'rangeUnderflow',
			() => this.localize.term('validation_entriesShort', this.#limitMin, this.#limitMin - this._selectedIds.length),
			() => this.#limitMin > 0 && this._selectedIds.length < this.#limitMin,
		);
		this.addValidator(
			'rangeOverflow',
			() => this.localize.term('validation_entriesExceed', this.#limitMax, this._selectedIds.length - this.#limitMax),
			() => this.#limitMax > 0 && this._selectedIds.length > this.#limitMax,
		);
	}

	/** True when a maximum is configured and already reached, so nothing more can be added. */
	protected get _limitReached(): boolean {
		return this.#limitMax > 0 && this._selectedIds.length >= this.#limitMax;
	}

	static #parseIds(v: unknown): number[] {
		if (!v) return [];
		if (Array.isArray(v)) return v.filter((x): x is number => typeof x === 'number');
		if (typeof v === 'string') {
			try {
				const parsed = JSON.parse(v);
				return Array.isArray(parsed) ? parsed : [];
			} catch {
				return [];
			}
		}
		return [];
	}

	@state() protected _allItems: PickerItem[] = [];
	@state() private _searchTerm = '';
	@state() private _comboboxValue = '';
	@state() protected _loading = false;
	@state() private _error = false;

	protected abstract fetchItems(): Promise<PickerItem[]>;

	/**
	 * Name of this picker's section in the localization dictionaries (en/da/nb).
	 * Each section must define: pleaseSelect, selectedItems and search.
	 */
	protected abstract readonly localizationKey: string;

	protected _term(name: string): string {
		return this.localize.term(`${this.localizationKey}_${name}`);
	}

	override connectedCallback() {
		super.connectedCallback();
		this.#loadItems();
	}

	async #loadItems() {
		this._loading = true;
		this._error = false;
		try {
			this._allItems = await this.fetchItems();
		} catch {
			this._error = true;
		} finally {
			this._loading = false;
		}
	}

	private get _filteredItems(): PickerItem[] {
		const ids = this._selectedIds;
		const term = this._searchTerm.toLowerCase();
		return this._allItems.filter(
			(item) => item.label.toLowerCase().includes(term) && !ids.includes(item.id),
		);
	}

	protected get _selectedItems(): PickerItem[] {
		return this._selectedIds
			.map((id) => this._allItems.find((item) => item.id === id))
			.filter((item): item is PickerItem => item !== undefined);
	}

	#onSearch(e: UUIComboboxEvent) {
		this._searchTerm = (e.target as UUIComboboxElement).search ?? '';
	}

	#onSelect(e: UUIComboboxEvent) {
		const raw = (e.target as UUIComboboxElement).value?.toString();
		if (!raw) return;
		const newId = Number(raw);
		if (Number.isNaN(newId) || this._selectedIds.includes(newId) || this._limitReached) return;
		this.value = JSON.stringify([...this._selectedIds, newId]);
		this._comboboxValue = '';
		this._searchTerm = '';
		this.dispatchEvent(new UmbChangeEvent());
	}

	#removeItem(id: number) {
		this.value = JSON.stringify(this._selectedIds.filter((x) => x !== id));
		this.dispatchEvent(new UmbChangeEvent());
	}

	/** Replaces the whole selection and notifies Umbraco. For use by subclasses with custom selectors. */
	protected setSelectedIds(ids: number[]) {
		this.value = JSON.stringify(ids);
		this.dispatchEvent(new UmbChangeEvent());
	}

	/** The control used to pick items. Subclasses may override (e.g. a tree instead of a combobox). */
	protected renderSelector() {
		return html`
			<div class="selector-row">${this.#renderCombobox()} ${this.renderClearAll()}</div>
		`;
	}

	/** Button that clears the whole selection; sits to the right of the search field. */
	protected renderClearAll() {
		const label = this.localize.term('speedwarePickerCommon_clearAll');
		return html`
			<uui-button
				class="clear-all"
				look="secondary"
				compact
				label="${label}"
				?disabled=${this._loading || this._selectedIds.length === 0}
				@click=${() => this.setSelectedIds([])}>
				${label}
			</uui-button>
		`;
	}

	#renderCombobox() {
		return html`
			<uui-combobox
				.value=${this._comboboxValue}
				placeholder="${this._term('search')}"
				?disabled=${this._loading || this._limitReached}
				@search=${this.#onSearch}
				@change=${this.#onSelect}>
				<uui-combobox-list>
					${this._loading
						? html`<uui-combobox-list-option disabled>Loading…</uui-combobox-list-option>`
						: repeat(
								this._filteredItems,
								(item) => item.id,
								(item) => html`
									<uui-combobox-list-option .value=${String(item.id)}>
										${item.label}
									</uui-combobox-list-option>
								`,
							)}
				</uui-combobox-list>
			</uui-combobox>
		`;
	}

	override render() {
		if (this._error) {
			return html`<uui-tag color="danger">Failed to load options</uui-tag>`;
		}
		return html`
			${this.renderSelector()}
			${this._showSelected && this._selectedIds.length === 0 && !this._loading
				? html`<p id="placeholder">${this._term('pleaseSelect')}</p>`
				: nothing}
			${this._showSelected && this._selectedItems.length > 0
				? html`
						<p id="selected-heading">${this._term('selectedItems')}</p>
						<div id="pills">
							${repeat(
								this._selectedItems,
								(item) => item.id,
								(item) => html`
									<uui-tag>
										<div class="tag-content">
											<span>${item.label}</span>
											<uui-button
												label="Remove ${item.label}"
												compact
												@click=${() => this.#removeItem(item.id)}>
												<uui-icon name="icon-wrong"></uui-icon>
											</uui-button>
										</div>
									</uui-tag>
								`,
							)}
						</div>
					`
				: nothing}
			${this._showDebug ? this.#renderDebug() : nothing}
		`;
	}

	#renderDebug() {
		const debug = {
			storedValue: this.#value,
			selectedIds: this._selectedIds,
			selectedItems: this._selectedItems.map((item) => ({ id: item.id, label: item.label })),
			unresolvedIds: this._selectedIds.filter((id) => !this._allItems.some((item) => item.id === id)),
			availableItems: this._allItems.length,
			localizationKey: this.localizationKey,
		};
		return html`<pre id="debug">${JSON.stringify(debug, null, 2)}</pre>`;
	}

	static override styles: CSSResultGroup = css`
		:host {
			display: block;
			width: 100%;
		}

		.selector-row {
			display: flex;
			align-items: center;
			gap: var(--uui-size-space-2);
		}

		uui-combobox {
			flex: 1;
			min-width: 0;
		}

		.clear-all {
			flex: none;
		}

		#placeholder,
		#selected-heading {
			margin: var(--uui-size-space-3) 0 0;
			font-size: var(--uui-type-small-size);
			color: var(--uui-color-text-alt);
		}

		#selected-heading {
			font-weight: bold;
			color: var(--uui-color-text);
		}

		#debug {
			margin: var(--uui-size-space-3) 0 0;
			padding: var(--uui-size-space-3);
			overflow: auto;
			font-size: var(--uui-type-small-size);
			background: var(--uui-color-surface-alt);
			border: 1px dashed var(--uui-color-border);
			border-radius: var(--uui-border-radius);
		}

		#pills {
			display: flex;
			flex-wrap: wrap;
			gap: var(--uui-size-space-2);
			margin-top: var(--uui-size-space-2);
		}

		.tag-content {
			display: flex;
			align-items: center;
			gap: var(--uui-size-space-2);
		}

		uui-tag uui-button {
			--uui-button-height: auto;
			--uui-button-padding-left-factor: 0.5;
			--uui-button-padding-right-factor: 0.5;
			display: inline-flex;
			align-items: center;
			margin: 0;
		}

		uui-tag uui-button:hover {
			color: var(--uui-color-selected-contrast);
		}
	`;
}

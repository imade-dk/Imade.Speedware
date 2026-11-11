import { css, customElement, html, nothing, repeat, state } from '@umbraco-cms/backoffice/external/lit';
import type { CSSResultGroup } from '@umbraco-cms/backoffice/external/lit';
import { SpeedwarePickerBaseElement } from '../speedware-picker.element.js';
import { ImadeSpeedwareWebService } from '../../api/index.js';
import type { CoursesTreePickerItemDto } from '../../api/types.gen.js';
import type { PickerItem } from '../types.js';

const ROOT_PARENT_ID = 0;

type SearchState = { visible: Set<number>; ancestors: Set<number> };

@customElement('imade-speedware-courses-tree-picker')
export class CoursesTreePickerElement extends SpeedwarePickerBaseElement {
	protected readonly localizationKey = 'speedwareCoursesTreePicker';

	#nodes = new Map<number, CoursesTreePickerItemDto>();
	#children = new Map<number, number[]>();

	@state() private _expanded = new Set<number>();
	@state() private _treeSearch = '';

	protected async fetchItems(): Promise<PickerItem[]> {
		const { data } = await ImadeSpeedwareWebService.getCoursesTree({ throwOnError: true });

		this.#nodes = new Map(data.map((n) => [n.id, n]));
		this.#children = new Map();
		// The API returns a depth-first list in Speedadmin order, so pushing keeps sibling order.
		for (const n of data) {
			const siblings = this.#children.get(n.parentId) ?? [];
			siblings.push(n.id);
			this.#children.set(n.parentId, siblings);
		}

		// Start collapsed, but reveal the ancestors of anything already selected.
		const expanded = new Set<number>();
		for (const id of this._selectedIds) {
			let parent = this.#nodes.get(id)?.parentId;
			while (parent !== undefined && parent !== ROOT_PARENT_ID && !expanded.has(parent)) {
				expanded.add(parent);
				parent = this.#nodes.get(parent)?.parentId;
			}
		}
		this._expanded = expanded;

		return data.map((n) => ({ id: n.id, label: this.#path(n.id) }));
	}

	#path(id: number): string {
		const names: string[] = [];
		const seen = new Set<number>();
		let current = this.#nodes.get(id);
		while (current && !seen.has(current.id)) {
			seen.add(current.id);
			names.unshift(current.name);
			current = this.#nodes.get(current.parentId);
		}
		return names.join(' › ');
	}

	/** All selectable (active) descendants of a node, excluding the node itself. */
	#descendantIds(id: number): number[] {
		const result: number[] = [];
		const stack = [...(this.#children.get(id) ?? [])];
		while (stack.length) {
			const childId = stack.pop()!;
			if (this.#nodes.get(childId)?.active) result.push(childId);
			stack.push(...(this.#children.get(childId) ?? []));
		}
		return result;
	}

	#toggleNode(id: number, checked: boolean) {
		const without = this._selectedIds.filter((x) => x !== id);
		this.setSelectedIds(checked ? [...without, id] : without);
	}

	#toggleChildren(id: number) {
		const descendants = this.#descendantIds(id);
		const allSelected = descendants.every((d) => this._selectedIds.includes(d));
		const without = this._selectedIds.filter((x) => !descendants.includes(x));
		this.setSelectedIds(allSelected ? without : [...without, ...descendants]);
	}

	#toggleExpanded(id: number) {
		const next = new Set(this._expanded);
		if (!next.delete(id)) next.add(id);
		this._expanded = next;
	}

	#expandAll() {
		this._expanded = new Set([...this.#children.keys()].filter((id) => id !== ROOT_PARENT_ID));
	}

	#collapseAll() {
		this._expanded = new Set();
	}

	/** With a search term: ids to show (matches + their ancestors) and the ancestors to auto-expand. */
	#searchState(): SearchState | null {
		const term = this._treeSearch.trim().toLowerCase();
		if (!term) return null;
		const visible = new Set<number>();
		const ancestors = new Set<number>();
		for (const node of this.#nodes.values()) {
			if (!node.name.toLowerCase().includes(term)) continue;
			visible.add(node.id);
			let parent = node.parentId;
			while (parent !== ROOT_PARENT_ID && this.#nodes.has(parent) && !ancestors.has(parent)) {
				visible.add(parent);
				ancestors.add(parent);
				parent = this.#nodes.get(parent)!.parentId;
			}
		}
		return { visible, ancestors };
	}

	protected override renderSelector() {
		if (this._loading) return html`<uui-loader-bar></uui-loader-bar>`;
		const search = this.#searchState();
		const roots = this.#children.get(ROOT_PARENT_ID) ?? [];
		return html`
			<div id="toolbar">
				<uui-input
					id="tree-search"
					type="search"
					label="${this._term('search')}"
					placeholder="${this._term('search')}"
					.value=${this._treeSearch}
					@input=${(e: Event) => (this._treeSearch = (e.target as HTMLInputElement).value)}></uui-input>
				${this.renderClearAll()}
				<uui-button compact look="secondary" label="${this._term('expandAll')}" @click=${this.#expandAll}>
					${this._term('expandAll')}
				</uui-button>
				<uui-button compact look="secondary" label="${this._term('collapseAll')}" @click=${this.#collapseAll}>
					${this._term('collapseAll')}
				</uui-button>
			</div>
			<div id="tree" role="tree">${this.#renderNodes(roots, search)}</div>
		`;
	}

	#renderNodes(ids: number[], search: SearchState | null): unknown {
		const shown = search ? ids.filter((id) => search.visible.has(id)) : ids;
		if (shown.length === 0) return nothing;
		return html`
			<ul>
				${repeat(
					shown,
					(id) => id,
					(id) => this.#renderNode(id, search),
				)}
			</ul>
		`;
	}

	#renderNode(id: number, search: SearchState | null): unknown {
		const node = this.#nodes.get(id);
		if (!node) return nothing;
		const childIds = this.#children.get(id) ?? [];
		const hasChildren = childIds.length > 0;
		const expanded = search ? search.ancestors.has(id) : this._expanded.has(id);
		const selected = this._selectedIds.includes(id);
		const descendants = hasChildren ? this.#descendantIds(id) : [];
		const allChildrenSelected = descendants.length > 0 && descendants.every((d) => this._selectedIds.includes(d));
		const childrenLabel = this._term(allChildrenSelected ? 'deselectChildren' : 'selectChildren');

		return html`
			<li role="treeitem" aria-expanded=${hasChildren ? String(expanded) : nothing}>
				<div class="row ${node.active ? '' : 'inactive'}">
					${hasChildren
						? html`<uui-button
								class="toggle"
								compact
								label="${expanded ? this._term('collapseAll') : this._term('expandAll')}"
								?disabled=${!!search}
								@click=${() => this.#toggleExpanded(id)}>
								<uui-icon name=${expanded ? 'icon-navigation-down' : 'icon-navigation-right'}></uui-icon>
							</uui-button>`
						: html`<span class="toggle-spacer"></span>`}
					<uui-checkbox
						label=${node.name}
						?checked=${selected}
						?disabled=${!node.active}
						@change=${(e: Event) => this.#toggleNode(id, (e.target as HTMLInputElement).checked)}>
						${node.name}
					</uui-checkbox>
					${node.courseCount > 0
						? html`<uui-badge class="count" color="default" title="${node.courseCount}">${node.courseCount}</uui-badge>`
						: nothing}
					${descendants.length > 0
						? html`<uui-button
								class="children-action"
								compact
								look="outline"
								label="${childrenLabel}"
								@click=${() => this.#toggleChildren(id)}>
								${childrenLabel}
							</uui-button>`
						: nothing}
				</div>
				${hasChildren && expanded ? this.#renderNodes(childIds, search) : nothing}
			</li>
		`;
	}

	static override styles: CSSResultGroup = [
		SpeedwarePickerBaseElement.styles,
		css`
			#toolbar {
				display: flex;
				align-items: center;
				gap: var(--uui-size-space-2);
				margin-bottom: var(--uui-size-space-3);
			}

			#tree-search {
				flex: 1;
			}

			#tree {
				padding: var(--uui-size-space-2);
				border: 1px solid var(--uui-color-border);
				border-radius: var(--uui-border-radius);
			}

			ul {
				list-style: none;
				margin: 0;
				padding-left: var(--uui-size-space-5);
			}

			#tree > ul {
				padding-left: 0;
			}

			.row {
				display: flex;
				align-items: center;
				gap: var(--uui-size-space-2);
				min-height: 32px;
			}

			.row.inactive {
				opacity: 0.5;
			}

			.toggle,
			.toggle-spacer {
				width: 28px;
				flex: none;
			}

			.count {
				position: static;
				flex: none;
			}

			.children-action {
				margin-left: auto;
			}
		`,
	];
}

export default CoursesTreePickerElement;

declare global {
	interface HTMLElementTagNameMap {
		'imade-speedware-courses-tree-picker': CoursesTreePickerElement;
	}
}

import { n as e, r as t, t as n } from "./api-BfM7j7ti.js";
import { css as r, customElement as i, html as a, nothing as o, repeat as s, state as c } from "@umbraco-cms/backoffice/external/lit";
//#region src/property-editors/courses-tree-picker/courses-tree-picker.element.ts
var l = 0, u = class extends e {
	constructor(...e) {
		super(...e), this.localizationKey = "speedwareCoursesTreePicker", this.#e = /* @__PURE__ */ new Map(), this.#t = /* @__PURE__ */ new Map(), this._expanded = /* @__PURE__ */ new Set(), this._treeSearch = "";
	}
	#e;
	#t;
	async fetchItems() {
		let { data: e } = await n.getCoursesTree({ throwOnError: !0 });
		this.#e = new Map(e.map((e) => [e.id, e])), this.#t = /* @__PURE__ */ new Map();
		for (let t of e) {
			let e = this.#t.get(t.parentId) ?? [];
			e.push(t.id), this.#t.set(t.parentId, e);
		}
		let t = /* @__PURE__ */ new Set();
		for (let e of this._selectedIds) {
			let n = this.#e.get(e)?.parentId;
			for (; n !== void 0 && n !== l && !t.has(n);) t.add(n), n = this.#e.get(n)?.parentId;
		}
		return this._expanded = t, e.map((e) => ({
			id: e.id,
			label: this.#n(e.id)
		}));
	}
	#n(e) {
		let t = [], n = /* @__PURE__ */ new Set(), r = this.#e.get(e);
		for (; r && !n.has(r.id);) n.add(r.id), t.unshift(r.name), r = this.#e.get(r.parentId);
		return t.join(" › ");
	}
	#r(e) {
		let t = [], n = [...this.#t.get(e) ?? []];
		for (; n.length;) {
			let e = n.pop();
			this.#e.get(e)?.active && t.push(e), n.push(...this.#t.get(e) ?? []);
		}
		return t;
	}
	#i(e, t) {
		let n = this._selectedIds.filter((t) => t !== e);
		this.setSelectedIds(t ? [...n, e] : n);
	}
	#a(e) {
		let t = this.#r(e), n = t.every((e) => this._selectedIds.includes(e)), r = this._selectedIds.filter((e) => !t.includes(e));
		this.setSelectedIds(n ? r : [...r, ...t]);
	}
	#o(e) {
		let t = new Set(this._expanded);
		t.delete(e) || t.add(e), this._expanded = t;
	}
	#s() {
		this._expanded = new Set([...this.#t.keys()].filter((e) => e !== l));
	}
	#c() {
		this._expanded = /* @__PURE__ */ new Set();
	}
	#l() {
		let e = this._treeSearch.trim().toLowerCase();
		if (!e) return null;
		let t = /* @__PURE__ */ new Set(), n = /* @__PURE__ */ new Set();
		for (let r of this.#e.values()) {
			if (!r.name.toLowerCase().includes(e)) continue;
			t.add(r.id);
			let i = r.parentId;
			for (; i !== l && this.#e.has(i) && !n.has(i);) t.add(i), n.add(i), i = this.#e.get(i).parentId;
		}
		return {
			visible: t,
			ancestors: n
		};
	}
	renderSelector() {
		if (this._loading) return a`<uui-loader-bar></uui-loader-bar>`;
		let e = this.#l(), t = this.#t.get(l) ?? [];
		return a`
			<div id="toolbar">
				<uui-input
					id="tree-search"
					type="search"
					label="${this._term("search")}"
					placeholder="${this._term("search")}"
					.value=${this._treeSearch}
					@input=${(e) => this._treeSearch = e.target.value}></uui-input>
				<uui-button compact look="secondary" label="${this._term("expandAll")}" @click=${this.#s}>
					${this._term("expandAll")}
				</uui-button>
				<uui-button compact look="secondary" label="${this._term("collapseAll")}" @click=${this.#c}>
					${this._term("collapseAll")}
				</uui-button>
				${this.renderClearAll()}
			</div>
			<div id="tree" role="tree">${this.#u(t, e)}</div>
		`;
	}
	#u(e, t) {
		let n = t ? e.filter((e) => t.visible.has(e)) : e;
		return n.length === 0 ? o : a`
			<ul>
				${s(n, (e) => e, (e) => this.#d(e, t))}
			</ul>
		`;
	}
	#d(e, t) {
		let n = this.#e.get(e);
		if (!n) return o;
		let r = this.#t.get(e) ?? [], i = r.length > 0, s = t ? t.ancestors.has(e) : this._expanded.has(e), c = this._selectedIds.includes(e), l = i ? this.#r(e) : [], u = l.length > 0 && l.every((e) => this._selectedIds.includes(e)), d = this._term(u ? "deselectChildren" : "selectChildren");
		return a`
			<li role="treeitem" aria-expanded=${i ? String(s) : o}>
				<div class="row ${n.active ? "" : "inactive"}">
					${i ? a`<uui-button
								class="toggle"
								compact
								label="${s ? this._term("collapseAll") : this._term("expandAll")}"
								?disabled=${!!t}
								@click=${() => this.#o(e)}>
								<uui-icon name=${s ? "icon-navigation-down" : "icon-navigation-right"}></uui-icon>
							</uui-button>` : a`<span class="toggle-spacer"></span>`}
					<uui-checkbox
						label=${n.name}
						?checked=${c}
						?disabled=${!n.active}
						@change=${(t) => this.#i(e, t.target.checked)}>
						${n.name}
					</uui-checkbox>
					${n.courseCount > 0 ? a`<uui-badge class="count" color="default" title="${n.courseCount}">${n.courseCount}</uui-badge>` : o}
					${l.length > 0 ? a`<uui-button
								class="children-action"
								compact
								look="outline"
								label="${d}"
								@click=${() => this.#a(e)}>
								${d}
							</uui-button>` : o}
				</div>
				${i && s ? this.#u(r, t) : o}
			</li>
		`;
	}
	static {
		this.styles = [e.styles, r`
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
		`];
	}
};
t([c()], u.prototype, "_expanded", void 0), t([c()], u.prototype, "_treeSearch", void 0), u = t([i("imade-speedware-courses-tree-picker")], u);
var d = u;
//#endregion
export { u as CoursesTreePickerElement, d as default };

//# sourceMappingURL=courses-tree-picker.element-DScpatRj.js.map
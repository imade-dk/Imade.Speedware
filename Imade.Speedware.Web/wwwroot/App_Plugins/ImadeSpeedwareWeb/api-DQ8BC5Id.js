import { css as e, html as t, nothing as n, property as r, repeat as i, state as a } from "@umbraco-cms/backoffice/external/lit";
import { UmbChangeEvent as o } from "@umbraco-cms/backoffice/event";
import { UmbLitElement as s } from "@umbraco-cms/backoffice/lit-element";
import { umbHttpClient as c } from "@umbraco-cms/backoffice/http-client";
//#region \0@oxc-project+runtime@0.127.0/helpers/decorate.js
function l(e, t, n, r) {
	var i = arguments.length, a = i < 3 ? t : r === null ? r = Object.getOwnPropertyDescriptor(t, n) : r, o;
	if (typeof Reflect == "object" && typeof Reflect.decorate == "function") a = Reflect.decorate(e, t, n, r);
	else for (var s = e.length - 1; s >= 0; s--) (o = e[s]) && (a = (i < 3 ? o(a) : i > 3 ? o(t, n, a) : o(t, n)) || a);
	return i > 3 && a && Object.defineProperty(t, n, a), a;
}
//#endregion
//#region src/property-editors/speedware-picker.element.ts
var u = class r extends s {
	constructor(...e) {
		super(...e), this.#e = "", this._selectedIds = [], this._allItems = [], this._searchTerm = "", this._comboboxValue = "", this._loading = !1, this._error = !1;
	}
	#e;
	set value(e) {
		if (e == null) {
			this.#e === "" && (this._selectedIds = []);
			return;
		}
		let t = Array.isArray(e) ? JSON.stringify(e) : e ?? "", n = r.#t(e);
		t !== "" && n.length === 0 && t !== "[]" || (this.#e = t, this._selectedIds = n);
	}
	get value() {
		return this.#e;
	}
	static #t(e) {
		if (!e) return [];
		if (Array.isArray(e)) return e.filter((e) => typeof e == "number");
		if (typeof e == "string") try {
			let t = JSON.parse(e);
			return Array.isArray(t) ? t : [];
		} catch {
			return [];
		}
		return [];
	}
	_term(e) {
		return this.localize.term(`${this.localizationKey}_${e}`);
	}
	connectedCallback() {
		super.connectedCallback(), this.#n();
	}
	async #n() {
		this._loading = !0, this._error = !1;
		try {
			this._allItems = await this.fetchItems();
		} catch {
			this._error = !0;
		} finally {
			this._loading = !1;
		}
	}
	get _filteredItems() {
		let e = this._selectedIds, t = this._searchTerm.toLowerCase();
		return this._allItems.filter((n) => n.label.toLowerCase().includes(t) && !e.includes(n.id));
	}
	get _selectedItems() {
		return this._selectedIds.map((e) => this._allItems.find((t) => t.id === e)).filter((e) => e !== void 0);
	}
	#r(e) {
		this._searchTerm = e.target.search ?? "";
	}
	#i(e) {
		let t = e.target.value?.toString();
		if (!t) return;
		let n = Number(t);
		Number.isNaN(n) || this._selectedIds.includes(n) || (this.value = JSON.stringify([...this._selectedIds, n]), this._comboboxValue = "", this._searchTerm = "", this.dispatchEvent(new o()));
	}
	#a(e) {
		this.value = JSON.stringify(this._selectedIds.filter((t) => t !== e)), this.dispatchEvent(new o());
	}
	render() {
		return this._error ? t`<uui-tag color="danger">Failed to load options</uui-tag>` : t`
			<uui-combobox
				.value=${this._comboboxValue}
				placeholder="${this._term("search")}"
				?disabled=${this._loading}
				@search=${this.#r}
				@change=${this.#i}>
				<uui-combobox-list>
					${this._loading ? t`<uui-combobox-list-option disabled>Loading…</uui-combobox-list-option>` : i(this._filteredItems, (e) => e.id, (e) => t`
									<uui-combobox-list-option .value=${String(e.id)}>
										${e.label}
									</uui-combobox-list-option>
								`)}
				</uui-combobox-list>
			</uui-combobox>
			${this._selectedIds.length === 0 && !this._loading ? t`<p id="placeholder">${this._term("pleaseSelect")}</p>` : n}
			${this._selectedItems.length > 0 ? t`
						<p id="selected-heading">${this._term("selectedItems")}</p>
						<div id="pills">
							${i(this._selectedItems, (e) => e.id, (e) => t`
									<uui-tag>
										<div class="tag-content">
											<span>${e.label}</span>
											<uui-button
												label="Remove ${e.label}"
												compact
												@click=${() => this.#a(e.id)}>
												<uui-icon name="icon-wrong"></uui-icon>
											</uui-button>
										</div>
									</uui-tag>
								`)}
						</div>
					` : n}
		`;
	}
	static {
		this.styles = e`
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
};
l([a()], u.prototype, "_selectedIds", void 0), l([r({ attribute: !1 })], u.prototype, "value", null), l([a()], u.prototype, "_allItems", void 0), l([a()], u.prototype, "_searchTerm", void 0), l([a()], u.prototype, "_comboboxValue", void 0), l([a()], u.prototype, "_loading", void 0), l([a()], u.prototype, "_error", void 0);
//#endregion
//#region src/api/core/bodySerializer.gen.ts
var d = { bodySerializer: (e) => JSON.stringify(e, (e, t) => typeof t == "bigint" ? t.toString() : t) };
Object.entries({
	$body_: "body",
	$headers_: "headers",
	$path_: "path",
	$query_: "query"
});
//#endregion
//#region src/api/core/serverSentEvents.gen.ts
var f = ({ onRequest: e, onSseError: t, onSseEvent: n, responseTransformer: r, responseValidator: i, sseDefaultRetryDelay: a, sseMaxRetryAttempts: o, sseMaxRetryDelay: s, sseSleepFn: c, url: l, ...u }) => {
	let d, f = c ?? ((e) => new Promise((t) => setTimeout(t, e)));
	return { stream: async function* () {
		let c = a ?? 3e3, p = 0, m = u.signal ?? new AbortController().signal;
		for (; !m.aborted;) {
			p++;
			let a = u.headers instanceof Headers ? u.headers : new Headers(u.headers);
			d !== void 0 && a.set("Last-Event-ID", d);
			try {
				let t = {
					redirect: "follow",
					...u,
					body: u.serializedBody,
					headers: a,
					signal: m
				}, o = new Request(l, t);
				e && (o = await e(l, t));
				let s = await (u.fetch ?? globalThis.fetch)(o);
				if (!s.ok) throw Error(`SSE failed: ${s.status} ${s.statusText}`);
				if (!s.body) throw Error("No body in SSE response");
				let f = s.body.pipeThrough(new TextDecoderStream()).getReader(), p = "", h = () => {
					try {
						f.cancel();
					} catch {}
				};
				m.addEventListener("abort", h);
				try {
					for (;;) {
						let { done: e, value: t } = await f.read();
						if (e) break;
						p += t;
						let a = p.split("\n\n");
						p = a.pop() ?? "";
						for (let e of a) {
							let t = e.split("\n"), a = [], o;
							for (let e of t) if (e.startsWith("data:")) a.push(e.replace(/^data:\s*/, ""));
							else if (e.startsWith("event:")) o = e.replace(/^event:\s*/, "");
							else if (e.startsWith("id:")) d = e.replace(/^id:\s*/, "");
							else if (e.startsWith("retry:")) {
								let t = Number.parseInt(e.replace(/^retry:\s*/, ""), 10);
								Number.isNaN(t) || (c = t);
							}
							let s, l = !1;
							if (a.length) {
								let e = a.join("\n");
								try {
									s = JSON.parse(e), l = !0;
								} catch {
									s = e;
								}
							}
							l && (i && await i(s), r && (s = await r(s))), n?.({
								data: s,
								event: o,
								id: d,
								retry: c
							}), a.length && (yield s);
						}
					}
				} finally {
					m.removeEventListener("abort", h), f.releaseLock();
				}
				break;
			} catch (e) {
				if (t?.(e), o !== void 0 && p >= o) break;
				await f(Math.min(c * 2 ** (p - 1), s ?? 3e4));
			}
		}
	}() };
}, p = (e) => {
	switch (e) {
		case "label": return ".";
		case "matrix": return ";";
		case "simple": return ",";
		default: return "&";
	}
}, m = (e) => {
	switch (e) {
		case "form": return ",";
		case "pipeDelimited": return "|";
		case "spaceDelimited": return "%20";
		default: return ",";
	}
}, h = (e) => {
	switch (e) {
		case "label": return ".";
		case "matrix": return ";";
		case "simple": return ",";
		default: return "&";
	}
}, g = ({ allowReserved: e, explode: t, name: n, style: r, value: i }) => {
	if (!t) {
		let t = (e ? i : i.map((e) => encodeURIComponent(e))).join(m(r));
		switch (r) {
			case "label": return `.${t}`;
			case "matrix": return `;${n}=${t}`;
			case "simple": return t;
			default: return `${n}=${t}`;
		}
	}
	let a = p(r), o = i.map((t) => r === "label" || r === "simple" ? e ? t : encodeURIComponent(t) : _({
		allowReserved: e,
		name: n,
		value: t
	})).join(a);
	return r === "label" || r === "matrix" ? a + o : o;
}, _ = ({ allowReserved: e, name: t, value: n }) => {
	if (n == null) return "";
	if (typeof n == "object") throw Error("Deeply-nested arrays/objects aren’t supported. Provide your own `querySerializer()` to handle these.");
	return `${t}=${e ? n : encodeURIComponent(n)}`;
}, v = ({ allowReserved: e, explode: t, name: n, style: r, value: i, valueOnly: a }) => {
	if (i instanceof Date) return a ? i.toISOString() : `${n}=${i.toISOString()}`;
	if (r !== "deepObject" && !t) {
		let t = [];
		Object.entries(i).forEach(([n, r]) => {
			t = [
				...t,
				n,
				e ? r : encodeURIComponent(r)
			];
		});
		let a = t.join(",");
		switch (r) {
			case "form": return `${n}=${a}`;
			case "label": return `.${a}`;
			case "matrix": return `;${n}=${a}`;
			default: return a;
		}
	}
	let o = h(r), s = Object.entries(i).map(([t, i]) => _({
		allowReserved: e,
		name: r === "deepObject" ? `${n}[${t}]` : t,
		value: i
	})).join(o);
	return r === "label" || r === "matrix" ? o + s : s;
}, y = /\{[^{}]+\}/g, b = ({ path: e, url: t }) => {
	let n = t, r = t.match(y);
	if (r) for (let t of r) {
		let r = !1, i = t.substring(1, t.length - 1), a = "simple";
		i.endsWith("*") && (r = !0, i = i.substring(0, i.length - 1)), i.startsWith(".") ? (i = i.substring(1), a = "label") : i.startsWith(";") && (i = i.substring(1), a = "matrix");
		let o = e[i];
		if (o == null) continue;
		if (Array.isArray(o)) {
			n = n.replace(t, g({
				explode: r,
				name: i,
				style: a,
				value: o
			}));
			continue;
		}
		if (typeof o == "object") {
			n = n.replace(t, v({
				explode: r,
				name: i,
				style: a,
				value: o,
				valueOnly: !0
			}));
			continue;
		}
		if (a === "matrix") {
			n = n.replace(t, `;${_({
				name: i,
				value: o
			})}`);
			continue;
		}
		let s = encodeURIComponent(a === "label" ? `.${o}` : o);
		n = n.replace(t, s);
	}
	return n;
}, x = ({ baseUrl: e, path: t, query: n, querySerializer: r, url: i }) => {
	let a = i.startsWith("/") ? i : `/${i}`, o = (e ?? "") + a;
	t && (o = b({
		path: t,
		url: o
	}));
	let s = n ? r(n) : "";
	return s.startsWith("?") && (s = s.substring(1)), s && (o += `?${s}`), o;
};
function S(e) {
	let t = e.body !== void 0;
	if (t && e.bodySerializer) return "serializedBody" in e ? e.serializedBody !== void 0 && e.serializedBody !== "" ? e.serializedBody : null : e.body === "" ? null : e.body;
	if (t) return e.body;
}
//#endregion
//#region src/api/core/auth.gen.ts
var C = async (e, t) => {
	let n = typeof t == "function" ? await t(e) : t;
	if (n) return e.scheme === "bearer" ? `Bearer ${n}` : e.scheme === "basic" ? `Basic ${btoa(n)}` : n;
}, w = ({ allowReserved: e, array: t, object: n } = {}) => (r) => {
	let i = [];
	if (r && typeof r == "object") for (let a in r) {
		let o = r[a];
		if (o != null) if (Array.isArray(o)) {
			let n = g({
				allowReserved: e,
				explode: !0,
				name: a,
				style: "form",
				value: o,
				...t
			});
			n && i.push(n);
		} else if (typeof o == "object") {
			let t = v({
				allowReserved: e,
				explode: !0,
				name: a,
				style: "deepObject",
				value: o,
				...n
			});
			t && i.push(t);
		} else {
			let t = _({
				allowReserved: e,
				name: a,
				value: o
			});
			t && i.push(t);
		}
	}
	return i.join("&");
}, T = (e) => {
	if (!e) return "stream";
	let t = e.split(";")[0]?.trim();
	if (t) {
		if (t.startsWith("application/json") || t.endsWith("+json")) return "json";
		if (t === "multipart/form-data") return "formData";
		if ([
			"application/",
			"audio/",
			"image/",
			"video/"
		].some((e) => t.startsWith(e))) return "blob";
		if (t.startsWith("text/")) return "text";
	}
}, E = (e, t) => t ? !!(e.headers.has(t) || e.query?.[t] || e.headers.get("Cookie")?.includes(`${t}=`)) : !1, D = async ({ security: e, ...t }) => {
	for (let n of e) {
		if (E(t, n.name)) continue;
		let e = await C(n, t.auth);
		if (!e) continue;
		let r = n.name ?? "Authorization";
		switch (n.in) {
			case "query":
				t.query ||= {}, t.query[r] = e;
				break;
			case "cookie":
				t.headers.append("Cookie", `${r}=${e}`);
				break;
			default:
				t.headers.set(r, e);
				break;
		}
	}
}, O = (e) => x({
	baseUrl: e.baseUrl,
	path: e.path,
	query: e.query,
	querySerializer: typeof e.querySerializer == "function" ? e.querySerializer : w(e.querySerializer),
	url: e.url
}), k = (e, t) => {
	let n = {
		...e,
		...t
	};
	return n.baseUrl?.endsWith("/") && (n.baseUrl = n.baseUrl.substring(0, n.baseUrl.length - 1)), n.headers = j(e.headers, t.headers), n;
}, A = (e) => {
	let t = [];
	return e.forEach((e, n) => {
		t.push([n, e]);
	}), t;
}, j = (...e) => {
	let t = new Headers();
	for (let n of e) {
		if (!n) continue;
		let e = n instanceof Headers ? A(n) : Object.entries(n);
		for (let [n, r] of e) if (r === null) t.delete(n);
		else if (Array.isArray(r)) for (let e of r) t.append(n, e);
		else r !== void 0 && t.set(n, typeof r == "object" ? JSON.stringify(r) : r);
	}
	return t;
}, M = class {
	constructor() {
		this.fns = [];
	}
	clear() {
		this.fns = [];
	}
	eject(e) {
		let t = this.getInterceptorIndex(e);
		this.fns[t] && (this.fns[t] = null);
	}
	exists(e) {
		let t = this.getInterceptorIndex(e);
		return !!this.fns[t];
	}
	getInterceptorIndex(e) {
		return typeof e == "number" ? this.fns[e] ? e : -1 : this.fns.indexOf(e);
	}
	update(e, t) {
		let n = this.getInterceptorIndex(e);
		return this.fns[n] ? (this.fns[n] = t, e) : !1;
	}
	use(e) {
		return this.fns.push(e), this.fns.length - 1;
	}
}, N = () => ({
	error: new M(),
	request: new M(),
	response: new M()
}), P = w({
	allowReserved: !1,
	array: {
		explode: !0,
		style: "form"
	},
	object: {
		explode: !0,
		style: "deepObject"
	}
}), F = { "Content-Type": "application/json" }, I = (e = {}) => ({
	...d,
	headers: F,
	parseAs: "auto",
	querySerializer: P,
	...e
}), L = ((e = {}) => {
	let t = k(I(), e), n = () => ({ ...t }), r = (e) => (t = k(t, e), n()), i = N(), a = async (e) => {
		let n = {
			...t,
			...e,
			fetch: e.fetch ?? t.fetch ?? globalThis.fetch,
			headers: j(t.headers, e.headers),
			serializedBody: void 0
		};
		return n.security && await D({
			...n,
			security: n.security
		}), n.requestValidator && await n.requestValidator(n), n.body !== void 0 && n.bodySerializer && (n.serializedBody = n.bodySerializer(n.body)), (n.body === void 0 || n.serializedBody === "") && n.headers.delete("Content-Type"), {
			opts: n,
			url: O(n)
		};
	}, o = async (e) => {
		let { opts: t, url: n } = await a(e), r = {
			redirect: "follow",
			...t,
			body: S(t)
		}, o = new Request(n, r);
		for (let e of i.request.fns) e && (o = await e(o, t));
		let s = t.fetch, c = await s(o);
		for (let e of i.response.fns) e && (c = await e(c, o, t));
		let l = {
			request: o,
			response: c
		};
		if (c.ok) {
			let e = (t.parseAs === "auto" ? T(c.headers.get("Content-Type")) : t.parseAs) ?? "json";
			if (c.status === 204 || c.headers.get("Content-Length") === "0") {
				let n;
				switch (e) {
					case "arrayBuffer":
					case "blob":
					case "text":
						n = await c[e]();
						break;
					case "formData":
						n = new FormData();
						break;
					case "stream":
						n = c.body;
						break;
					default:
						n = {};
						break;
				}
				return t.responseStyle === "data" ? n : {
					data: n,
					...l
				};
			}
			let n;
			switch (e) {
				case "arrayBuffer":
				case "blob":
				case "formData":
				case "json":
				case "text":
					n = await c[e]();
					break;
				case "stream": return t.responseStyle === "data" ? c.body : {
					data: c.body,
					...l
				};
			}
			return e === "json" && (t.responseValidator && await t.responseValidator(n), t.responseTransformer && (n = await t.responseTransformer(n))), t.responseStyle === "data" ? n : {
				data: n,
				...l
			};
		}
		let u = await c.text(), d;
		try {
			d = JSON.parse(u);
		} catch {}
		let f = d ?? u, p = f;
		for (let e of i.error.fns) e && (p = await e(f, c, o, t));
		if (p ||= {}, t.throwOnError) throw p;
		return t.responseStyle === "data" ? void 0 : {
			error: p,
			...l
		};
	}, s = (e) => (t) => o({
		...t,
		method: e
	}), c = (e) => async (t) => {
		let { opts: n, url: r } = await a(t);
		return f({
			...n,
			body: n.body,
			headers: n.headers,
			method: e,
			onRequest: async (e, t) => {
				let r = new Request(e, t);
				for (let e of i.request.fns) e && (r = await e(r, n));
				return r;
			},
			url: r
		});
	};
	return {
		buildUrl: O,
		connect: s("CONNECT"),
		delete: s("DELETE"),
		get: s("GET"),
		getConfig: n,
		head: s("HEAD"),
		interceptors: i,
		options: s("OPTIONS"),
		patch: s("PATCH"),
		post: s("POST"),
		put: s("PUT"),
		request: o,
		setConfig: r,
		sse: {
			connect: c("CONNECT"),
			delete: c("DELETE"),
			get: c("GET"),
			head: c("HEAD"),
			options: c("OPTIONS"),
			patch: c("PATCH"),
			post: c("POST"),
			put: c("PUT"),
			trace: c("TRACE")
		},
		trace: s("TRACE")
	};
})(((e) => ({
	...e,
	...c.getConfig()
}))(I({ baseUrl: "https://localhost:5000" }))), R = class {
	static ping(e) {
		return (e?.client ?? L).get({
			security: [{
				scheme: "bearer",
				type: "http"
			}],
			url: "/umbraco/imadespeedwareweb/api/v1/ping",
			...e
		});
	}
	static whatsMyName(e) {
		return (e?.client ?? L).get({
			security: [{
				scheme: "bearer",
				type: "http"
			}],
			url: "/umbraco/imadespeedwareweb/api/v1/whatsMyName",
			...e
		});
	}
	static whatsTheTimeMrWolf(e) {
		return (e?.client ?? L).get({
			security: [{
				scheme: "bearer",
				type: "http"
			}],
			url: "/umbraco/imadespeedwareweb/api/v1/whatsTheTimeMrWolf",
			...e
		});
	}
	static whoAmI(e) {
		return (e?.client ?? L).get({
			security: [{
				scheme: "bearer",
				type: "http"
			}],
			url: "/umbraco/imadespeedwareweb/api/v1/whoAmI",
			...e
		});
	}
	static getTeachers(e) {
		return (e?.client ?? L).get({
			security: [{
				scheme: "bearer",
				type: "http"
			}],
			url: "/umbraco/imadespeedwareweb/api/v1/teachers",
			...e
		});
	}
	static getPlayTeachers(e) {
		return (e?.client ?? L).get({
			security: [{
				scheme: "bearer",
				type: "http"
			}],
			url: "/umbraco/imadespeedwareweb/api/v1/play-teachers",
			...e
		});
	}
	static getPlayBookingTypes(e) {
		return (e?.client ?? L).get({
			security: [{
				scheme: "bearer",
				type: "http"
			}],
			url: "/umbraco/imadespeedwareweb/api/v1/play-booking-types",
			...e
		});
	}
	static getBookingTypes(e) {
		return (e?.client ?? L).get({
			security: [{
				scheme: "bearer",
				type: "http"
			}],
			url: "/umbraco/imadespeedwareweb/api/v1/booking-types",
			...e
		});
	}
	static getPublishingTypes(e) {
		return (e?.client ?? L).get({
			security: [{
				scheme: "bearer",
				type: "http"
			}],
			url: "/umbraco/imadespeedwareweb/api/v1/publishing-types",
			...e
		});
	}
	static getSchools(e) {
		return (e?.client ?? L).get({
			security: [{
				scheme: "bearer",
				type: "http"
			}],
			url: "/umbraco/imadespeedwareweb/api/v1/schools",
			...e
		});
	}
	static getRooms(e) {
		return (e?.client ?? L).get({
			security: [{
				scheme: "bearer",
				type: "http"
			}],
			url: "/umbraco/imadespeedwareweb/api/v1/rooms",
			...e
		});
	}
};
//#endregion
export { u as n, l as r, R as t };

//# sourceMappingURL=api-DQ8BC5Id.js.map
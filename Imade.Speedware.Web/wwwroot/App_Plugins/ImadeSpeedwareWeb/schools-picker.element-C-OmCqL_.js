import { n as e, r as t, t as n } from "./api-CAMr9zkn.js";
import { customElement as r } from "@umbraco-cms/backoffice/external/lit";
//#region src/property-editors/schools-picker/schools-picker.element.ts
var i = class extends e {
	constructor(...e) {
		super(...e), this.localizationKey = "speedwareSchoolsPicker";
	}
	async fetchItems() {
		let { data: e } = await n.getSchools({ throwOnError: !0 });
		return e.map((e) => ({
			id: e.id,
			label: e.name
		}));
	}
};
i = t([r("imade-speedware-schools-picker")], i);
var a = i;
//#endregion
export { i as SchoolsPickerElement, a as default };

//# sourceMappingURL=schools-picker.element-C-OmCqL_.js.map
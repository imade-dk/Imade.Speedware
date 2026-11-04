import { n as e, r as t, t as n } from "./api-DDDfsnpu.js";
import { customElement as r } from "@umbraco-cms/backoffice/external/lit";
//#region src/property-editors/teachers-picker/teachers-picker.element.ts
var i = class extends e {
	constructor(...e) {
		super(...e), this.localizationKey = "speedwareTeachersPicker";
	}
	async fetchItems() {
		let { data: e } = await n.getTeachers({ throwOnError: !0 });
		return e.map((e) => ({
			id: e.id,
			label: e.name
		}));
	}
};
i = t([r("imade-speedware-teachers-picker")], i);
var a = i;
//#endregion
export { i as TeachersPickerElement, a as default };

//# sourceMappingURL=teachers-picker.element-CCbpUbmr.js.map
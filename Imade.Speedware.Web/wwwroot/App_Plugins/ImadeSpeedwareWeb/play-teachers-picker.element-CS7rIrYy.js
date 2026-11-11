import { n as e, r as t, t as n } from "./api-CAMr9zkn.js";
import { customElement as r } from "@umbraco-cms/backoffice/external/lit";
//#region src/property-editors/play-teachers-picker/play-teachers-picker.element.ts
var i = class extends e {
	constructor(...e) {
		super(...e), this.localizationKey = "speedwarePlayTeachersPicker";
	}
	async fetchItems() {
		let { data: e } = await n.getPlayTeachers({ throwOnError: !0 });
		return e.map((e) => ({
			id: e.id,
			label: e.name
		}));
	}
};
i = t([r("imade-speedware-play-teachers-picker")], i);
var a = i;
//#endregion
export { i as PlayTeachersPickerElement, a as default };

//# sourceMappingURL=play-teachers-picker.element-CS7rIrYy.js.map
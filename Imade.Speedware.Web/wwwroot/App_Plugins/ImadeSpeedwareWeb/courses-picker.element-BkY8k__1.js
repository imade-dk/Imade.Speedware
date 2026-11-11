import { n as e, r as t, t as n } from "./api-CAMr9zkn.js";
import { customElement as r } from "@umbraco-cms/backoffice/external/lit";
//#region src/property-editors/courses-picker/courses-picker.element.ts
var i = class extends e {
	constructor(...e) {
		super(...e), this.localizationKey = "speedwareCoursesPicker";
	}
	async fetchItems() {
		let { data: e } = await n.getCourses({ throwOnError: !0 });
		return e.map((e) => ({
			id: e.id,
			label: e.name
		}));
	}
};
i = t([r("imade-speedware-courses-picker")], i);
var a = i;
//#endregion
export { i as CoursesPickerElement, a as default };

//# sourceMappingURL=courses-picker.element-BkY8k__1.js.map
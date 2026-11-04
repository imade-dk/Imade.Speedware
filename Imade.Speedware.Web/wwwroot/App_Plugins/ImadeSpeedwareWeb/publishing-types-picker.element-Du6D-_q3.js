import { n as e, r as t, t as n } from "./api-DQ8BC5Id.js";
import { customElement as r } from "@umbraco-cms/backoffice/external/lit";
//#region src/property-editors/publishing-types-picker/publishing-types-picker.element.ts
var i = class extends e {
	constructor(...e) {
		super(...e), this.localizationKey = "speedwarePublishingTypesPicker";
	}
	async fetchItems() {
		let { data: e } = await n.getPublishingTypes({ throwOnError: !0 });
		return e.map((e) => ({
			id: e.id,
			label: e.name
		}));
	}
};
i = t([r("imade-speedware-publishing-types-picker")], i);
var a = i;
//#endregion
export { i as PublishingTypesPickerElement, a as default };

//# sourceMappingURL=publishing-types-picker.element-Du6D-_q3.js.map
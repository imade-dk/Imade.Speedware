import { n as e, r as t, t as n } from "./api-BGVzrnin.js";
import { customElement as r } from "@umbraco-cms/backoffice/external/lit";
//#region src/property-editors/offering-base-picker/offering-base-picker.element.ts
var i = class extends e {
	constructor(...e) {
		super(...e), this.localizationKey = "speedwareOfferingBasePicker";
	}
	async fetchItems() {
		let { data: e } = await n.getOfferingBases({ throwOnError: !0 });
		return e.map((e) => ({
			id: e.id,
			label: e.name
		}));
	}
};
i = t([r("imade-speedware-offering-base-picker")], i);
var a = i;
//#endregion
export { i as OfferingBasePickerElement, a as default };

//# sourceMappingURL=offering-base-picker.element-D_z1GJ1R.js.map
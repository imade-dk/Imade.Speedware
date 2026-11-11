import { n as e, r as t, t as n } from "./api-BfM7j7ti.js";
import { customElement as r } from "@umbraco-cms/backoffice/external/lit";
//#region src/property-editors/booking-types-picker/booking-types-picker.element.ts
var i = class extends e {
	constructor(...e) {
		super(...e), this.localizationKey = "speedwareBookingTypesPicker";
	}
	async fetchItems() {
		let { data: e } = await n.getBookingTypes({ throwOnError: !0 });
		return e.map((e) => ({
			id: e.id,
			label: e.name
		}));
	}
};
i = t([r("imade-speedware-booking-types-picker")], i);
var a = i;
//#endregion
export { i as BookingTypesPickerElement, a as default };

//# sourceMappingURL=booking-types-picker.element-DFRMFvnG.js.map
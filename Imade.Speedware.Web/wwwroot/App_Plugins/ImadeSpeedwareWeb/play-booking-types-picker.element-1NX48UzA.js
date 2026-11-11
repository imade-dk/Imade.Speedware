import { n as e, r as t, t as n } from "./api-BGVzrnin.js";
import { customElement as r } from "@umbraco-cms/backoffice/external/lit";
//#region src/property-editors/play-booking-types-picker/play-booking-types-picker.element.ts
var i = class extends e {
	constructor(...e) {
		super(...e), this.localizationKey = "speedwarePlayBookingTypesPicker";
	}
	async fetchItems() {
		let { data: e } = await n.getPlayBookingTypes({ throwOnError: !0 });
		return e.map((e) => ({
			id: e.id,
			label: e.name
		}));
	}
};
i = t([r("imade-speedware-play-booking-types-picker")], i);
var a = i;
//#endregion
export { i as PlayBookingTypesPickerElement, a as default };

//# sourceMappingURL=play-booking-types-picker.element-1NX48UzA.js.map
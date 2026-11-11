import { n as e, r as t, t as n } from "./api-CAMr9zkn.js";
import { customElement as r } from "@umbraco-cms/backoffice/external/lit";
//#region src/property-editors/rooms-picker/rooms-picker.element.ts
var i = class extends e {
	constructor(...e) {
		super(...e), this.localizationKey = "speedwareRoomsPicker";
	}
	async fetchItems() {
		let { data: e } = await n.getRooms({ throwOnError: !0 });
		return e.map((e) => ({
			id: e.id,
			label: e.name
		}));
	}
};
i = t([r("imade-speedware-rooms-picker")], i);
var a = i;
//#endregion
export { i as RoomsPickerElement, a as default };

//# sourceMappingURL=rooms-picker.element-CZ4WHZej.js.map
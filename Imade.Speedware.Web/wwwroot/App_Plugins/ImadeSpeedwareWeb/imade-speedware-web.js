import { n as e } from "./settings-BUTm8EbK.js";
//#region src/entrypoints/manifest.ts
var t = [{
	name: "Imade Speedware Web Entrypoint",
	alias: "Imade.Speedware.Web.Entrypoint",
	type: "backofficeEntryPoint",
	js: () => import("./entrypoint-CGMbS-uN.js")
}], n = [
	{
		type: "localization",
		alias: "Imade.Speedware.Web.En",
		name: "English",
		meta: { culture: "en" },
		js: () => import("./en-Cq7UWLsd.js")
	},
	{
		type: "localization",
		alias: "Imade.Speedware.Web.Da",
		name: "Dansk",
		meta: { culture: "da" },
		js: () => import("./da-Dz_Xitmr.js")
	},
	{
		type: "localization",
		alias: "Imade.Speedware.Web.Nb",
		name: "Norsk",
		meta: { culture: "nb" },
		js: () => import("./nb-CjCN58Hh.js")
	}
], r = [{
	type: "propertyEditorUi",
	alias: "Imade.Speedware.Web.TeacherPicker",
	name: "Speedware Teacher Picker",
	element: () => import("./teachers-picker.element-CCbpUbmr.js"),
	meta: {
		label: "Speedware Teacher Picker",
		icon: "icon-user",
		group: "Pickers",
		propertyEditorSchemaAlias: "Umbraco.Plain.String",
		settings: e
	}
}], i = [{
	type: "propertyEditorUi",
	alias: "Imade.Speedware.Web.PlayTeacherPicker",
	name: "Speedware Play Teacher Picker",
	element: () => import("./play-teachers-picker.element-DJz1VgS9.js"),
	meta: {
		label: "Speedware Play Teacher Picker",
		icon: "icon-user",
		group: "Pickers",
		propertyEditorSchemaAlias: "Umbraco.Plain.String",
		settings: e
	}
}], a = [{
	type: "propertyEditorUi",
	alias: "Imade.Speedware.Web.RoomPicker",
	name: "Speedware Room Picker",
	element: () => import("./rooms-picker.element-BOpaT0px.js"),
	meta: {
		label: "Speedware Room Picker",
		icon: "icon-door-open-alt",
		group: "Pickers",
		propertyEditorSchemaAlias: "Umbraco.Plain.String",
		settings: e
	}
}], o = [{
	type: "propertyEditorUi",
	alias: "Imade.Speedware.Web.SchoolPicker",
	name: "Speedware School Picker",
	element: () => import("./schools-picker.element-sAbgekUF.js"),
	meta: {
		label: "Speedware School Picker",
		icon: "icon-school",
		group: "Pickers",
		propertyEditorSchemaAlias: "Umbraco.Plain.String",
		settings: e
	}
}], s = [{
	type: "propertyEditorUi",
	alias: "Imade.Speedware.Web.PublishingTypePicker",
	name: "Speedware Publishing Type Picker",
	element: () => import("./publishing-types-picker.element-D3x6Sxqe.js"),
	meta: {
		label: "Speedware Publishing Type Picker",
		icon: "icon-globe",
		group: "Pickers",
		propertyEditorSchemaAlias: "Umbraco.Plain.String",
		settings: e
	}
}], c = [{
	type: "propertyEditorUi",
	alias: "Imade.Speedware.Web.BookingTypePicker",
	name: "Speedware Booking Type Picker",
	element: () => import("./booking-types-picker.element-Bhh2XHsB.js"),
	meta: {
		label: "Speedware Booking Type Picker",
		icon: "icon-calendar",
		group: "Pickers",
		propertyEditorSchemaAlias: "Umbraco.Plain.String",
		settings: e
	}
}], l = [{
	type: "propertyEditorUi",
	alias: "Imade.Speedware.Web.PlayBookingTypePicker",
	name: "Speedware Play Booking Type Picker",
	element: () => import("./play-booking-types-picker.element-BQ-hIoCw.js"),
	meta: {
		label: "Speedware Play Booking Type Picker",
		icon: "icon-calendar",
		group: "Pickers",
		propertyEditorSchemaAlias: "Umbraco.Plain.String",
		settings: e
	}
}], u = [{
	type: "propertyEditorUi",
	alias: "Imade.Speedware.Web.OfferingBasePicker",
	name: "Speedware Offering Base Picker",
	element: () => import("./offering-base-picker.element-CXzJgYIH.js"),
	meta: {
		label: "Speedware Offering Base Picker",
		icon: "icon-books",
		group: "Pickers",
		propertyEditorSchemaAlias: "Umbraco.Plain.String",
		settings: e
	}
}], d = [{
	type: "propertyEditorUi",
	alias: "Imade.Speedware.Web.CoursePicker",
	name: "Speedware Course Picker",
	element: () => import("./courses-picker.element-BhfuzvHI.js"),
	meta: {
		label: "Speedware Course Picker",
		icon: "icon-certificate",
		group: "Pickers",
		propertyEditorSchemaAlias: "Umbraco.Plain.String",
		settings: e
	}
}], f = [
	...r,
	...i,
	...a,
	...o,
	...s,
	...c,
	...l,
	...u,
	...d
], p = [
	...t,
	...n,
	...f
];
//#endregion
export { p as manifests };

//# sourceMappingURL=imade-speedware-web.js.map
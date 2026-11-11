import { a as e, i as t, o as n } from "./settings-C7KJQuqq.js";
//#region src/entrypoints/manifest.ts
var r = [{
	name: "Imade Speedware Web Entrypoint",
	alias: "Imade.Speedware.Web.Entrypoint",
	type: "backofficeEntryPoint",
	js: () => import("./entrypoint-CGMbS-uN.js")
}], i = [
	{
		type: "localization",
		alias: "Imade.Speedware.Web.En",
		name: "English",
		meta: { culture: "en" },
		js: () => import("./en-9_AoLdJZ.js")
	},
	{
		type: "localization",
		alias: "Imade.Speedware.Web.Da",
		name: "Dansk",
		meta: { culture: "da" },
		js: () => import("./da-CqTEtLfJ.js")
	},
	{
		type: "localization",
		alias: "Imade.Speedware.Web.Nb",
		name: "Norsk",
		meta: { culture: "nb" },
		js: () => import("./nb-DWV5CKym.js")
	}
], a = [{
	type: "propertyEditorUi",
	alias: "Imade.Speedware.Web.TeacherPicker",
	name: "Speedware Teacher Picker",
	element: () => import("./teachers-picker.element-Bi3_q0fr.js"),
	meta: {
		label: "Speedware Teacher Picker",
		icon: "icon-user",
		group: "Pickers",
		propertyEditorSchemaAlias: "Umbraco.Plain.String",
		settings: e
	}
}], o = [{
	type: "propertyEditorUi",
	alias: "Imade.Speedware.Web.PlayTeacherPicker",
	name: "Speedware Play Teacher Picker",
	element: () => import("./play-teachers-picker.element-CcPBrwXS.js"),
	meta: {
		label: "Speedware Play Teacher Picker",
		icon: "icon-user",
		group: "Pickers",
		propertyEditorSchemaAlias: "Umbraco.Plain.String",
		settings: e
	}
}], s = [{
	type: "propertyEditorUi",
	alias: "Imade.Speedware.Web.RoomPicker",
	name: "Speedware Room Picker",
	element: () => import("./rooms-picker.element-MycAo6H8.js"),
	meta: {
		label: "Speedware Room Picker",
		icon: "icon-door-open-alt",
		group: "Pickers",
		propertyEditorSchemaAlias: "Umbraco.Plain.String",
		settings: e
	}
}], c = [{
	type: "propertyEditorUi",
	alias: "Imade.Speedware.Web.SchoolPicker",
	name: "Speedware School Picker",
	element: () => import("./schools-picker.element-C9ZRHFtc.js"),
	meta: {
		label: "Speedware School Picker",
		icon: "icon-school",
		group: "Pickers",
		propertyEditorSchemaAlias: "Umbraco.Plain.String",
		settings: e
	}
}], l = [{
	type: "propertyEditorUi",
	alias: "Imade.Speedware.Web.PublishingTypePicker",
	name: "Speedware Publishing Type Picker",
	element: () => import("./publishing-types-picker.element-vln9RTIY.js"),
	meta: {
		label: "Speedware Publishing Type Picker",
		icon: "icon-globe",
		group: "Pickers",
		propertyEditorSchemaAlias: "Umbraco.Plain.String",
		settings: e
	}
}], u = [{
	type: "propertyEditorUi",
	alias: "Imade.Speedware.Web.BookingTypePicker",
	name: "Speedware Booking Type Picker",
	element: () => import("./booking-types-picker.element-Cr8XdI8J.js"),
	meta: {
		label: "Speedware Booking Type Picker",
		icon: "icon-calendar",
		group: "Pickers",
		propertyEditorSchemaAlias: "Umbraco.Plain.String",
		settings: e
	}
}], d = [{
	type: "propertyEditorUi",
	alias: "Imade.Speedware.Web.PlayBookingTypePicker",
	name: "Speedware Play Booking Type Picker",
	element: () => import("./play-booking-types-picker.element-1NX48UzA.js"),
	meta: {
		label: "Speedware Play Booking Type Picker",
		icon: "icon-calendar",
		group: "Pickers",
		propertyEditorSchemaAlias: "Umbraco.Plain.String",
		settings: e
	}
}], f = [{
	type: "propertyEditorUi",
	alias: "Imade.Speedware.Web.OfferingBasePicker",
	name: "Speedware Offering Base Picker",
	element: () => import("./offering-base-picker.element-D_z1GJ1R.js"),
	meta: {
		label: "Speedware Offering Base Picker",
		icon: "icon-books",
		group: "Pickers",
		propertyEditorSchemaAlias: "Umbraco.Plain.String",
		settings: t
	}
}], p = [{
	type: "propertyEditorUi",
	alias: "Imade.Speedware.Web.CoursePicker",
	name: "Speedware Course Picker",
	element: () => import("./courses-picker.element-DJjChePD.js"),
	meta: {
		label: "Speedware Course Picker",
		icon: "icon-certificate",
		group: "Pickers",
		propertyEditorSchemaAlias: "Umbraco.Plain.String",
		settings: t
	}
}], m = [{
	type: "propertyEditorUi",
	alias: "Imade.Speedware.Web.CoursesTreePicker",
	name: "Speedware Courses Tree Picker",
	element: () => import("./courses-tree-picker.element-CR8k63na.js"),
	meta: {
		label: "Speedware Courses Tree Picker",
		icon: "icon-tree",
		group: "Pickers",
		propertyEditorSchemaAlias: "Umbraco.Plain.String",
		settings: n
	}
}], h = [
	...a,
	...o,
	...s,
	...c,
	...l,
	...u,
	...d,
	...f,
	...p,
	...m
], g = [
	...r,
	...i,
	...h
];
//#endregion
export { g as manifests };

//# sourceMappingURL=imade-speedware-web.js.map
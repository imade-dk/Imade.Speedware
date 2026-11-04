//#region src/entrypoints/manifest.ts
var e = [{
	name: "Imade Speedware Web Entrypoint",
	alias: "Imade.Speedware.Web.Entrypoint",
	type: "backofficeEntryPoint",
	js: () => import("./entrypoint-D9PqLTTE.js")
}], t = [
	{
		type: "localization",
		alias: "Imade.Speedware.Web.En",
		name: "English",
		meta: { culture: "en" },
		js: () => import("./en-CpDbLsjQ.js")
	},
	{
		type: "localization",
		alias: "Imade.Speedware.Web.Da",
		name: "Dansk",
		meta: { culture: "da" },
		js: () => import("./da-CK0ZCtwm.js")
	},
	{
		type: "localization",
		alias: "Imade.Speedware.Web.Nb",
		name: "Norsk",
		meta: { culture: "nb" },
		js: () => import("./nb-DzWZCtTb.js")
	}
], n = [{
	type: "propertyEditorUi",
	alias: "Imade.Speedware.Web.TeacherPicker",
	name: "Speedware Teacher Picker",
	element: () => import("./teachers-picker.element-BCzNH8lz.js"),
	meta: {
		label: "Speedware Teacher Picker",
		icon: "icon-user",
		group: "Pickers",
		propertyEditorSchemaAlias: "Umbraco.Plain.String"
	}
}], r = [{
	type: "propertyEditorUi",
	alias: "Imade.Speedware.Web.PlayTeacherPicker",
	name: "Speedware Play Teacher Picker",
	element: () => import("./play-teachers-picker.element-DJuWpRzW.js"),
	meta: {
		label: "Speedware Play Teacher Picker",
		icon: "icon-user",
		group: "Pickers",
		propertyEditorSchemaAlias: "Umbraco.Plain.String"
	}
}], i = [{
	type: "propertyEditorUi",
	alias: "Imade.Speedware.Web.RoomPicker",
	name: "Speedware Room Picker",
	element: () => import("./rooms-picker.element-Cuk_EOmB.js"),
	meta: {
		label: "Speedware Room Picker",
		icon: "icon-door-open-alt",
		group: "Pickers",
		propertyEditorSchemaAlias: "Umbraco.Plain.String"
	}
}], a = [{
	type: "propertyEditorUi",
	alias: "Imade.Speedware.Web.SchoolPicker",
	name: "Speedware School Picker",
	element: () => import("./schools-picker.element-BqajfSE5.js"),
	meta: {
		label: "Speedware School Picker",
		icon: "icon-school",
		group: "Pickers",
		propertyEditorSchemaAlias: "Umbraco.Plain.String"
	}
}], o = [{
	type: "propertyEditorUi",
	alias: "Imade.Speedware.Web.PublishingTypePicker",
	name: "Speedware Publishing Type Picker",
	element: () => import("./publishing-types-picker.element-Du6D-_q3.js"),
	meta: {
		label: "Speedware Publishing Type Picker",
		icon: "icon-globe",
		group: "Pickers",
		propertyEditorSchemaAlias: "Umbraco.Plain.String"
	}
}], s = [{
	type: "propertyEditorUi",
	alias: "Imade.Speedware.Web.BookingTypePicker",
	name: "Speedware Booking Type Picker",
	element: () => import("./booking-types-picker.element-wucDavRg.js"),
	meta: {
		label: "Speedware Booking Type Picker",
		icon: "icon-calendar",
		group: "Pickers",
		propertyEditorSchemaAlias: "Umbraco.Plain.String"
	}
}], c = [{
	type: "propertyEditorUi",
	alias: "Imade.Speedware.Web.PlayBookingTypePicker",
	name: "Speedware Play Booking Type Picker",
	element: () => import("./play-booking-types-picker.element-c5YBIiIT.js"),
	meta: {
		label: "Speedware Play Booking Type Picker",
		icon: "icon-calendar",
		group: "Pickers",
		propertyEditorSchemaAlias: "Umbraco.Plain.String"
	}
}], l = [
	...n,
	...r,
	...i,
	...a,
	...o,
	...s,
	...c
], u = [
	...e,
	...t,
	...l
];
//#endregion
export { u as manifests };

//# sourceMappingURL=imade-speedware-web.js.map
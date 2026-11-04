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
		js: () => import("./en-ChtVRBUd.js")
	},
	{
		type: "localization",
		alias: "Imade.Speedware.Web.Da",
		name: "Dansk",
		meta: { culture: "da" },
		js: () => import("./da-pkLQI3-A.js")
	},
	{
		type: "localization",
		alias: "Imade.Speedware.Web.Nb",
		name: "Norsk",
		meta: { culture: "nb" },
		js: () => import("./nb-CAE2OrXL.js")
	}
], n = [{
	type: "propertyEditorUi",
	alias: "Imade.Speedware.Web.TeacherPicker",
	name: "Speedware Teacher Picker",
	element: () => import("./teachers-picker.element-Xj3lQU6e.js"),
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
	element: () => import("./play-teachers-picker.element-DP06QT5R.js"),
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
	element: () => import("./rooms-picker.element-Dap-dPtl.js"),
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
	element: () => import("./schools-picker.element-BAqaglP7.js"),
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
	element: () => import("./publishing-types-picker.element-CSLCi0XP.js"),
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
	element: () => import("./booking-types-picker.element-Do_0bdeS.js"),
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
	element: () => import("./play-booking-types-picker.element-D7GyxJ9G.js"),
	meta: {
		label: "Speedware Play Booking Type Picker",
		icon: "icon-calendar",
		group: "Pickers",
		propertyEditorSchemaAlias: "Umbraco.Plain.String"
	}
}], l = [{
	type: "propertyEditorUi",
	alias: "Imade.Speedware.Web.OfferingBasePicker",
	name: "Speedware Offering Base Picker",
	element: () => import("./offering-base-picker.element-DaWeSm-I.js"),
	meta: {
		label: "Speedware Offering Base Picker",
		icon: "icon-books",
		group: "Pickers",
		propertyEditorSchemaAlias: "Umbraco.Plain.String"
	}
}], u = [{
	type: "propertyEditorUi",
	alias: "Imade.Speedware.Web.CoursePicker",
	name: "Speedware Course Picker",
	element: () => import("./courses-picker.element-CpwGriny.js"),
	meta: {
		label: "Speedware Course Picker",
		icon: "icon-certificate",
		group: "Pickers",
		propertyEditorSchemaAlias: "Umbraco.Plain.String"
	}
}], d = [
	...n,
	...r,
	...i,
	...a,
	...o,
	...s,
	...c,
	...l,
	...u
], f = [
	...e,
	...t,
	...d
];
//#endregion
export { f as manifests };

//# sourceMappingURL=imade-speedware-web.js.map
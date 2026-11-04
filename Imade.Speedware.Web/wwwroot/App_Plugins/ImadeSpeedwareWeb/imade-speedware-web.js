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
		js: () => import("./en-C9FzlI8z.js")
	},
	{
		type: "localization",
		alias: "Imade.Speedware.Web.Da",
		name: "Dansk",
		meta: { culture: "da" },
		js: () => import("./da-CPCorWPJ.js")
	},
	{
		type: "localization",
		alias: "Imade.Speedware.Web.Nb",
		name: "Norsk",
		meta: { culture: "nb" },
		js: () => import("./nb-CeLIceL-.js")
	}
], n = [{
	type: "propertyEditorUi",
	alias: "Imade.Speedware.Web.TeacherPicker",
	name: "Speedware Teacher Picker",
	element: () => import("./teachers-picker.element-BzvASlH-.js"),
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
	element: () => import("./play-teachers-picker.element-CBjJjlN_.js"),
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
	element: () => import("./rooms-picker.element-D2iY50uX.js"),
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
	element: () => import("./schools-picker.element-BYEdb_4e.js"),
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
	element: () => import("./publishing-types-picker.element-OucRS-Va.js"),
	meta: {
		label: "Speedware Publishing Type Picker",
		icon: "icon-globe",
		group: "Pickers",
		propertyEditorSchemaAlias: "Umbraco.Plain.String"
	}
}], s = [
	...n,
	...r,
	...i,
	...a,
	...o
], c = [
	...e,
	...t,
	...s
];
//#endregion
export { c as manifests };

//# sourceMappingURL=imade-speedware-web.js.map
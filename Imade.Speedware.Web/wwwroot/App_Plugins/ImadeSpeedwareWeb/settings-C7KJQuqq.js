//#region src/property-editors/settings.ts
var e = "showDebug", t = "showSelected", n = {
	properties: [{
		alias: e,
		label: "#speedwarePickerSettings_showDebugLabel",
		description: "{#speedwarePickerSettings_showDebugDescription}",
		propertyEditorUiAlias: "Umb.PropertyEditorUi.Toggle"
	}],
	defaultData: [{
		alias: e,
		value: !1
	}]
}, r = {
	properties: [...n.properties, {
		alias: t,
		label: "#speedwarePickerSettings_showSelectedLabel",
		description: "{#speedwarePickerSettings_showSelectedDescription}",
		propertyEditorUiAlias: "Umb.PropertyEditorUi.Toggle"
	}],
	defaultData: [...n.defaultData, {
		alias: t,
		value: !0
	}]
}, i = "validationLimit", a = {
	properties: [...n.properties, {
		alias: i,
		label: "#speedwarePickerSettings_amountLabel",
		description: "{#speedwarePickerSettings_amountDescription}",
		propertyEditorUiAlias: "Umb.PropertyEditorUi.NumberRange",
		config: [{
			alias: "validationRange",
			value: { min: 0 }
		}]
	}],
	defaultData: [...n.defaultData, {
		alias: i,
		value: {
			min: 0,
			max: 0
		}
	}]
};
//#endregion
export { n as a, a as i, t as n, r as o, i as r, e as t };

//# sourceMappingURL=settings-C7KJQuqq.js.map
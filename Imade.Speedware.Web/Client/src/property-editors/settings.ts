/** Alias of the "show debug information" setting shared by all Speedware pickers. */
export const SHOW_DEBUG_SETTING_ALIAS = 'showDebug';

/** Alias of the "show selected nodes" setting (tags below the tree) of the courses tree picker. */
export const SHOW_SELECTED_SETTING_ALIAS = 'showSelected';

/** Data type settings shared by all Speedware pickers (spread into each manifest's `meta.settings`). */
export const pickerSettings = {
	properties: [
		{
			alias: SHOW_DEBUG_SETTING_ALIAS,
			label: '#speedwarePickerSettings_showDebugLabel',
			description: '{#speedwarePickerSettings_showDebugDescription}',
			propertyEditorUiAlias: 'Umb.PropertyEditorUi.Toggle',
		},
	],
	defaultData: [{ alias: SHOW_DEBUG_SETTING_ALIAS, value: false }],
};

/** Settings for the courses tree picker: the shared ones plus "show selected nodes" (default on). */
export const treePickerSettings = {
	properties: [
		...pickerSettings.properties,
		{
			alias: SHOW_SELECTED_SETTING_ALIAS,
			label: '#speedwarePickerSettings_showSelectedLabel',
			description: '{#speedwarePickerSettings_showSelectedDescription}',
			propertyEditorUiAlias: 'Umb.PropertyEditorUi.Toggle',
		},
	],
	defaultData: [...pickerSettings.defaultData, { alias: SHOW_SELECTED_SETTING_ALIAS, value: true }],
};

/** Alias of the min/max "amount" setting (0 / empty = unlimited), same shape as the Block List's `validationLimit`. */
export const VALIDATION_LIMIT_SETTING_ALIAS = 'validationLimit';

/** Settings for pickers with a selection limit: the shared ones plus an "Amount" min/max range. */
export const limitedPickerSettings = {
	properties: [
		...pickerSettings.properties,
		{
			alias: VALIDATION_LIMIT_SETTING_ALIAS,
			label: '#speedwarePickerSettings_amountLabel',
			description: '{#speedwarePickerSettings_amountDescription}',
			propertyEditorUiAlias: 'Umb.PropertyEditorUi.NumberRange',
			config: [{ alias: 'validationRange', value: { min: 0 } }],
		},
	],
	defaultData: [...pickerSettings.defaultData, { alias: VALIDATION_LIMIT_SETTING_ALIAS, value: { min: 0, max: 0 } }],
};

/** Alias of the "show debug information" setting shared by all Speedware pickers. */
export const SHOW_DEBUG_SETTING_ALIAS = 'showDebug';

/** Data type settings shared by all Speedware pickers (spread into each manifest's `meta.settings`). */
export const pickerSettings = {
	properties: [
		{
			alias: SHOW_DEBUG_SETTING_ALIAS,
			label: '#speedwarePickerSettings_showDebugLabel',
			description: '#speedwarePickerSettings_showDebugDescription',
			propertyEditorUiAlias: 'Umb.PropertyEditorUi.Toggle',
		},
	],
	defaultData: [{ alias: SHOW_DEBUG_SETTING_ALIAS, value: false }],
};

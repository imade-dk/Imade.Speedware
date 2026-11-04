import { pickerSettings } from '../settings.js';

export const manifests: Array<UmbExtensionManifest> = [
	{
		type: 'propertyEditorUi',
		alias: 'Imade.Speedware.Web.SchoolPicker',
		name: 'Speedware School Picker',
		element: () => import('./schools-picker.element.js'),
		meta: {
			label: 'Speedware School Picker',
			icon: 'icon-school',
			group: 'Pickers',
			propertyEditorSchemaAlias: 'Umbraco.Plain.String',
			settings: pickerSettings,
		},
	},
];

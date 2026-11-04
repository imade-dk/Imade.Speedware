import { pickerSettings } from '../settings.js';

export const manifests: Array<UmbExtensionManifest> = [
	{
		type: 'propertyEditorUi',
		alias: 'Imade.Speedware.Web.CoursePicker',
		name: 'Speedware Course Picker',
		element: () => import('./courses-picker.element.js'),
		meta: {
			label: 'Speedware Course Picker',
			icon: 'icon-certificate',
			group: 'Pickers',
			propertyEditorSchemaAlias: 'Umbraco.Plain.String',
			settings: pickerSettings,
		},
	},
];

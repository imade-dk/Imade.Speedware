import { pickerSettings } from '../settings.js';

export const manifests: Array<UmbExtensionManifest> = [
	{
		type: 'propertyEditorUi',
		alias: 'Imade.Speedware.Web.TeacherPicker',
		name: 'Speedware Teacher Picker',
		element: () => import('./teachers-picker.element.js'),
		meta: {
			label: 'Speedware Teacher Picker',
			icon: 'icon-user',
			group: 'Pickers',
			propertyEditorSchemaAlias: 'Umbraco.Plain.String',
			settings: pickerSettings,
		},
	},
];

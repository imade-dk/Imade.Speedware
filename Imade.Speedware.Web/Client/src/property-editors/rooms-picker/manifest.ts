import { pickerSettings } from '../settings.js';

export const manifests: Array<UmbExtensionManifest> = [
	{
		type: 'propertyEditorUi',
		alias: 'Imade.Speedware.Web.RoomPicker',
		name: 'Speedware Room Picker',
		element: () => import('./rooms-picker.element.js'),
		meta: {
			label: 'Speedware Room Picker',
			icon: 'icon-door-open-alt',
			group: 'Pickers',
			propertyEditorSchemaAlias: 'Umbraco.Plain.String',
			settings: pickerSettings,
		},
	},
];

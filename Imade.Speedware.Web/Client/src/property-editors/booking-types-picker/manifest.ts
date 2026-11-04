import { pickerSettings } from '../settings.js';

export const manifests: Array<UmbExtensionManifest> = [
	{
		type: 'propertyEditorUi',
		alias: 'Imade.Speedware.Web.BookingTypePicker',
		name: 'Speedware Booking Type Picker',
		element: () => import('./booking-types-picker.element.js'),
		meta: {
			label: 'Speedware Booking Type Picker',
			icon: 'icon-calendar',
			group: 'Pickers',
			propertyEditorSchemaAlias: 'Umbraco.Plain.String',
			settings: pickerSettings,
		},
	},
];

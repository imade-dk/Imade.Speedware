export const manifests: Array<UmbExtensionManifest> = [
	{
		type: 'propertyEditorUi',
		alias: 'Imade.Speedware.Web.PlayBookingTypePicker',
		name: 'Speedware Play Booking Type Picker',
		element: () => import('./play-booking-types-picker.element.js'),
		meta: {
			label: 'Speedware Play Booking Type Picker',
			icon: 'icon-calendar',
			group: 'Pickers',
			propertyEditorSchemaAlias: 'Umbraco.Plain.String',
		},
	},
];

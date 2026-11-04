export const manifests: Array<UmbExtensionManifest> = [
	{
		type: 'propertyEditorUi',
		alias: 'Imade.Speedware.Web.OfferingBasePicker',
		name: 'Speedware Offering Base Picker',
		element: () => import('./offering-base-picker.element.js'),
		meta: {
			label: 'Speedware Offering Base Picker',
			icon: 'icon-books',
			group: 'Pickers',
			propertyEditorSchemaAlias: 'Umbraco.Plain.String',
		},
	},
];

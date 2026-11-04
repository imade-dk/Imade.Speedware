export const manifests: Array<UmbExtensionManifest> = [
	{
		type: 'propertyEditorUi',
		alias: 'Imade.Speedware.Web.PublishingTypePicker',
		name: 'Speedware Publishing Type Picker',
		element: () => import('./publishing-types-picker.element.js'),
		meta: {
			label: 'Speedware Publishing Type Picker',
			icon: 'icon-globe',
			group: 'Pickers',
			propertyEditorSchemaAlias: 'Umbraco.Plain.String',
		},
	},
];

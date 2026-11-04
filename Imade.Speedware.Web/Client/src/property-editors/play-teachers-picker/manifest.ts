export const manifests: Array<UmbExtensionManifest> = [
	{
		type: 'propertyEditorUi',
		alias: 'Imade.Speedware.Web.PlayTeacherPicker',
		name: 'Speedware Play Teacher Picker',
		element: () => import('./play-teachers-picker.element.js'),
		meta: {
			label: 'Speedware Play Teacher Picker',
			icon: 'icon-user',
			group: 'Pickers',
			propertyEditorSchemaAlias: 'Umbraco.Plain.String',
		},
	},
];

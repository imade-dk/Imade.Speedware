import { treePickerSettings } from '../settings.js';

export const manifests: Array<UmbExtensionManifest> = [
	{
		type: 'propertyEditorUi',
		alias: 'Imade.Speedware.Web.CoursesTreePicker',
		name: 'Speedware Courses Tree Picker',
		element: () => import('./courses-tree-picker.element.js'),
		meta: {
			label: 'Speedware Courses Tree Picker',
			icon: 'icon-tree',
			group: 'Pickers',
			propertyEditorSchemaAlias: 'Umbraco.Plain.String',
			settings: treePickerSettings,
		},
	},
];

export const manifests: Array<UmbExtensionManifest> = [
	{
		type: 'localization',
		alias: 'Imade.Speedware.Web.En',
		name: 'English',
		meta: { culture: 'en' },
		js: () => import('./en.js'),
	},
	{
		type: 'localization',
		alias: 'Imade.Speedware.Web.Da',
		name: 'Dansk',
		meta: { culture: 'da' },
		js: () => import('./da.js'),
	},
	{
		type: 'localization',
		alias: 'Imade.Speedware.Web.Nb',
		name: 'Norsk',
		meta: { culture: 'nb' },
		js: () => import('./nb.js'),
	},
];

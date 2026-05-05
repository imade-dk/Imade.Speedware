export const manifests: Array<UmbExtensionManifest> = [
  {
    name: "Imade Speedware Web Entrypoint",
    alias: "Imade.Speedware.Web.Entrypoint",
    type: "backofficeEntryPoint",
    js: () => import("./entrypoint.js"),
  },
];

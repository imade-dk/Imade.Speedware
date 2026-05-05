# Plan: SpeedwareConfigScaffoldComposer

## Context

`Imade.Speedware.Api` defines `SpeedwareConfig` with a constant section name (`"speedware"`) and five properties with defaults. Consumers must manually add this section to `appsettings.json` — there is no guide or scaffolding. This composer auto-writes the section with defaults on first startup so developers don't have to remember the keys.

## Files to change

| File | Change |
|---|---|
| `Imade.Speedware.Web/Imade.Speedware.Web.csproj` | Add `<ProjectReference>` to `Imade.Speedware.Api` |
| `Imade.Speedware.Web/Composers/SpeedwareConfigScaffoldComposer.cs` | **Create** — new IComposer |

Reference files (read-only):
- `Imade.Speedware.Api/Core/SpeedwareConfig.cs` — source of section name and defaults
- `Imade.Speedware.Web/Composers/ImadeSpeedwareWebApiComposer.cs` — pattern for file style

## Step 1 — Add project reference

In `Imade.Speedware.Web/Imade.Speedware.Web.csproj`, add inside an `<ItemGroup>`:

```xml
<ProjectReference Include="../Imade.Speedware.Api/Imade.Speedware.Api.csproj" />
```

## Step 2 — Create the composer

`Imade.Speedware.Web/Composers/SpeedwareConfigScaffoldComposer.cs`:

```csharp
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Json.Nodes;
using Imade.Speedware.Api.Core;
using Umbraco.Cms.Core.Composing;
using Umbraco.Cms.Core.DependencyInjection;

namespace Imade.Speedware.Web.Composers
{
    public class SpeedwareConfigScaffoldComposer : IComposer
    {
        public void Compose(IUmbracoBuilder builder)
        {
            try
            {
                var appsettingsPath = Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json");

                if (!File.Exists(appsettingsPath))
                    return;

                var root = JsonNode.Parse(File.ReadAllText(appsettingsPath));
                if (root is not JsonObject rootObject)
                    return;

                if (rootObject.ContainsKey(SpeedwareConfig.SpeedwareSection))
                    return;

                var defaults = new SpeedwareConfig();
                rootObject[SpeedwareConfig.SpeedwareSection] = new JsonObject
                {
                    [nameof(SpeedwareConfig.ApiKey)]           = defaults.ApiKey,
                    [nameof(SpeedwareConfig.BaseUrl)]          = defaults.BaseUrl,
                    [nameof(SpeedwareConfig.SchoolIdentifier)] = defaults.SchoolIdentifier,
                    [nameof(SpeedwareConfig.RootUploadFolder)] = defaults.RootUploadFolder,
                    [nameof(SpeedwareConfig.CacheDuration)]    = defaults.CacheDuration,
                };

                File.WriteAllText(appsettingsPath, rootObject.ToJsonString(new JsonSerializerOptions
                {
                    WriteIndented = true,
                    Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
                }));
            }
            catch
            {
                // Scaffolding is a convenience step; never break startup.
            }
        }
    }
}
```

### Key design decisions

- **`Directory.GetCurrentDirectory()`** — ASP.NET Core's `WebApplicationBuilder` sets the process CWD to the content root before any `ConfigureServices`/`Compose` calls, so this reliably points at the directory containing `appsettings.json`.
- **Skip if section exists** — `ContainsKey` check before any write; no merging, no overwriting.
- **`nameof()` for property keys** — keeps JSON keys in sync with C# property names at compile time. The section key uses `SpeedwareConfig.SpeedwareSection` (`"speedware"`) since `nameof()` would give `"SpeedwareConfig"`.
- **`JavaScriptEncoder.UnsafeRelaxedJsonEscaping`** — prevents round-tripping `+` as `+` (the existing `appsettings.json` has a `HMACSecretKey` with `+`).
- **Silent catch** — any I/O or parse error silently returns; the section just won't be scaffolded, which is acceptable.

## Verification

1. Delete the `"speedware"` key from `Umbraco17.4.0/appsettings.json` (or confirm it's absent).
2. Run `dotnet run --project Umbraco17.4.0/Umbraco17.4.0.csproj`.
3. Open `Umbraco17.4.0/appsettings.json` — the `"speedware"` section should appear at the bottom with all five keys and their defaults.
4. Restart the site — the section is NOT re-written (skip-if-exists works).
5. Run `dotnet build Imade.Speedware.Web/Imade.Speedware.Web.csproj` to confirm no compile errors.

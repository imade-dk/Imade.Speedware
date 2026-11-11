# CLAUDE.md

This file provides guidance to Claude Code (claude.ai/code) when working with code in this repository.

## Projects

| Project | Type | Purpose |
|---|---|---|
| `Imade.Speedware.Api` | .NET 10 class library | Speedadmin REST API client |
| `Imade.Speedware.Web` | Umbraco backoffice extension | Backoffice UI for Speedadmin data |
| `Imade.Speedware.Usn` | .NET 10 class library | USN SiteBuilder integration shared by downstream projects (e.g. `SpwiBlock<T>`); the only project that references `USNSiteBuilder.Core` |
| `Umbraco17.4.0` | Umbraco 17.3.5 web app (test site) | Local dev host for the extension |

## Build

```bash
# API client
dotnet build Imade.Speedware.Api/Imade.Speedware.Api.csproj

# Extension (C#)
dotnet build Imade.Speedware.Web/Imade.Speedware.Web.csproj

# Extension (TypeScript)
cd Imade.Speedware.Web/Client && npm run build

# Run Umbraco test site (includes extension via ProjectReference)
dotnet run --project Umbraco17.4.0/Umbraco17.4.0.csproj
```

Umbraco runs on **https://localhost:44300** / **http://localhost:51437**.
Backoffice login: `kenneth@imade.dk` / `umbracoadmin`.

There are no tests yet. There is no lint step — the `.editorconfig` at the repo root enforces formatting rules that IDEs and Roslyn enforce at edit time.

## Architecture

This repo contains a .NET 10 class library (`Imade.Speedware.Api`) that wraps the Speedadmin REST API, and an Umbraco backoffice extension (`Imade.Speedware.Web`) that surfaces Speedadmin data in the Umbraco backoffice. The namespace throughout the API client is `Imade.Speedware.Api`.

### Request flow

`ISpeedwareClient` → `SpeedwareClient` → `HttpClient` (typed, configured via DI)

`SpeedwareClient` exposes three families of methods:
- `GetListAsync<T>` / `GetAsync<T>` — GET requests, deserialise JSON into a model or list
- `PostAsync<T,L>` / `PostAsyncList<T,L>` — POST with a filter/limiter body, returns `PagedResult<T>` or a flat list
- `GetBlobBytesAsync` — GET returning raw `byte[]` for file/media blobs

All methods accept a `CancellationToken`, throw `SpeedwareApiException` on failure, and log errors via `ILogger<SpeedwareClient>`.

### DI registration

Consumers call a single extension method:

```csharp
services.AddSpeedwareApiClient(configuration);
```

This wires `ISpeedwareClient → SpeedwareClient` as a typed `HttpClient`, configures base address, timeout (10 min), and the `Authorization` header, and binds `SpeedwareConfig` from the `speedware` section of `appsettings.json`.

Required config keys under `speedware`:
- `ApiKeys` — list of `{ Name, ApiKey }` Speedadmin keys (the first is used unless a name is requested via `GetApiKey(name)`); the legacy single `ApiKey` is used only when `ApiKeys` is empty (no default; throws on startup if no key is configured)
- `BaseUrl` — defaults to `https://api.speedadmin.dk/v1/`
- `SchoolIdentifier` — tenant identifier (no default)
- `RootUploadFolder` — folder for downloaded blobs (default `speedware`)
- `CacheDuration` — integer, minutes (default 10)

Never commit real API keys: keep them in `appsettings.Development.json` (gitignored) or user secrets, not in `Umbraco17.4.0/appsettings.json`.

### Model layers

Each domain entity (e.g. `Booking`, `News`, `Course`) has two layers:

1. **ViewModel** (`Models/SpeedwareViewModels/`) — abstract base class with the raw API fields, named `*ViewModel`
2. **Model** (`Models/`) — concrete class that inherits the ViewModel and adds computed properties or domain logic (e.g. `News` adds `Images`, `Files`, `Audio`, `Video` filtered from `Blobs`; `Booking` adds `StartTime`, `EndTime`, `Location`)

Add new domain logic to the model layer, not the ViewModel.

### Filters / limiters

Classes in `Filters/` implement `ILimiter` and are serialised to JSON as the POST body. They carry `Take` / `Skip` pagination, a `Sort` field (values from the `Core.Sorting` enums), and domain-specific filters. All `Take` and `Skip` properties are annotated with `[Range]` matching the API's documented limits.

`GetHashCode` in filter classes uses `Core.HashHelper` (FNV-1a) — use the existing helper methods rather than writing inline hash logic.

### Endpoints

`Core/ApiEndpoint.cs` is an enum where each value has a `[Description("...")]` attribute containing the URL path (with `{id}` placeholder where applicable). Pass enum values to `SpeedwareClient` methods; the client calls `.ToDescriptionString()` to resolve the path.

### Exceptions

`Core/SpeedwareApiException` is the single exception type thrown by `SpeedwareClient`. It optionally carries an `HttpStatusCode`. Catch this type in consuming code; do not catch `HttpRequestException` or `JsonException` directly — the client wraps both.

## Imade.Speedware.Web (backoffice extension)

`Imade.Speedware.Web` is an Umbraco backoffice extension built with the official `umbraco-extension` .NET template. It is referenced as a `<ProjectReference>` in `Umbraco17.4.0` so it loads automatically when the test site runs.

### Structure

```
Imade.Speedware.Web/
├── Imade.Speedware.Web.csproj
├── Constants.cs
├── Composers/          # C# composers (DI wiring, Swagger)
├── Controllers/        # C# API controllers exposed to the backoffice
├── Services/           # Cached services over ISpeedwareClient (one per entity)
├── Core/, Helpers/, Models/
└── Client/             # TypeScript/Vite source
    ├── package.json
    ├── vite.config.ts
    └── src/
        ├── api/        # OpenAPI client (generated, with hand-added picker entries)
        ├── entrypoints/
        ├── localization/      # en.ts, da.ts, nb.ts + manifest.ts
        ├── property-editors/  # Speedware pickers (see below)
        └── bundle.manifests.ts
```

The built bundle in `wwwroot/App_Plugins/ImadeSpeedwareWeb` is tracked in git; run `npm run build` before committing.

### Services

Each entity has an `I<Name>Service` / `<Name>Service` pair in `Services/`, registered as scoped in `Composers/SpeedwareServicesComposer.cs`. Services extend `SpeedwareServiceBase` and use `GetCachedListAsync` / `GetCachedAsync` (runtime cache, duration from `CacheDuration`) with keys like `speedware:<entity>:all` and `speedware:<entity>:{id}`. They log failures and rethrow, and throw `SpeedwareApiException` when an id is not found. Copy an existing service (e.g. `SchoolsService`) when adding one.

Existing services: Teachers, Schools, Departments, Rooms, PublishingTypes, BookingTypes, PlayBookingTypes, OfferingBase, Courses (uses `courses/all`), CoursesTree (uses `courses/tree`), Blob.

### Pickers (property editors)

Pickers are multi-select property editor UIs (`propertyEditorUi`, schema `Umbraco.Plain.String`) that store the selected ids as a JSON array string, e.g. `[1,2,3]`. All share `property-editors/speedware-picker.element.ts` (`SpeedwarePickerBaseElement`); each picker is a folder with `manifest.ts` and `<name>-picker.element.ts` that only sets `localizationKey` and implements `fetchItems()` returning `{ id, label }[]`.

Pickers: teachers, play teachers, rooms, schools, publishing types, booking types, play booking types, offering base, courses, courses tree.

The courses tree picker stores node `TreeID`s (not course ids). Its endpoint (`courses-tree`) returns a flat depth-first list `{ id, name, parentId, courseCount, active }` (only the subtree below the node with `TreeID` 1 is returned, that node itself omitted, so its children are the roots with `parentId` 0; inactive nodes included but disabled); the client builds the tree. It extends the base element by overriding `renderSelector()` and calling `setSelectedIds()`; the tags show `Parent › Child` paths and can be hidden with the tree picker's "Show selected nodes" setting (`showSelected`, default on; hides the tags and the "nothing selected" text).

The offering base and courses pickers use `limitedPickerSettings`, which adds an "Amount" min/max setting (`validationLimit`, `Umb.PropertyEditorUi.NumberRange`, like the Block List). 0 or empty means no limit. The base element mixes in `UmbFormControlMixin` and registers `rangeUnderflow`/`rangeOverflow` validators; at the maximum the combobox is disabled. Pickers without the setting are unrestricted.

Adding a picker:
1. Add (or reuse) the service and register it in `SpeedwareServicesComposer`.
2. Add an endpoint to `Controllers/SpeedwarePickersController.cs` returning `{ Id, Name }` items (filter inactive items where the model has an active flag) and its `...PickerItemDto` record.
3. Add the matching function and types to `Client/src/api/sdk.gen.ts` / `types.gen.ts` (or regenerate the client; entries so far were added by hand).
4. Create `property-editors/<name>-picker/` with the manifest (include `settings: pickerSettings`) and element, and register the manifest in `property-editors/manifest.ts`.
5. Add a localization section named after `localizationKey` (`speedware<Name>Picker`) with `pleaseSelect`, `selectedItems` and `search` to `en.ts`, `da.ts` and `nb.ts`.

All pickers share a "Show debug information" data type setting (`showDebug`, default false, defined in `property-editors/settings.ts`) that renders the stored value and selected items under the tags.

### Extension development workflow

1. Run `dotnet run --project Umbraco17.4.0/Umbraco17.4.0.csproj` to start the host.
2. In a separate terminal: `cd Imade.Speedware.Web/Client && npm run watch` for hot-reload during development.
3. Run `npm run build` before committing to produce the production bundle.

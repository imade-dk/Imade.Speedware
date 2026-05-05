# CLAUDE.md

This file provides guidance to Claude Code (claude.ai/code) when working with code in this repository.

## Build

```bash
dotnet build Imade.Speedware.Api/Imade.Speedware.Api.csproj
```

There are no tests yet. There is no lint step — the `.editorconfig` at the repo root enforces formatting rules that IDEs and Roslyn enforce at edit time.

## Architecture

This repo is a single .NET 10 class library (`Imade.Speedware.Api`) that wraps the Speedadmin REST API. The namespace throughout is `Imade.Speedadmin.Api` (note: *Speedadmin*, not *Speedware*).

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
- `ApiKey` — the Speedadmin API key (no default; throws on startup if missing)
- `BaseUrl` — defaults to `https://api.speedadmin.dk/v1/`
- `SchoolIdentifier` — tenant identifier (no default)
- `CacheDuration` — integer, minutes (default 10)

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

# People & Places Service Layer

## Context

`Imade.Speedware.Web` has only a thin controller (a `Ping` endpoint) and no service layer. The `Imade.Speedware.Api` client library provides `ISpeedwareClient` — but it had never been registered in DI within the Web project. This plan adds four domain services (Teachers, Schools, Departments, Rooms) plus a blob download service, all sitting between future controllers and `ISpeedwareClient`, with caching via Umbraco's `AppCaches.RuntimeCache`.

## Files

```
Imade.Speedware.Api/
└── Core/
    ├── SpeedwareApiKey.cs           ← new
    ├── SpeedwareConfig.cs           ← added ApiKeys list + GetApiKey()
    └── FilesAndPath.cs              ← changed internal → public

Imade.Speedware.Web/
├── Services/
│   ├── SpeedwareServiceBase.cs
│   ├── IBlobService.cs
│   ├── BlobService.cs
│   ├── ITeachersService.cs
│   ├── TeachersService.cs
│   ├── ISchoolsService.cs
│   ├── SchoolsService.cs
│   ├── IDepartmentsService.cs
│   ├── DepartmentsService.cs
│   ├── IRoomsService.cs
│   └── RoomsService.cs
└── Composers/
    └── SpeedwareServicesComposer.cs
```

## Configuration

`SpeedwareConfig` supports multiple named API keys via `SpeedwareApiKey` (`Name`, `ApiKey`).

```csharp
public class SpeedwareApiKey
{
    public string Name { get; set; } = string.Empty;
    public string ApiKey { get; set; } = string.Empty;
}

// In SpeedwareConfig:
public List<SpeedwareApiKey> ApiKeys { get; set; } = [];

public string GetApiKey(string? name = null)
{
    if (ApiKeys.Count > 0)
    {
        if (name is null)
            return ApiKeys[0].ApiKey;                    // default = first entry

        return ApiKeys
            .FirstOrDefault(k => k.Name.Equals(name, StringComparison.OrdinalIgnoreCase))?.ApiKey
            ?? throw new InvalidOperationException($"No API key configured with name '{name}'.");
    }

    return ApiKey;   // backward-compat fallback for existing appsettings.json
}
```

**Resolution rules:**
- One entry, no name → that entry is the default
- Multiple entries, name provided → find by name (case-insensitive), throw if missing
- Multiple entries, no name → first entry
- `ApiKeys` empty → fall back to the legacy `ApiKey` string property

`ServiceCollectionExtensions` calls `config.GetApiKey()` (no name) when configuring the `HttpClient` `Authorization` header at startup.

`SpeedwareConfigScaffoldComposer` writes the new `ApiKeys` array format for fresh installs:
```json
"speedware": {
  "ApiKeys": [{ "Name": "", "ApiKey": "" }],
  ...
}
```

## Base Class

`SpeedwareServiceBase` holds the shared infrastructure. All services inherit from it. `_config` is `protected` so subclasses can read `RootUploadFolder` and other config values.

```csharp
public abstract class SpeedwareServiceBase
{
    protected readonly ISpeedwareClient _client;
    protected readonly SpeedwareConfig _config;
    private readonly IAppPolicyCache _cache;

    protected SpeedwareServiceBase(ISpeedwareClient client, AppCaches appCaches, IOptions<SpeedwareConfig> config)
    {
        _client = client;
        _cache = appCaches.RuntimeCache;
        _config = config.Value;
    }

    protected async Task<List<T>> GetCachedListAsync<T>(string key, Func<Task<List<T>?>> factory)
        => await _cache.GetCacheItemAsync<List<T>>(key, factory, TimeSpan.FromMinutes(_config.CacheDuration)) ?? [];

    protected async Task<T?> GetCachedAsync<T>(string key, Func<Task<T?>> factory)
        => await _cache.GetCacheItemAsync<T>(key, factory, TimeSpan.FromMinutes(_config.CacheDuration));
}
```

Cache strategy: **absolute expiry** = `TimeSpan.FromMinutes(config.CacheDuration)`. `GetCacheItemAsync<T>` is the async extension method from `Umbraco.Extensions`. New shared methods go here.

## Blob Service

`IBlobService` / `BlobService` downloads Speedware blobs to `wwwroot/{RootUploadFolder}/{subfolder}/{filename}` and returns the virtual web path. **Disk presence is the persistent cache** — if the file already exists it is not re-fetched.

```csharp
public interface IBlobService
{
    Task<string> EnsureDownloadedAsync(Blob blob, CancellationToken cancellationToken = default);
}
```

`BlobService` inherits `SpeedwareServiceBase` (gains `_client` and `_config`), injects `IWebHostEnvironment` for `WebRootPath`, and uses `FilesAndPath.FileTypeName(blob.MimeType)` to determine the subfolder (`"Images"`, `"Files"`, `"Audio"`, `"Video"`).

`FilesAndPath` in `Imade.Speedware.Api/Core/FilesAndPath.cs` was changed from `internal` to `public` to make this possible.

## Service Interfaces

All methods accept `CancellationToken cancellationToken = default`.

**ITeachersService**
```csharp
Task<List<Teacher>> GetAllAsync(CancellationToken cancellationToken);
Task<Teacher> GetByIdAsync(int id, CancellationToken cancellationToken);
Task<List<Teacher>> GetByDepartmentAsync(int departmentId, CancellationToken cancellationToken);
Task<List<Course>> GetCoursesByTeacherAsync(int teacherId, CancellationToken cancellationToken);
Task<string?> EnsureBlobAsync(Teacher teacher, CancellationToken cancellationToken);
```

`EnsureBlobAsync` returns `null` if the teacher has no blob, otherwise delegates to `IBlobService.EnsureDownloadedAsync` and returns the virtual path. `TeachersService` injects `IBlobService` alongside its other dependencies.

**ISchoolsService**
```csharp
Task<List<School>> GetAllAsync(CancellationToken cancellationToken);
Task<School> GetByIdAsync(int id, CancellationToken cancellationToken);
Task<List<SchoolContact>> GetContactsBySchoolAsync(int schoolId, CancellationToken cancellationToken);
```

**IDepartmentsService**
```csharp
Task<List<Department>> GetAllAsync(CancellationToken cancellationToken);
Task<Department> GetByIdAsync(int id, CancellationToken cancellationToken);
```

**IRoomsService**
```csharp
Task<List<Room>> GetAllAsync(CancellationToken cancellationToken);         // → rooms
Task<Room> GetByIdAsync(int id, CancellationToken cancellationToken);
Task<List<Room>> GetAllUnpagedAsync(CancellationToken cancellationToken);  // → rooms/all
```

## Implementation Pattern

Each service inherits `SpeedwareServiceBase`, passes the three shared dependencies via `base(...)`, and adds only its own `ILogger<T>` (plus `IBlobService` where blob methods are needed).

Single-entity methods use `?? throw new SpeedwareApiException(...)` on the result of `GetCachedAsync<T>`. All exceptions are logged with structured parameters before rethrowing.

### Cache Key Scheme

| Service | Keys |
|---|---|
| Teachers | `speedware:teachers:all`, `speedware:teachers:{id}`, `speedware:teachers:dept:{id}`, `speedware:teachers:{id}:courses` |
| Schools | `speedware:schools:all`, `speedware:schools:{id}`, `speedware:schools:{id}:contacts` |
| Departments | `speedware:departments:all`, `speedware:departments:{id}` |
| Rooms | `speedware:rooms:all`, `speedware:rooms:{id}`, `speedware:rooms:all:unpaged` |

## Composer

```csharp
public class SpeedwareServicesComposer : IComposer
{
    public void Compose(IUmbracoBuilder builder)
    {
        builder.Services.AddSpeedwareApiClient(builder.Config);  // first registration in project

        builder.Services.AddScoped<ITeachersService, TeachersService>();
        builder.Services.AddScoped<ISchoolsService, SchoolsService>();
        builder.Services.AddScoped<IDepartmentsService, DepartmentsService>();
        builder.Services.AddScoped<IRoomsService, RoomsService>();
        builder.Services.AddScoped<IBlobService, BlobService>();
    }
}
```

Services are registered as `Scoped` (per HTTP request). `AppCaches` is a singleton registered by Umbraco — no explicit registration needed.

## Key References

- `ISpeedwareClient` — `Imade.Speedware.Api/Interfaces/ISpeedwareClient.cs`
- `ApiEndpoint` enum — `Imade.Speedware.Api/Core/ApiEndpoint.cs`
- `SpeedwareConfig` / `SpeedwareApiKey` — `Imade.Speedware.Api/Core/SpeedwareConfig.cs`, `SpeedwareApiKey.cs`
- `FilesAndPath` — `Imade.Speedware.Api/Core/FilesAndPath.cs`
- `AddSpeedwareApiClient` — `Imade.Speedware.Api/Extensions/ServiceCollectionExtensions.cs`
- `AppCaches` / `IAppPolicyCache` / `GetCacheItemAsync<T>` — `Umbraco.Cms.Core.Cache` + `Umbraco.Extensions`
- Model types: `Teacher`, `Course`, `School`, `SchoolContact`, `Department`, `Room`, `Blob` — `Imade.Speedware.Api/Models/`

# Code Review Recommendations — Imade.Speedware.Api

## Priority: Critical (Fixed)

### Hardcoded API Key
- **File**: `Core/SpeedwareConfig.cs`
- **Issue**: API key was hardcoded as a default property value, exposing secrets in source control and compiled binaries.
- **Fix applied**: Removed default value. `ApiKey` now defaults to `string.Empty` and must be supplied via configuration (e.g. `appsettings.json` or environment variables under the `speedware` section). Constructor throws `InvalidOperationException` if not set.

### Silent HTTP Failures
- **File**: `SpeedwareClient.cs`
- **Issue**: All HTTP methods returned `default` (null) on failure with no logging. Callers could not distinguish between "no data" and "request failed". Several `EnsureSuccessStatusCode()` calls were commented out.
- **Fix applied**: All methods now throw `SpeedwareApiException` on HTTP or deserialization failure. Added `CancellationToken` support across all methods. Removed redundant `if (response.IsSuccessStatusCode)` checks after `EnsureSuccessStatusCode()`.

---

## Priority: High (Fixed)

### No CancellationToken Support
- **File**: `SpeedwareClient.cs`
- **Issue**: All async methods lacked a `CancellationToken` parameter, making it impossible to cancel in-flight requests.
- **Fix applied**: `CancellationToken cancellationToken = default` added to all async method signatures and passed to all underlying `HttpClient` calls. *(Included in critical fix.)*

### Empty ISpeedwareClient Interface
- **File**: `Interfaces/ISpeedwareClient.cs`
- **Issue**: The interface was completely empty. `SpeedwareClient` claimed to implement it, but no method signatures were declared, making it useless for DI and mocking.
- **Fix applied**: Populated with the full method signatures from `SpeedwareClient`, including all overloads and `CancellationToken` parameters.

### HttpClient Mutated in Constructor
- **File**: `SpeedwareClient.cs`
- **Issue**: `BaseAddress`, `DefaultRequestHeaders`, and `Timeout` were set directly on the injected `HttpClient` instance, which breaks when the instance is reused across scopes.
- **Fix applied**: Configuration moved to `Extensions/ServiceCollectionExtensions.cs`. The `AddSpeedwareApiClient()` extension method configures the typed `HttpClient` via `IHttpClientFactory`. The constructor no longer mutates the client.

### Missing Exception Handling for TaskCanceledException
- **File**: `SpeedwareClient.cs`
- **Issue**: `TaskCanceledException` (timeouts) was not caught and would surface with no context.
- **Fix applied**: All methods now catch `TaskCanceledException when (!cancellationToken.IsCancellationRequested)` to distinguish timeouts from deliberate cancellations and wrap them in `SpeedwareApiException`.

---

## Priority: Medium (Fixed)

### No Logging
- **File**: `SpeedwareClient.cs`
- **Issue**: No `ILogger` was used anywhere. Failures were invisible.
- **Fix applied**: `ILogger<SpeedwareClient>` injected. Every catch block logs the error with structured properties (URI, HTTP status code) before re-throwing.

### HttpClientFactoryService is a Pointless Wrapper
- **File**: `HttpClientFactoryService.cs`
- **Issue**: This class injects `IHttpClientFactory` but never uses it, only delegating calls to `SpeedwareClient` with no added value.
- **Status**: Kept intentionally — may be consumed by a separate project not yet in this repository.

### Missing Null Guards on Model Computed Properties
- **Files**: `Models/News.cs`
- **Issue**: Computed properties (`Images`, `Files`, `Audio`, `Video`) called `.Where()` directly on `Blobs` without a null check, throwing `NullReferenceException` if `Blobs` is null.
- **Fix applied**: All four properties now use `(Blobs ?? []).Where(...)`.

### Duplicate GetHashCode Logic
- **Files**: `Filters/BookingLimiter.cs`, `Filters/PlayBookingRequest.cs`
- **Issue**: Identical FNV-1a hash implementation duplicated across both classes.
- **Fix applied**: Extracted to `Core/HashHelper.cs` with `HashCollection`, `HashValue<T>`, and `HashString` methods. Both filter classes now delegate to it.

### No DI Registration Extension Method
- **Issue**: No `AddSpeedwareApiClient()` extension method existed. Consumers had to wire up dependencies manually.
- **Fix applied**: `Extensions/ServiceCollectionExtensions.cs` added with `AddSpeedwareApiClient(IConfiguration)` that registers the typed `HttpClient`, configures headers/timeout, and binds `SpeedwareConfig` from the `speedware` config section.

### Missing NuGet Package References
- **File**: `Imade.Speedware.Api.csproj`
- **Issue**: `IOptions<SpeedwareConfig>` and `ILogger` were used but only `Microsoft.Extensions.Http` was declared.
- **Fix applied**: Added explicit references to `Microsoft.Extensions.Options.ConfigurationExtensions` and `Microsoft.Extensions.Logging.Abstractions`.

---

## Priority: Low (Fixed)

### Typo in Property Name
- **Files**: `Filters/ListLimiter.cs`, `Filters/NewsLimiter.cs`, `Filters/SchoolClassGradeLimiter.cs`, `Filters/SeasonLimiter.cs`
- **Issue**: Property named `GetFormattetAndMappedSortString` — "Formattet" should be "Formatted".
- **Fix applied**: Renamed to `GetFormattedAndMappedSortString` across all four files.

### Commented-Out BinaryFormatter Code
- **File**: `Core/ObjectCloner.cs`
- **Issue**: Dead code referencing the deprecated `BinaryFormatter` was commented out but still present, along with several unused `using` directives.
- **Fix applied**: Removed all commented-out code and unused imports. File reduced from 47 lines to 13.

### Unnecessary ToArray() Inside string.Join()
- **Files**: `Filters/BookingLimiter.cs`, `Filters/PlayBookingRequest.cs`
- **Issue**: `string.Join(",", collection.Select(...).ToArray())` — `ToArray()` is redundant.
- **Fix applied**: Eliminated as part of the `HashHelper` refactor — filter `GetHashCode` implementations no longer call `string.Join` directly.

### Mixed Indentation
- **File**: `SpeedwareClient.cs` and others
- **Issue**: Files mixed tabs and spaces across method blocks.
- **Fix applied**: `.editorconfig` added at the solution root enforcing 4-space indentation, CRLF line endings, and sorted `using` directives for all C# files.

### Inconsistent Filter Defaults and No Range Validation
- **Files**: Various filter classes
- **Issue**: No validation enforced the documented `Take`/`Skip` ranges.
- **Fix applied**: `[Range]` attributes added to `Take` and `Skip` in all filter classes, matching limits documented in the XML comments (0–500 for booking filters, 0–200 for list/news/school filters).

### Unused Imports
- **Files**: `SpeedwareClient.cs` and filter classes
- **Issue**: Several `using` directives were unused.
- **Fix applied**: Cleaned up in `ObjectCloner.cs`, filter classes, and `SpeedwareClient.cs` as part of the respective fixes. `.editorconfig` now enforces `dotnet_sort_system_directives_first` going forward.

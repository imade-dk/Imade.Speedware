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

## Priority: High

### No CancellationToken Support
- **File**: `SpeedwareClient.cs`
- **Issue**: All async methods lacked a `CancellationToken` parameter, making it impossible to cancel in-flight requests.
- **Fix**: Add `CancellationToken cancellationToken = default` to all async method signatures and pass to all underlying `HttpClient` calls. *(Included in critical fix above.)*

### Empty ISpeedwareClient Interface
- **File**: `Interfaces/ISpeedwareClient.cs`
- **Issue**: The interface is completely empty. `SpeedwareClient` claims to implement it, but no method signatures are declared, making it useless for DI and mocking.
- **Fix**: Populate with the actual method signatures from `SpeedwareClient`.

### HttpClient Mutated in Constructor
- **File**: `SpeedwareClient.cs`
- **Issue**: `BaseAddress`, `DefaultRequestHeaders`, and `Timeout` are set directly on the injected `HttpClient` instance. This pattern breaks when the same `HttpClient` instance is reused across multiple scopes.
- **Fix**: Configure a named or typed `HttpClient` via `IHttpClientFactory` in the DI registration instead of mutating the injected instance in the constructor.

### Missing Exception Handling for TaskCanceledException
- **File**: `SpeedwareClient.cs`
- **Issue**: `TaskCanceledException` (timeouts) is not caught and will surface as an unhandled exception with no context.
- **Fix**: Add a `catch (TaskCanceledException ex)` block that throws a `SpeedwareApiException` with a descriptive timeout message.

---

## Priority: Medium

### No Logging
- **File**: `SpeedwareClient.cs`
- **Issue**: No `ILogger` is used anywhere. Failures, durations, and retry attempts are invisible.
- **Fix**: Inject `ILogger<SpeedwareClient>` and log request start/end with endpoint and duration, all HTTP errors with status code and response body, and deserialization failures.

### HttpClientFactoryService is a Pointless Wrapper
- **File**: `HttpClientFactoryService.cs`
- **Issue**: This class injects `IHttpClientFactory` but never uses it. It only delegates all calls to `SpeedwareClient` with no added value.
- **Fix**: Delete the class and have consumers depend on `ISpeedwareClient` directly. Alternatively, move retry logic, caching, or circuit-breaking here to give it a real purpose.

### Missing Null Guards on Model Computed Properties
- **Files**: `Models/News.cs`, `Models/Booking.cs`
- **Issue**: Computed properties (e.g. `Images`, `Files`, `Audio`, `Video` in `News.cs`) call `.Where()` directly on `Blobs` without a null check. Will throw `NullReferenceException` if `Blobs` is null.
- **Fix**: Add null coalescing: `(Blobs ?? []).Where(...)`.

### Duplicate GetHashCode Logic
- **Files**: `Filters/BookingLimiter.cs`, `Filters/PlayBookingRequest.cs`
- **Issue**: Identical FNV-1a hash implementation duplicated across both classes. A bug fix must be applied in multiple places.
- **Fix**: Extract to a shared utility or use the built-in `HashCode.Combine()` available since .NET 6.

### No DI Registration Extension Method
- **Issue**: No `AddSpeedwareApiClient()` extension method exists. Consumers must wire up all dependencies manually with no guidance.
- **Fix**: Add a single extension method:
  ```csharp
  public static IServiceCollection AddSpeedwareApiClient(this IServiceCollection services, IConfiguration config)
  {
      services.Configure<SpeedwareConfig>(config.GetSection(SpeedwareConfig.SpeedwareSection));
      services.AddHttpClient<ISpeedwareClient, SpeedwareClient>();
      return services;
  }
  ```

### Missing NuGet Package References
- **File**: `Imade.Speedware.Api.csproj`
- **Issue**: `IOptions<SpeedwareConfig>` is used from `Microsoft.Extensions.Options`, but only `Microsoft.Extensions.Http` is declared as a dependency.
- **Fix**: Add explicit references:
  ```xml
  <PackageReference Include="Microsoft.Extensions.Options.ConfigurationExtensions" Version="10.0.x" />
  <PackageReference Include="Microsoft.Extensions.Logging.Abstractions" Version="10.0.x" />
  ```

---

## Priority: Low

### Typo in Property Name
- **Files**: `Filters/ListLimiter.cs`, `Filters/NewsLimiter.cs`, `Filters/SchoolClassGradeLimiter.cs`
- **Issue**: Property is named `GetFormattetAndMappedSortString` — "Formattet" should be "Formatted".
- **Fix**: Rename to `GetFormattedAndMappedSortString`.

### Commented-Out BinaryFormatter Code
- **File**: `Core/ObjectCloner.cs`
- **Issue**: Dead code referencing the deprecated and removed `BinaryFormatter` is commented out but still present.
- **Fix**: Delete the commented-out block entirely.

### Unnecessary ToArray() Inside string.Join()
- **Files**: `Filters/BookingLimiter.cs`, `Filters/PlayBookingRequest.cs`
- **Issue**: `string.Join(",", collection.Select(...).ToArray())` — `ToArray()` is redundant; `string.Join` accepts `IEnumerable<T>` directly.
- **Fix**: Remove `.ToArray()`.

### Mixed Indentation
- **File**: `SpeedwareClient.cs`
- **Issue**: File mixes tabs and spaces across method blocks.
- **Fix**: Add an `.editorconfig` file at the solution root to enforce consistent indentation across the project.

### Inconsistent Filter Defaults and No Range Validation
- **Files**: Various filter classes
- **Issue**: Some filters default `Take=10`, others don't set a default. The API supports 0–500 but no validation enforces this.
- **Fix**: Standardise defaults and add `[Range(0, 500)]` data annotations where applicable.

### Unused Imports
- **Files**: `SpeedwareClient.cs` and others
- **Issue**: Several `using` directives are unused (e.g. `System.Linq` in `SpeedwareClient.cs`).
- **Fix**: Run IDE code cleanup or enable the `IDE0005` analyser rule to flag unused usings as errors.

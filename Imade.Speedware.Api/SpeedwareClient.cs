using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Imade.Speedadmin.Api.Core;
using Imade.Speedadmin.Api.Interfaces;
using Microsoft.Extensions.Options;

namespace Imade.Speedadmin.Api
{
    public class SpeedwareClient : ISpeedwareClient
    {
        private readonly HttpClient _client;
        private readonly JsonSerializerOptions _options;
        private readonly SpeedwareConfig _speedwareConfig;

        public SpeedwareClient(HttpClient client, IOptions<SpeedwareConfig> config)
        {
            if (config?.Value == null) throw new ArgumentNullException(nameof(config));

            _speedwareConfig = config.Value;

            if (string.IsNullOrWhiteSpace(_speedwareConfig.ApiKey))
                throw new InvalidOperationException("Speedware ApiKey is not configured.");
            if (string.IsNullOrWhiteSpace(_speedwareConfig.BaseUrl))
                throw new InvalidOperationException("Speedware BaseUrl is not configured.");

            _client = client;
            _client.BaseAddress = new Uri(_speedwareConfig.BaseUrl);
            _client.Timeout = TimeSpan.FromMinutes(10);
            _client.DefaultRequestHeaders.Clear();
            _client.DefaultRequestHeaders.Add("Authorization", _speedwareConfig.ApiKey);
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            _options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        }

        #region Gets

        public async Task<List<T>> GetListAsync<T>(ApiEndpoint endpoint, CancellationToken cancellationToken = default)
        {
            try
            {
                using var response = await _client.GetAsync(endpoint.ToDescriptionString(), cancellationToken);
                response.EnsureSuccessStatusCode();
                var stream = await response.Content.ReadAsStreamAsync(cancellationToken);
                return await JsonSerializer.DeserializeAsync<List<T>>(stream, _options, cancellationToken)
                    ?? throw new SpeedwareApiException($"Deserialization returned null for endpoint {endpoint}.");
            }
            catch (HttpRequestException ex)
            {
                throw new SpeedwareApiException($"HTTP request failed for endpoint {endpoint}.", ex);
            }
            catch (JsonException ex)
            {
                throw new SpeedwareApiException($"Failed to deserialize response for endpoint {endpoint}.", ex);
            }
        }

        public async Task<List<T>> GetListAsync<T>(ApiEndpoint endpoint, string id, CancellationToken cancellationToken = default)
        {
            var uri = endpoint.ToDescriptionString().Replace("{id}", id);
            try
            {
                using var response = await _client.GetAsync(uri, cancellationToken);
                response.EnsureSuccessStatusCode();
                var stream = await response.Content.ReadAsStreamAsync(cancellationToken);
                return await JsonSerializer.DeserializeAsync<List<T>>(stream, _options, cancellationToken)
                    ?? throw new SpeedwareApiException($"Deserialization returned null for {uri}.");
            }
            catch (HttpRequestException ex)
            {
                throw new SpeedwareApiException($"HTTP request failed for {uri}.", ex);
            }
            catch (JsonException ex)
            {
                throw new SpeedwareApiException($"Failed to deserialize response for {uri}.", ex);
            }
        }

        public async Task<List<T>> GetListAsync<T>(ApiEndpoint endpoint, int id, CancellationToken cancellationToken = default)
        {
            return await GetListAsync<T>(endpoint, id.ToString(), cancellationToken);
        }

        public async Task<T> GetAsync<T>(ApiEndpoint endpoint, string id, CancellationToken cancellationToken = default)
        {
            var uri = endpoint.ToDescriptionString().Replace("{id}", id);
            try
            {
                using var response = await _client.GetAsync(uri, cancellationToken);
                response.EnsureSuccessStatusCode();
                var stream = await response.Content.ReadAsStreamAsync(cancellationToken);
                return await JsonSerializer.DeserializeAsync<T>(stream, _options, cancellationToken)
                    ?? throw new SpeedwareApiException($"Deserialization returned null for {uri}.");
            }
            catch (HttpRequestException ex)
            {
                throw new SpeedwareApiException($"HTTP request failed for {uri}.", ex);
            }
            catch (JsonException ex)
            {
                throw new SpeedwareApiException($"Failed to deserialize response for {uri}.", ex);
            }
        }

        public async Task<T> GetAsync<T>(ApiEndpoint endpoint, int id, CancellationToken cancellationToken = default)
        {
            return await GetAsync<T>(endpoint, id.ToString(), cancellationToken);
        }

        #endregion

        #region Posts

        public async Task<Models.PagedResult<T>> PostAsync<T, L>(ApiEndpoint endpoint, ILimiter limiter, CancellationToken cancellationToken = default)
        {
            var content = new StringContent(JsonSerializer.Serialize((L)limiter, _options), Encoding.UTF8, "application/json");
            try
            {
                using var response = await _client.PostAsync(endpoint.ToDescriptionString(), content, cancellationToken);
                response.EnsureSuccessStatusCode();
                var stream = await response.Content.ReadAsStreamAsync(cancellationToken);
                return await JsonSerializer.DeserializeAsync<Models.PagedResult<T>>(stream, _options, cancellationToken)
                    ?? throw new SpeedwareApiException($"Deserialization returned null for endpoint {endpoint}.");
            }
            catch (HttpRequestException ex)
            {
                throw new SpeedwareApiException($"HTTP request failed for endpoint {endpoint}.", ex);
            }
            catch (JsonException ex)
            {
                throw new SpeedwareApiException($"Failed to deserialize response for endpoint {endpoint}.", ex);
            }
        }

        public async Task<List<T>> PostAsyncList<T, L>(ApiEndpoint endpoint, ILimiter limiter, CancellationToken cancellationToken = default)
        {
            var content = new StringContent(JsonSerializer.Serialize((L)limiter, _options), Encoding.UTF8, "application/json");
            try
            {
                using var response = await _client.PostAsync(endpoint.ToDescriptionString(), content, cancellationToken);
                response.EnsureSuccessStatusCode();
                var stream = await response.Content.ReadAsStreamAsync(cancellationToken);
                return await JsonSerializer.DeserializeAsync<List<T>>(stream, _options, cancellationToken)
                    ?? throw new SpeedwareApiException($"Deserialization returned null for endpoint {endpoint}.");
            }
            catch (HttpRequestException ex)
            {
                throw new SpeedwareApiException($"HTTP request failed for endpoint {endpoint}.", ex);
            }
            catch (JsonException ex)
            {
                throw new SpeedwareApiException($"Failed to deserialize response for endpoint {endpoint}.", ex);
            }
        }

        #endregion

        #region Blob

        public async Task<byte[]> GetBlobBytesAsync(ApiEndpoint endpoint, string id, CancellationToken cancellationToken = default)
        {
            var uri = endpoint.ToDescriptionString().Replace("{id}", id);
            try
            {
                using var response = await _client.GetAsync(uri, cancellationToken);
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadAsByteArrayAsync(cancellationToken);
            }
            catch (HttpRequestException ex)
            {
                throw new SpeedwareApiException($"HTTP request failed for blob {uri}.", ex);
            }
        }

        #endregion
    }
}

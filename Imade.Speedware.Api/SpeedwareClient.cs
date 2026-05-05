using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Imade.Speedadmin.Api.Core;
using Imade.Speedadmin.Api.Interfaces;
using Imade.Speedadmin.Api.Models;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Imade.Speedadmin.Api
{
    public class SpeedwareClient : ISpeedwareClient
    {
        private readonly HttpClient _client;
        private readonly JsonSerializerOptions _options;
        private readonly ILogger<SpeedwareClient> _logger;

        public SpeedwareClient(HttpClient client, IOptions<SpeedwareConfig> config, ILogger<SpeedwareClient> logger)
        {
            if (config?.Value == null) throw new ArgumentNullException(nameof(config));

            _client = client;
            _logger = logger;
            _options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        }

        #region Gets

        public async Task<List<T>> GetListAsync<T>(ApiEndpoint endpoint, CancellationToken cancellationToken = default)
        {
            var uri = endpoint.ToDescriptionString();
            try
            {
                using var response = await _client.GetAsync(uri, cancellationToken);
                response.EnsureSuccessStatusCode();
                var stream = await response.Content.ReadAsStreamAsync(cancellationToken);
                return await JsonSerializer.DeserializeAsync<List<T>>(stream, _options, cancellationToken)
                    ?? throw new SpeedwareApiException($"Deserialization returned null for {uri}.");
            }
            catch (TaskCanceledException ex) when (!cancellationToken.IsCancellationRequested)
            {
                _logger.LogError(ex, "Request timed out for {Uri}", uri);
                throw new SpeedwareApiException($"Request timed out for {uri}.", ex);
            }
            catch (HttpRequestException ex)
            {
                _logger.LogError(ex, "HTTP request failed for {Uri} — {StatusCode}", uri, ex.StatusCode);
                throw new SpeedwareApiException($"HTTP request failed for {uri}.", ex);
            }
            catch (JsonException ex)
            {
                _logger.LogError(ex, "Failed to deserialize response for {Uri}", uri);
                throw new SpeedwareApiException($"Failed to deserialize response for {uri}.", ex);
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
            catch (TaskCanceledException ex) when (!cancellationToken.IsCancellationRequested)
            {
                _logger.LogError(ex, "Request timed out for {Uri}", uri);
                throw new SpeedwareApiException($"Request timed out for {uri}.", ex);
            }
            catch (HttpRequestException ex)
            {
                _logger.LogError(ex, "HTTP request failed for {Uri} — {StatusCode}", uri, ex.StatusCode);
                throw new SpeedwareApiException($"HTTP request failed for {uri}.", ex);
            }
            catch (JsonException ex)
            {
                _logger.LogError(ex, "Failed to deserialize response for {Uri}", uri);
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
            catch (TaskCanceledException ex) when (!cancellationToken.IsCancellationRequested)
            {
                _logger.LogError(ex, "Request timed out for {Uri}", uri);
                throw new SpeedwareApiException($"Request timed out for {uri}.", ex);
            }
            catch (HttpRequestException ex)
            {
                _logger.LogError(ex, "HTTP request failed for {Uri} — {StatusCode}", uri, ex.StatusCode);
                throw new SpeedwareApiException($"HTTP request failed for {uri}.", ex);
            }
            catch (JsonException ex)
            {
                _logger.LogError(ex, "Failed to deserialize response for {Uri}", uri);
                throw new SpeedwareApiException($"Failed to deserialize response for {uri}.", ex);
            }
        }

        public async Task<T> GetAsync<T>(ApiEndpoint endpoint, int id, CancellationToken cancellationToken = default)
        {
            return await GetAsync<T>(endpoint, id.ToString(), cancellationToken);
        }

        #endregion

        #region Posts

        public async Task<PagedResult<T>> PostAsync<T, L>(ApiEndpoint endpoint, ILimiter limiter, CancellationToken cancellationToken = default)
        {
            var uri = endpoint.ToDescriptionString();
            var content = new StringContent(JsonSerializer.Serialize((L)limiter, _options), Encoding.UTF8, "application/json");
            try
            {
                using var response = await _client.PostAsync(uri, content, cancellationToken);
                response.EnsureSuccessStatusCode();
                var stream = await response.Content.ReadAsStreamAsync(cancellationToken);
                return await JsonSerializer.DeserializeAsync<PagedResult<T>>(stream, _options, cancellationToken)
                    ?? throw new SpeedwareApiException($"Deserialization returned null for {uri}.");
            }
            catch (TaskCanceledException ex) when (!cancellationToken.IsCancellationRequested)
            {
                _logger.LogError(ex, "Request timed out for {Uri}", uri);
                throw new SpeedwareApiException($"Request timed out for {uri}.", ex);
            }
            catch (HttpRequestException ex)
            {
                _logger.LogError(ex, "HTTP request failed for {Uri} — {StatusCode}", uri, ex.StatusCode);
                throw new SpeedwareApiException($"HTTP request failed for {uri}.", ex);
            }
            catch (JsonException ex)
            {
                _logger.LogError(ex, "Failed to deserialize response for {Uri}", uri);
                throw new SpeedwareApiException($"Failed to deserialize response for {uri}.", ex);
            }
        }

        public async Task<List<T>> PostAsyncList<T, L>(ApiEndpoint endpoint, ILimiter limiter, CancellationToken cancellationToken = default)
        {
            var uri = endpoint.ToDescriptionString();
            var content = new StringContent(JsonSerializer.Serialize((L)limiter, _options), Encoding.UTF8, "application/json");
            try
            {
                using var response = await _client.PostAsync(uri, content, cancellationToken);
                response.EnsureSuccessStatusCode();
                var stream = await response.Content.ReadAsStreamAsync(cancellationToken);
                return await JsonSerializer.DeserializeAsync<List<T>>(stream, _options, cancellationToken)
                    ?? throw new SpeedwareApiException($"Deserialization returned null for {uri}.");
            }
            catch (TaskCanceledException ex) when (!cancellationToken.IsCancellationRequested)
            {
                _logger.LogError(ex, "Request timed out for {Uri}", uri);
                throw new SpeedwareApiException($"Request timed out for {uri}.", ex);
            }
            catch (HttpRequestException ex)
            {
                _logger.LogError(ex, "HTTP request failed for {Uri} — {StatusCode}", uri, ex.StatusCode);
                throw new SpeedwareApiException($"HTTP request failed for {uri}.", ex);
            }
            catch (JsonException ex)
            {
                _logger.LogError(ex, "Failed to deserialize response for {Uri}", uri);
                throw new SpeedwareApiException($"Failed to deserialize response for {uri}.", ex);
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
            catch (TaskCanceledException ex) when (!cancellationToken.IsCancellationRequested)
            {
                _logger.LogError(ex, "Request timed out for blob {Uri}", uri);
                throw new SpeedwareApiException($"Request timed out for blob {uri}.", ex);
            }
            catch (HttpRequestException ex)
            {
                _logger.LogError(ex, "HTTP request failed for blob {Uri} — {StatusCode}", uri, ex.StatusCode);
                throw new SpeedwareApiException($"HTTP request failed for blob {uri}.", ex);
            }
        }

        #endregion
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
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
            _speedwareConfig = config.Value;

            _client = client;
            _client.BaseAddress = new Uri(_speedwareConfig.BaseUrl);
            _client.Timeout = new TimeSpan(0, 10, 0);
            _client.DefaultRequestHeaders.Clear();
            _client.DefaultRequestHeaders.Add("Authorization", _speedwareConfig.ApiKey);
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            _options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        }
        #region Gets

        public async Task<List<T>> GetListAsync<T>(ApiEndpoint endpoint)
        {

            using var response = await _client.GetAsync(endpoint.ToDescriptionString());
            response.EnsureSuccessStatusCode();
            if (response.IsSuccessStatusCode)
            {
                var stream = await response.Content.ReadAsStreamAsync();
                var output = await JsonSerializer.DeserializeAsync<List<T>>(stream, _options);
                return output;
            }
            return default;

        }

        public async Task<List<T>> GetListAsync<T>(ApiEndpoint endpoint, string id)
        {
            var uri = endpoint.ToDescriptionString().Replace("{id}", id);
            using var response = await _client.GetAsync(uri);
            response.EnsureSuccessStatusCode();
            if (response.IsSuccessStatusCode)
            {
                var stream = await response.Content.ReadAsStreamAsync();
                var output = await JsonSerializer.DeserializeAsync<List<T>>(stream, _options);
                return output;
            }
            return default;

        }
        public async Task<List<T>> GetListAsync<T>(ApiEndpoint endpoint, int id)
        {
            return await GetListAsync<T>(endpoint, id.ToString());
        }

        public async Task<T> GetAsync<T>(ApiEndpoint endpoint, string id)
        {
            var uri = endpoint.ToDescriptionString().Replace("{id}", id);

            using var response = await _client.GetAsync(uri);
            //response.EnsureSuccessStatusCode();
            if (response.IsSuccessStatusCode)
            {
                var stream = await response.Content.ReadAsStreamAsync();
                var output = await JsonSerializer.DeserializeAsync<T>(stream, _options);
                return output;
            }
            return default;
        }

        public async Task<T> GetAsync<T>(ApiEndpoint endpoint, int id)
        {
            return await GetAsync<T>(endpoint, id.ToString());
        }
        #endregion

        #region Posts
        public async Task<Models.PagedResult<T>> PostAsync<T, L>(ApiEndpoint endpoint, Interfaces.ILimiter limiter)
        {
            using var response = await _client.PostAsync(endpoint.ToDescriptionString(), new StringContent(JsonSerializer.Serialize((L)limiter, _options), Encoding.UTF8, "application/json"));
            //response.EnsureSuccessStatusCode();
            if (response.IsSuccessStatusCode)
            {
                var stream = await response.Content.ReadAsStreamAsync();
                var output = await JsonSerializer.DeserializeAsync<Models.PagedResult<T>>(stream, _options);
                return output;
            }
            return default;
        }
		public async Task<List<T>> PostAsyncList<T, L>(ApiEndpoint endpoint, Interfaces.ILimiter limiter)
		{
			using var response = await _client.PostAsync(endpoint.ToDescriptionString(), new StringContent(JsonSerializer.Serialize((L)limiter, _options), Encoding.UTF8, "application/json"));
			//response.EnsureSuccessStatusCode();
			if (response.IsSuccessStatusCode)
			{
				var stream = await response.Content.ReadAsStreamAsync();
				var output = await JsonSerializer.DeserializeAsync<List<T>>(stream, _options);
				return output;
			}
			return default;
		}
		#endregion

		#region Blob

		public async Task<byte[]> GetBlobBytesAsync(ApiEndpoint endpoint, string id)
        {
            var uri = endpoint.ToDescriptionString().Replace("{id}", id);
            using var response = await _client.GetAsync(uri);
            //response.EnsureSuccessStatusCode();
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsByteArrayAsync();
            }
            return default;
        }

        #endregion
    }
}

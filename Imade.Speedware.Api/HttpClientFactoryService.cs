using Imade.Speedware.Api.Core;
using Imade.Speedware.Api.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Imade.Speedware.Api
{
    public class HttpClientFactoryService : Interfaces.IHttpClientFactoryService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly JsonSerializerOptions _options;
        private readonly SpeedwareClient _speedwareClient;
        public HttpClientFactoryService(IHttpClientFactory httpClientFactory, SpeedwareClient speedwareClient)
        {
            _httpClientFactory = httpClientFactory;
            _speedwareClient = speedwareClient;
            _options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        }

        public async Task<T> GetAsync<T>(ApiEndpoint endpoint, string id) => await _speedwareClient.GetAsync<T>(endpoint, id);

        public async Task<T> GetAsync<T>(ApiEndpoint endpoint, int id) => await _speedwareClient.GetAsync<T>(endpoint, id);

        public async Task<List<T>> GetListAsync<T>(ApiEndpoint endpoint) => await _speedwareClient.GetListAsync<T>(endpoint);

        public async Task<Models.PagedResult<T>> PostAsync<T,L>(ApiEndpoint endpoint, Interfaces.ILimiter limiter) => await _speedwareClient.PostAsync<T,L>(endpoint, limiter);
    }
}

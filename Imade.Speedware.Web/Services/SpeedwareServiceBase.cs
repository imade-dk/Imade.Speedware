using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Imade.Speedware.Api.Core;
using Imade.Speedware.Api.Interfaces;
using Microsoft.Extensions.Options;
using Umbraco.Cms.Core.Cache;
using Umbraco.Extensions;

namespace Imade.Speedware.Web.Services
{
    public abstract class SpeedwareServiceBase
    {
        protected readonly ISpeedwareClient _client;
        private readonly IAppPolicyCache _cache;
        protected readonly SpeedwareConfig _config;

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
}

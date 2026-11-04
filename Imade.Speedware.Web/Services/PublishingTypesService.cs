using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Imade.Speedware.Api.Core;
using Imade.Speedware.Api.Interfaces;
using Imade.Speedware.Api.Models;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Umbraco.Cms.Core.Cache;

namespace Imade.Speedware.Web.Services
{
    public class PublishingTypesService : SpeedwareServiceBase, IPublishingTypesService
    {
        private readonly ILogger<PublishingTypesService> _logger;

        public PublishingTypesService(ISpeedwareClient client, AppCaches appCaches, IOptions<SpeedwareConfig> config, ILogger<PublishingTypesService> logger)
            : base(client, appCaches, config)
        {
            _logger = logger;
        }

        public async Task<List<PublishType>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            try
            {
                return await GetCachedListAsync("speedware:publishingtypes:all",
                    async () => await _client.GetListAsync<PublishType>(ApiEndpoint.PublishTypes, cancellationToken));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to get all publish types.");
                throw;
            }
        }

        public async Task<PublishType> GetByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            try
            {
                return await GetCachedAsync<PublishType>($"speedware:publishingtypes:{id}",
                    async () => await _client.GetAsync<PublishType>(ApiEndpoint.PublishTypeById, id, cancellationToken))
                    ?? throw new SpeedwareApiException($"Publish type {id} not found.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to get publish type {PublishTypeId}.", id);
                throw;
            }
        }
    }
}

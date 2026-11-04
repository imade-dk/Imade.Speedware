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
    public class OfferingBaseService : SpeedwareServiceBase, IOfferingBaseService
    {
        private readonly ILogger<OfferingBaseService> _logger;

        public OfferingBaseService(ISpeedwareClient client, AppCaches appCaches, IOptions<SpeedwareConfig> config, ILogger<OfferingBaseService> logger)
            : base(client, appCaches, config)
        {
            _logger = logger;
        }

        public async Task<List<OfferingBase>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            try
            {
                return await GetCachedListAsync("speedware:offeringbase:all",
                    async () => await _client.GetListAsync<OfferingBase>(ApiEndpoint.OfferingBase, cancellationToken));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to get all offering bases.");
                throw;
            }
        }

        public async Task<OfferingBase> GetByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            try
            {
                return await GetCachedAsync<OfferingBase>($"speedware:offeringbase:{id}",
                    async () => await _client.GetAsync<OfferingBase>(ApiEndpoint.OfferingBaseById, id, cancellationToken))
                    ?? throw new SpeedwareApiException($"Offering base {id} not found.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to get offering base {OfferingBaseId}.", id);
                throw;
            }
        }
    }
}

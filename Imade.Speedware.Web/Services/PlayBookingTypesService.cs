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
    public class PlayBookingTypesService : SpeedwareServiceBase, IPlayBookingTypesService
    {
        private readonly ILogger<PlayBookingTypesService> _logger;

        public PlayBookingTypesService(ISpeedwareClient client, AppCaches appCaches, IOptions<SpeedwareConfig> config, ILogger<PlayBookingTypesService> logger)
            : base(client, appCaches, config)
        {
            _logger = logger;
        }

        public async Task<List<PlayBookingType>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            try
            {
                return await GetCachedListAsync("speedware:playbookingtypes:all",
                    async () => await _client.GetListAsync<PlayBookingType>(ApiEndpoint.PlayBookingTypes, cancellationToken));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to get all play play booking types.");
                throw;
            }
        }

        public async Task<PlayBookingType> GetByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            try
            {
                return await GetCachedAsync<PlayBookingType>($"speedware:playbookingtypes:{id}",
                    async () => await _client.GetAsync<PlayBookingType>(ApiEndpoint.PlayBookingTypeById, id, cancellationToken))
                    ?? throw new SpeedwareApiException($"Play play booking type {id} not found.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to get play booking type {PlayBookingTypeId}.", id);
                throw;
            }
        }
    }
}

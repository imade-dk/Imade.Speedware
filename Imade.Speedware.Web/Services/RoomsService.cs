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
    public class RoomsService : SpeedwareServiceBase, IRoomsService
    {
        private readonly ILogger<RoomsService> _logger;

        public RoomsService(ISpeedwareClient client, AppCaches appCaches, IOptions<SpeedwareConfig> config, ILogger<RoomsService> logger)
            : base(client, appCaches, config)
        {
            _logger = logger;
        }

        public async Task<List<Room>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            try
            {
                return await GetCachedListAsync("speedware:rooms:all",
                    async () => await _client.GetListAsync<Room>(ApiEndpoint.Rooms, cancellationToken));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to get all rooms.");
                throw;
            }
        }

        public async Task<Room> GetByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            try
            {
                return await GetCachedAsync<Room>($"speedware:rooms:{id}",
                    async () => await _client.GetAsync<Room>(ApiEndpoint.RoomById, id, cancellationToken))
                    ?? throw new SpeedwareApiException($"Room {id} not found.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to get room {RoomId}.", id);
                throw;
            }
        }

        public async Task<List<Room>> GetAllUnpagedAsync(CancellationToken cancellationToken = default)
        {
            try
            {
                return await GetCachedListAsync("speedware:rooms:all:unpaged",
                    async () => await _client.GetListAsync<Room>(ApiEndpoint.RoomsAll, cancellationToken));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to get all rooms (unpaged).");
                throw;
            }
        }
    }
}

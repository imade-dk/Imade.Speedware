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
    public class BookingTypesService : SpeedwareServiceBase, IBookingTypesService
    {
        private readonly ILogger<BookingTypesService> _logger;

        public BookingTypesService(ISpeedwareClient client, AppCaches appCaches, IOptions<SpeedwareConfig> config, ILogger<BookingTypesService> logger)
            : base(client, appCaches, config)
        {
            _logger = logger;
        }

        public async Task<List<BookingType>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            try
            {
                return await GetCachedListAsync("speedware:bookingtypes:all",
                    async () => await _client.GetListAsync<BookingType>(ApiEndpoint.BookingTypes, cancellationToken));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to get all booking types.");
                throw;
            }
        }

        public async Task<BookingType> GetByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            try
            {
                return await GetCachedAsync<BookingType>($"speedware:bookingtypes:{id}",
                    async () => await _client.GetAsync<BookingType>(ApiEndpoint.BookingTypeById, id, cancellationToken))
                    ?? throw new SpeedwareApiException($"Booking type {id} not found.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to get booking type {BookingTypeId}.", id);
                throw;
            }
        }
    }
}

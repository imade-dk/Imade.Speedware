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
    public class SchoolsService : SpeedwareServiceBase, ISchoolsService
    {
        private readonly ILogger<SchoolsService> _logger;

        public SchoolsService(ISpeedwareClient client, AppCaches appCaches, IOptions<SpeedwareConfig> config, ILogger<SchoolsService> logger)
            : base(client, appCaches, config)
        {
            _logger = logger;
        }

        public async Task<List<School>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            try
            {
                return await GetCachedListAsync("speedware:schools:all",
                    async () => await _client.GetListAsync<School>(ApiEndpoint.Schools, cancellationToken));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to get all schools.");
                throw;
            }
        }

        public async Task<School> GetByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            try
            {
                return await GetCachedAsync<School>($"speedware:schools:{id}",
                    async () => await _client.GetAsync<School>(ApiEndpoint.SchoolById, id, cancellationToken))
                    ?? throw new SpeedwareApiException($"School {id} not found.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to get school {SchoolId}.", id);
                throw;
            }
        }

        public async Task<List<SchoolContact>> GetContactsBySchoolAsync(int schoolId, CancellationToken cancellationToken = default)
        {
            try
            {
                return await GetCachedListAsync($"speedware:schools:{schoolId}:contacts",
                    async () => await _client.GetListAsync<SchoolContact>(ApiEndpoint.SchoolContactsBySchoolId, schoolId, cancellationToken));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to get contacts for school {SchoolId}.", schoolId);
                throw;
            }
        }
    }
}

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
    public class CoursesService : SpeedwareServiceBase, ICoursesService
    {
        private readonly ILogger<CoursesService> _logger;

        public CoursesService(ISpeedwareClient client, AppCaches appCaches, IOptions<SpeedwareConfig> config, ILogger<CoursesService> logger)
            : base(client, appCaches, config)
        {
            _logger = logger;
        }

        public async Task<List<Course>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            try
            {
                return await GetCachedListAsync("speedware:courses:all",
                    async () => await _client.GetListAsync<Course>(ApiEndpoint.CoursesAll, cancellationToken));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to get all courses.");
                throw;
            }
        }

        public async Task<Course> GetByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            try
            {
                return await GetCachedAsync<Course>($"speedware:courses:{id}",
                    async () => await _client.GetAsync<Course>(ApiEndpoint.CourseById, id, cancellationToken))
                    ?? throw new SpeedwareApiException($"Course {id} not found.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to get course {CourseId}.", id);
                throw;
            }
        }
    }
}

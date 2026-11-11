using System;
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
    public class CoursesTreeService : SpeedwareServiceBase, ICoursesTreeService
    {
        private readonly ILogger<CoursesTreeService> _logger;

        public CoursesTreeService(ISpeedwareClient client, AppCaches appCaches, IOptions<SpeedwareConfig> config, ILogger<CoursesTreeService> logger)
            : base(client, appCaches, config)
        {
            _logger = logger;
        }

        public async Task<Tree> GetTreeAsync(CancellationToken cancellationToken = default)
        {
            try
            {
                return await GetCachedAsync<Tree>("speedware:coursestree:all",
                    async () => await _client.GetAsync<Tree>(ApiEndpoint.CoursesTree, 0, cancellationToken))
                    ?? throw new SpeedwareApiException("Courses tree not found.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to get courses tree.");
                throw;
            }
        }
    }
}

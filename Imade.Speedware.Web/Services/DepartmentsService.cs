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
    public class DepartmentsService : SpeedwareServiceBase, IDepartmentsService
    {
        private readonly ILogger<DepartmentsService> _logger;

        public DepartmentsService(ISpeedwareClient client, AppCaches appCaches, IOptions<SpeedwareConfig> config, ILogger<DepartmentsService> logger)
            : base(client, appCaches, config)
        {
            _logger = logger;
        }

        public async Task<List<Department>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            try
            {
                return await GetCachedListAsync("speedware:departments:all",
                    async () => await _client.GetListAsync<Department>(ApiEndpoint.Departments, cancellationToken));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to get all departments.");
                throw;
            }
        }

        public async Task<Department> GetByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            try
            {
                return await GetCachedAsync<Department>($"speedware:departments:{id}",
                    async () => await _client.GetAsync<Department>(ApiEndpoint.DepartmentById, id, cancellationToken))
                    ?? throw new SpeedwareApiException($"Department {id} not found.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to get department {DepartmentId}.", id);
                throw;
            }
        }
    }
}

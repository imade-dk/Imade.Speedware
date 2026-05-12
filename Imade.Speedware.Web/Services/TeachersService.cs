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
    public class TeachersService : SpeedwareServiceBase, ITeachersService
    {
        private readonly IBlobService _blobService;
        private readonly ILogger<TeachersService> _logger;

        public TeachersService(ISpeedwareClient client, AppCaches appCaches, IOptions<SpeedwareConfig> config, IBlobService blobService, ILogger<TeachersService> logger)
            : base(client, appCaches, config)
        {
            _blobService = blobService;
            _logger = logger;
        }

        public async Task<List<Teacher>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            try
            {
                return await GetCachedListAsync("speedware:teachers:all",
                    async () => await _client.GetListAsync<Teacher>(ApiEndpoint.Teachers, cancellationToken));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to get all teachers.");
                throw;
            }
        }

        public async Task<Teacher> GetByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            try
            {
                return await GetCachedAsync<Teacher>($"speedware:teachers:{id}",
                    async () => await _client.GetAsync<Teacher>(ApiEndpoint.TeacherById, id, cancellationToken))
                    ?? throw new SpeedwareApiException($"Teacher {id} not found.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to get teacher {TeacherId}.", id);
                throw;
            }
        }

        public async Task<List<Teacher>> GetByDepartmentAsync(int departmentId, CancellationToken cancellationToken = default)
        {
            try
            {
                return await GetCachedListAsync($"speedware:teachers:dept:{departmentId}",
                    async () => await _client.GetListAsync<Teacher>(ApiEndpoint.TeachersByDepartmentId, departmentId, cancellationToken));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to get teachers for department {DepartmentId}.", departmentId);
                throw;
            }
        }

        public async Task<List<Course>> GetCoursesByTeacherAsync(int teacherId, CancellationToken cancellationToken = default)
        {
            try
            {
                return await GetCachedListAsync($"speedware:teachers:{teacherId}:courses",
                    async () => await _client.GetListAsync<Course>(ApiEndpoint.TeachersCoursesByTeacherId, teacherId, cancellationToken));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to get courses for teacher {TeacherId}.", teacherId);
                throw;
            }
        }

        public async Task<string?> EnsureBlobAsync(Teacher teacher, CancellationToken cancellationToken = default)
        {
            if (teacher.Blob is null)
                return null;

            try
            {
                return await _blobService.EnsureDownloadedAsync(teacher.Blob, cancellationToken);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to ensure blob for teacher {TeacherId}.", teacher.TeacherId);
                throw;
            }
        }
    }
}

using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Imade.Speedware.Api.Models;

namespace Imade.Speedware.Web.Services
{
    public interface ITeachersService
    {
        Task<List<Teacher>> GetAllAsync(CancellationToken cancellationToken = default);
        Task<Teacher> GetByIdAsync(int id, CancellationToken cancellationToken = default);
        Task<List<Teacher>> GetByDepartmentAsync(int departmentId, CancellationToken cancellationToken = default);
        Task<List<Course>> GetCoursesByTeacherAsync(int teacherId, CancellationToken cancellationToken = default);
        Task<string?> EnsureBlobAsync(Teacher teacher, CancellationToken cancellationToken = default);
    }
}

using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Imade.Speedware.Api.Models;

namespace Imade.Speedware.Web.Services
{
    public interface ITeachersService
    {
        Task<IEnumerable<Teacher>> GetAllAsync(CancellationToken cancellationToken = default);
        Task<Teacher> GetByIdAsync(int id, CancellationToken cancellationToken = default);
        Task<IEnumerable<Teacher>> GetByDepartmentAsync(int departmentId, CancellationToken cancellationToken = default);
        Task<IEnumerable<Course>> GetCoursesByTeacherAsync(int teacherId, CancellationToken cancellationToken = default);
        Task<string?> EnsureBlobAsync(Teacher teacher, CancellationToken cancellationToken = default);
    }
}

using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Imade.Speedware.Api.Models;

namespace Imade.Speedware.Web.Services
{
    public interface ICoursesService
    {
        Task<List<Course>> GetAllAsync(CancellationToken cancellationToken = default);
        Task<Course> GetByIdAsync(int id, CancellationToken cancellationToken = default);
    }
}

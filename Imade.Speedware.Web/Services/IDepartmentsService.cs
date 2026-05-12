using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Imade.Speedware.Api.Models;

namespace Imade.Speedware.Web.Services
{
    public interface IDepartmentsService
    {
        Task<List<Department>> GetAllAsync(CancellationToken cancellationToken = default);
        Task<Department> GetByIdAsync(int id, CancellationToken cancellationToken = default);
    }
}

using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Imade.Speedware.Api.Models;

namespace Imade.Speedware.Web.Services
{
    public interface ISchoolsService
    {
        Task<List<School>> GetAllAsync(CancellationToken cancellationToken = default);
        Task<School> GetByIdAsync(int id, CancellationToken cancellationToken = default);
        Task<List<SchoolContact>> GetContactsBySchoolAsync(int schoolId, CancellationToken cancellationToken = default);
    }
}

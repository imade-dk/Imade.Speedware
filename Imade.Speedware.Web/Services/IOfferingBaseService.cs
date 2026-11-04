using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Imade.Speedware.Api.Models;

namespace Imade.Speedware.Web.Services
{
    public interface IOfferingBaseService
    {
        Task<List<OfferingBase>> GetAllAsync(CancellationToken cancellationToken = default);
        Task<OfferingBase> GetByIdAsync(int id, CancellationToken cancellationToken = default);
    }
}

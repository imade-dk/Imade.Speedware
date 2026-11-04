using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Imade.Speedware.Api.Models;

namespace Imade.Speedware.Web.Services
{
    public interface IPlayBookingTypesService
    {
        Task<List<PlayBookingType>> GetAllAsync(CancellationToken cancellationToken = default);
        Task<PlayBookingType> GetByIdAsync(int id, CancellationToken cancellationToken = default);
    }
}

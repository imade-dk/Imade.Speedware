using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Imade.Speedware.Api.Models;

namespace Imade.Speedware.Web.Services
{
    public interface IRoomsService
    {
        Task<List<Room>> GetAllAsync(CancellationToken cancellationToken = default);
        Task<Room> GetByIdAsync(int id, CancellationToken cancellationToken = default);
        Task<List<Room>> GetAllUnpagedAsync(CancellationToken cancellationToken = default);
    }
}

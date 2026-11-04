using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Imade.Speedware.Api.Models;

namespace Imade.Speedware.Web.Services
{
    public interface IBookingTypesService
    {
        Task<List<BookingType>> GetAllAsync(CancellationToken cancellationToken = default);
        Task<BookingType> GetByIdAsync(int id, CancellationToken cancellationToken = default);
    }
}

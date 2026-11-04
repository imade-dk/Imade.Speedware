using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Imade.Speedware.Api.Models;

namespace Imade.Speedware.Web.Services
{
    public interface IPublishingTypesService
    {
        Task<List<PublishType>> GetAllAsync(CancellationToken cancellationToken = default);
        Task<PublishType> GetByIdAsync(int id, CancellationToken cancellationToken = default);
    }
}

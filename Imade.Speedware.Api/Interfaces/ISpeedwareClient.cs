using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Imade.Speedware.Api.Core;
using Imade.Speedware.Api.Models;

namespace Imade.Speedware.Api.Interfaces
{
    public interface ISpeedwareClient
    {
        Task<List<T>> GetListAsync<T>(ApiEndpoint endpoint, CancellationToken cancellationToken = default);
        Task<List<T>> GetListAsync<T>(ApiEndpoint endpoint, string id, CancellationToken cancellationToken = default);
        Task<List<T>> GetListAsync<T>(ApiEndpoint endpoint, int id, CancellationToken cancellationToken = default);

        Task<T> GetAsync<T>(ApiEndpoint endpoint, string id, CancellationToken cancellationToken = default);
        Task<T> GetAsync<T>(ApiEndpoint endpoint, int id, CancellationToken cancellationToken = default);

        Task<PagedResult<T>> PostAsync<T, L>(ApiEndpoint endpoint, ILimiter limiter, CancellationToken cancellationToken = default);
        Task<List<T>> PostAsyncList<T, L>(ApiEndpoint endpoint, ILimiter limiter, CancellationToken cancellationToken = default);

        Task<byte[]> GetBlobBytesAsync(ApiEndpoint endpoint, string id, CancellationToken cancellationToken = default);
    }
}

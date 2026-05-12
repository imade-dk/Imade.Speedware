using System.Threading;
using System.Threading.Tasks;
using Imade.Speedware.Api.Models;

namespace Imade.Speedware.Web.Services
{
    public interface IBlobService
    {
        Task<string> EnsureDownloadedAsync(Blob blob, CancellationToken cancellationToken = default);
    }
}

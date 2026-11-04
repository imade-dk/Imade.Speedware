using System.Threading;
using System.Threading.Tasks;
using Imade.Speedware.Api.Models;
using Imade.Speedware.Web.Core;

namespace Imade.Speedware.Web.Services
{
    public interface IBlobService
    {
        Task<string> EnsureDownloadedAsync(Blob blob, FileFolder subFolder, int parentId, CancellationToken cancellationToken = default);
    }
}

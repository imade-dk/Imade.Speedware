using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Imade.Speedware.Api.Models;

namespace Imade.Speedware.Web.Services
{
    public interface ICoursesTreeService
    {
        /// <summary>
        /// Returns the nested course tree (top-level entries are the root nodes).
        /// </summary>
        Task<Tree> GetTreeAsync(CancellationToken cancellationToken = default);
    }
}

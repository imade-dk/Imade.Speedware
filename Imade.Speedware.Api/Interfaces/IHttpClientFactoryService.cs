using Imade.Speedadmin.Api.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imade.Speedadmin.Api.Interfaces
{
    public interface IHttpClientFactoryService
    {
        public Task<List<T>> GetListAsync<T>(ApiEndpoint endpoint);
        public Task<T> GetAsync<T>(ApiEndpoint endpoint, string id);

        public Task<T> GetAsync<T>(ApiEndpoint endpoint, int id);
        public Task<Models.PagedResult<T>> PostAsync<T,L>(ApiEndpoint endpoint, ILimiter limiter);
    }
}

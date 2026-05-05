using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imade.Speedware.Api.Interfaces
{
    public interface IPagedResult<T> where T : class
    {
        int TotalResults { get; set; }
        int RequestResults { get; set; }
        List<T> Results { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imade.Speedadmin.Api.Models
{
    public class PagedResult<T>
    {
        public int TotalResults { get; set; }
        public int RequestResults { get; set; }
        public List<T> Results { get; set; } = new List<T>();
    }
}

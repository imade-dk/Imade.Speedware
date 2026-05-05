using Imade.Speedadmin.Api.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imade.Speedadmin.Api.Filters
{
    public class SeasonLimiter : ILimiter
    {
        public int Take { get; set; } = 10;
        public int Skip { get; set; } = 0;
        public string Sort { get; set; }

        public List<string> GetFormattetAndMappedSortString { get; set; } = null;

    }
}

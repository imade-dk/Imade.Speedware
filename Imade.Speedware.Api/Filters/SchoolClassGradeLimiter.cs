using Imade.Speedadmin.Api.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imade.Speedadmin.Api.Filters
{
    public class SchoolClassGradeLimiter : ILimiter
    {
		/// <summary>
		/// Range: inclusive between 0 and 200
		/// </summary>
		public int Take { get; set; } = 10;
		/// <summary>
		/// Range: inclusive between 0 and 2147483647
		/// </summary>
		public int Skip { get; set; } = 0;
        public string Sort { get; set; }

        public List<string> GetFormattetAndMappedSortString { get; set; } = null;
    }
}

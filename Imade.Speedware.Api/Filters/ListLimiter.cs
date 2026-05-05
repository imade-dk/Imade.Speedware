using Imade.Speedware.Api.Interfaces;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Imade.Speedware.Api.Filters
{
    public class ListLimiter : ILimiter
    {
		/// <summary>
		/// Range: inclusive between 0 and 200
		/// </summary>
		[Range(0, 200)]
		public int Take { get; set; } = 10;
		/// <summary>
		/// Range: inclusive between 0 and 2147483647
		/// </summary>
		[Range(0, int.MaxValue)]
		public int Skip { get; set; } = 0;
        public string Sort { get; set; }

        public List<string> GetFormattedAndMappedSortString { get; set; } = null;
    }
}

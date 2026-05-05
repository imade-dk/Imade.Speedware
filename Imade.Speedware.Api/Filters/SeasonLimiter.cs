using Imade.Speedadmin.Api.Interfaces;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Imade.Speedadmin.Api.Filters
{
    public class SeasonLimiter : ILimiter
    {
        [Range(0, 200)]
        public int Take { get; set; } = 10;
        [Range(0, int.MaxValue)]
        public int Skip { get; set; } = 0;
        public string Sort { get; set; }

        public List<string> GetFormattedAndMappedSortString { get; set; } = null;

    }
}

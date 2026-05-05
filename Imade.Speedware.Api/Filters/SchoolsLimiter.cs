using Imade.Speedware.Api.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imade.Speedware.Api.Filters
{
    public class SchoolsLimiter: ILimiter
    {
        public int Take { get; set; } = 10;
        public int Skip { get; set; } = 0;
        /// <summary>
        /// Filter using contains
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Available fields: Name, default Name
        /// </summary>
        public string Sort { get; set; } = Core.Sorting.SchoolsBy.Name.ToString();
    }
}

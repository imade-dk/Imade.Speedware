using Imade.Speedadmin.Api.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imade.Speedadmin.Api.Filters
{
    public class NewsLimiter: ILimiter
    {
        /// <summary>
        /// Required
        /// </summary>
        public IEnumerable<int> PublishTypeIds { get; set; }
        /// <summary>
        /// Data type: Date, defaults to current date at midnight
        /// This evaluates if the value of DateFrom is between start and end. 
        /// Due to poor naming an additional property is added that does the same- DateBetweenStartAndEnd
        /// </summary>
        public DateTime DateFrom { get; set; } = DateTime.Today;

        public DateTime? DateBetweenStartAndEnd { get; set; }
        public DateTime? StartIsAfterOrEq { get; set; }
        public DateTime? CreatedAfterOrEq { get; set; }
        public int? ID { get; set; }
        /// <summary>
        /// Range: inclusive between 0 and 200, default 10
        /// </summary>
        public int Take { get; set; } = 10;
        /// <summary>
        /// Range: inclusive between 0 and 2147483647, default 0
        /// </summary>
        public int Skip { get; set; } = 0;
        /// <summary>
        /// Available fields CreatedDate, Title, Firstname, Lastname, default CreatedDate
        /// </summary>
        public string Sort { get; set; } = Core.Sorting.NewsBy.CreatedDate.ToString();
        public IEnumerable<string> GetFormattetAndMappedSortString { get; set; } = null;
    }
}

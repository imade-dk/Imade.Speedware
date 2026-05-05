using Imade.Speedadmin.Api.Interfaces;
using System;

namespace Imade.Speedadmin.Api.Filters
{
    public class CancellationsLimiter : ILimiter
    {
        /// <summary>
        /// Filter using gt and eq
        /// Deafaults to today
        /// </summary>
        public DateTime DateFrom { get; set; } = DateTime.Today;
        /// <summary>
        /// Filter using lt and eq
        /// defaults to today + 1
        /// </summary>
        public DateTime DateTo { get; set; } = DateTime.Today.AddDays(1);
        /// <summary>
        /// Filter using equals
        /// </summary>
        public int? WeekDay { get; set; }
        /// <summary>
        /// Range: inclusive between 0 and 500, default 10
        /// </summary>
        public int Take { get; set; } = 10;
        /// <summary>
        /// Range: inclusive between 0 and 2147483647, default 0
        /// </summary>
        public int Skip { get; set; } = 0;
        /// <summary>
        /// Available fields Date
        /// </summary>
        public string Sort { get; set; } = Core.Sorting.CancellationsBy.Date.ToString();
    }
}

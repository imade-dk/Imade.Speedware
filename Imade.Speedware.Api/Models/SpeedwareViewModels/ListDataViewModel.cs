using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imade.Speedware.Api.Models.SpeedwareViewModels
{
    [Serializable]
    public abstract class ListDataViewModel
    {
        public string Data { get; set; }
        public int ReportId { get; set; }
        public string Title { get; set; }
    }
}

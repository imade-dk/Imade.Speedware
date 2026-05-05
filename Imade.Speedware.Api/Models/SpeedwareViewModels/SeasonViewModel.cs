using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imade.Speedadmin.Api.Models.SpeedwareViewModels
{
    [Serializable]
     public abstract class SeasonViewModel
    {
        public int SeasonId { get; set; }
        public string Season { get; set; }
    }
}

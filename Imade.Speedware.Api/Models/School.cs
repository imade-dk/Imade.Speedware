using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imade.Speedware.Api.Models
{
    public class School: SpeedwareViewModels.SchoolViewModel
    {
        public SchoolContact SchoolContact { get; set; } = new SchoolContact();
    }
}

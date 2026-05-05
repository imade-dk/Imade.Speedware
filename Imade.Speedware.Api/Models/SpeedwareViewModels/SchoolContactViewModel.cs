using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imade.Speedadmin.Api.Models.SpeedwareViewModels
{
     [Serializable]
    public abstract class SchoolContactViewModel
    {
        public int ContactID { get; set; }
        public string ContactName { get; set; }
        public string Phone { get; set; }
        public string Cell { get; set; }
        public string Email { get; set; }
        public string Comment { get; set; }
        public string ContactType { get; set; }


    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imade.Speedware.Api.Models.SpeedwareViewModels
{
    public abstract class SchoolViewModel
    {
        public int SchoolId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string ZipCode { get; set; }
        public string CityName { get; set; }
        public string District { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string DayCareEmail { get; set; }
        public string Comment { get; set; }
        public bool IsPublic { get; set; }
        public string EAN { get; set; }
        public string JanitorName { get; set; }
        public string JanitorPhone { get; set; }
        public string JanitorMobile { get; set; }
        public string JanitorEmail { get; set; }
        public bool IsCourseSchool { get; set; }
		public int MasterResourceId { get; set; }
		public IEnumerable<Attribute> Attributes { get; set; } = new List<Attribute>();
    }
}

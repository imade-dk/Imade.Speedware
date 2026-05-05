
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imade.Speedadmin.Api.Models.SpeedwareViewModels
{
    public abstract class TeacherViewModel
    {
        public int TeacherId { get; set; }
        public int TeacherMasterResourceId { get; set; } = 0;
		public string Surname { get; set; }
        public string Initials { get; set; }
        public string Address { get; set; }
        public string Location { get; set; }
        public string ZipCode { get; set; }
        public string Phone { get; set; }
        public string Mobile { get; set; }
        public string City { get; set; }
        public int Age { get; set; }
        public string UserType { get; set; }
        public bool Active { get; set; }
        public bool Admin { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public bool Locked { get; set; }
        public DateTime LastPasswordChange { get; set; }
        public int Alert { get; set; }
        public DateTime HireDate { get; set; }
        public bool CanBeBookingOwner { get; set; }
        public IEnumerable<string> AvailableClasses { get; set; } = new List<string>();
		public IEnumerable<Department> Departments { get; set; } = new List<Department>();
		public IEnumerable<Attribute> Attributes { get; set; } = new List<Attribute>();
        public Blob Blob { get; set; }
    }
}

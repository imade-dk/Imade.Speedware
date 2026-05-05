using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imade.Speedadmin.Api.Models.SpeedwareViewModels
{
    public abstract class CourseViewModel
    {
        public int CouseId { get; set; }
        public string Course { get; set; }
        public int CategoriId { get; set; }
        public string Categori { get; set; }
        public string Text { get; set; }
        public string Description { get; set; }
        public int SubjectCodeId { get; set; }
        public int SubjectCode { get; set; }
        public string Subject { get; set; }
        public bool Active { get; set; } = true;
		public int OnWaitingList { get; set; }
        public IEnumerable<CoursesSubCategory> SubCategories { get; set; }
        public IEnumerable<Blob> Blobs { get; set; }
        public IEnumerable<Attribute> Attributes { get; set; } = new List<Attribute>();
        public IEnumerable<int> AvailableAtSchools { get; set; } = new List<int>();
        public IEnumerable<int> TeacherIds { get; set; } = new List<int>();

    }
}

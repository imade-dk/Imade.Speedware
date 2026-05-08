using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Imade.Speedware.Api.Models.SpeedwareViewModels
{
	[Serializable]
	public abstract class OfferingBaseViewModel
	{
		public int OfferingBaseId { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public string Category { get; set; }
		public int  CategoryId { get; set; }
		public int DepartmentId { get; set; }
		public string Department { get; set; }
		public string SubjectName { get; set; }
		public int SubjectId { get; set; }
		public string SubjectAreaName { get; set; }
		public int SubjectAreaId { get; set; }
		public List<int> TeacherIds { get; set; } = [];

		[JsonPropertyName("Image")]
		public Blob Blob { get; set; }
		public IEnumerable<Offering> Offerings { get; set; } = new List<Offering>();
		public IEnumerable<Attribute> Attributes { get; set; } = new List<Attribute>();
        public string CatalogueUrl { get; set; }

    }
}

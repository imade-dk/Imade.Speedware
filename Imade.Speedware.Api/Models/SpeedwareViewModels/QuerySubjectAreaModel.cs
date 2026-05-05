using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imade.Speedware.Api.Models.SpeedwareViewModels
{
	public abstract class QuerySubjectAreaModel
	{
		public int SubjectAreaId { get; set; }
		public string Name { get; set; }
		public bool IsActive { get; set; }
		public  SubjectAreaRegistrationLink RegistrationLink { get; set; }
		public IEnumerable<Subject> Subjects { get; set; }
	}
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imade.Speedadmin.Api.Models.SpeedwareViewModels
{
	public abstract class QuerySubjectModel
	{
		public int SubjectId { get; set; }
		public string Name { get; set; }
		public int SubjectAreaId { get; set; }
		public bool IsActive { get; set; }
	}
}

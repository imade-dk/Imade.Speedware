using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imade.Speedadmin.Api.Models.SpeedwareViewModels
{
	public abstract class WaitingListViewModel
	{
		public int WaitingListId { get; set; }
		public int StudentId { get; set; }
		public int WaitingListCourseId { get; set; }
		public  DateTime AddedAt { get; set; }
	}
}

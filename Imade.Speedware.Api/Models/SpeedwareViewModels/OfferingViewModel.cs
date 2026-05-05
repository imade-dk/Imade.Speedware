using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imade.Speedadmin.Api.Models.SpeedwareViewModels
{
	[Serializable]
	public abstract class OfferingViewModel
	{
		public int OfferingId { get; set; }
		public int OfferingBaseId { get; set; }
		public string PublicName { get; set; }
		public bool IsOngoing { get; set; }
		public bool IsEnsemble { get; set; }

	}
}

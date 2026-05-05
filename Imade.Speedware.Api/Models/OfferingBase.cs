using Imade.Speedware.Api.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Imade.Speedware.Api.Models
{
	public class OfferingBase : SpeedwareViewModels.OfferingBaseViewModel, ISpeedwareModel, IBlob
	{
		public List<Teacher> Teachers { get; set; } = [];
	}
}

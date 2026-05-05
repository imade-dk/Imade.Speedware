using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imade.Speedware.Api.Models.SpeedwareViewModels
{
	public abstract class TreeViewModel
	{
		public IEnumerable<NodeViewModel> Nodes = new List<NodeViewModel>();
	}
}

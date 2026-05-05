using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imade.Speedware.Api.Models.SpeedwareViewModels
{
    public abstract class RoomViewModel
    {
        public int RoomId { get; set; }
        public int RoomMasterResourceId { get; set; } = 0;
		public string Room { get; set; }
        public string School { get; set; }
        public string Address { get; set; }
        public string ZipCode { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
    }
}

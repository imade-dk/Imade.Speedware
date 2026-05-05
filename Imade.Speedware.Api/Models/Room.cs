using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imade.Speedware.Api.Models
{
    public class Room : SpeedwareViewModels.RoomViewModel
    {
        public string NameAndSchool
        {
            get { return string.Format("{0} ({1})", Room, School); }
        }

        public string SchoolAndName
        {
            get { return string.Format("{0} ({1})", School, Room); }
        }
    }
}

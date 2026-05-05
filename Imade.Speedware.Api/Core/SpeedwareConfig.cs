using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imade.Speedadmin.Api.Core
{
    public class SpeedwareConfig
    {
        public const string SpeedwareSection = "speedware";
        public string ApiKey { get; set; } = "sdlkjhfgsldjkhflur hkuhgfisukh8oifdyds89ofyu089ds7f8sdhuifsd978f6798sd7f8s5";
        public string BaseUrl { get; set; } = "https://api.speedadmin.dk/v1/";
        public string SchoolIdentifier { get; set; } = "TST";
        public string RootUploadFolder { get; set; } = "speedware";
        public int CacheDuration { get; set; } = 10;
    }
}

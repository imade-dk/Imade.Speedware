using Asp.Versioning;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Imade.Speedware.Web.Controllers
{
    [ApiVersion("1.0")]
    [ApiExplorerSettings(GroupName = "Imade.Speedware.Web")]
    public class ImadeSpeedwareWebApiController : ImadeSpeedwareWebApiControllerBase
    {

        [HttpGet("ping")]
        [ProducesResponseType<string>(StatusCodes.Status200OK)]
        public string Ping() => "Pong";
    }
}

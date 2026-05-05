using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Umbraco.Cms.Api.Common.Attributes;
using Umbraco.Cms.Web.Common.Authorization;
using Umbraco.Cms.Web.Common.Routing;

namespace Imade.Speedware.Web.Controllers
{
    [ApiController]
    [BackOfficeRoute("imadespeedwareweb/api/v{version:apiVersion}")]
    [Authorize(Policy = AuthorizationPolicies.SectionAccessContent)]
    [MapToApi(Constants.ApiName)]
    public class ImadeSpeedwareWebApiControllerBase : ControllerBase
    {
    }
}

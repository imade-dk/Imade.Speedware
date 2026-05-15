using Imade.Speedware.Api.Core;
using Imade.Speedware.Api.Interfaces;
using Imade.Speedware.Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace Imade.Speedware.TestApi.Controllers;

[ApiController]
[Route("api/[controller]")]
[ProducesResponseType(StatusCodes.Status403Forbidden)]
[ProducesResponseType(StatusCodes.Status404NotFound)]
[ProducesResponseType(StatusCodes.Status500InternalServerError)]
public class OfferingBaseController(ISpeedwareClient client) : ControllerBase
{
    [HttpGet]
    [ProducesResponseType<List<OfferingBase>>(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetOfferingBase(CancellationToken ct)
        => Ok(await client.GetListAsync<OfferingBase>(ApiEndpoint.OfferingBase, ct));

    [HttpGet("{id:int}")]
    [ProducesResponseType<OfferingBase>(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetOfferingBaseItem(int id, CancellationToken ct)
        => Ok(await client.GetAsync<OfferingBase>(ApiEndpoint.OfferingBaseById, id, ct));
}

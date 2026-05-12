using Imade.Speedware.Api.Core;
using Imade.Speedware.Api.Interfaces;
using Imade.Speedware.Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace Imade.Speedware.TestApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PublishTypesController(ISpeedwareClient client) : ControllerBase
{
    [HttpGet]
    [ProducesResponseType<List<PublishType>>(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetPublishTypes(CancellationToken ct)
        => Ok(await client.GetListAsync<PublishType>(ApiEndpoint.PublishTypes, ct));

    [HttpGet("{id:int}")]
    [ProducesResponseType<PublishType>(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetPublishType(int id, CancellationToken ct)
        => Ok(await client.GetAsync<PublishType>(ApiEndpoint.PublishTypeById, id, ct));
}

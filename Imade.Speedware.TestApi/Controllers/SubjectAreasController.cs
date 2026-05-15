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
public class SubjectAreasController(ISpeedwareClient client) : ControllerBase
{
    [HttpGet]
    [ProducesResponseType<List<SubjectArea>>(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetSubjectAreas(CancellationToken ct)
        => Ok(await client.GetListAsync<SubjectArea>(ApiEndpoint.SubjectAreas, ct));

    [HttpGet("{id:int}")]
    [ProducesResponseType<SubjectArea>(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetSubjectArea(int id, CancellationToken ct)
        => Ok(await client.GetAsync<SubjectArea>(ApiEndpoint.SubjectAreaById, id, ct));
}

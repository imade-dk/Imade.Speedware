using Imade.Speedware.Api.Core;
using Imade.Speedware.Api.Interfaces;
using Imade.Speedware.Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace Imade.Speedware.TestApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SchoolsController(ISpeedwareClient client) : ControllerBase
{
    [HttpGet]
    [ProducesResponseType<List<School>>(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetSchools(CancellationToken ct)
        => Ok(await client.GetListAsync<School>(ApiEndpoint.Schools, ct));

    [HttpGet("{id:int}")]
    [ProducesResponseType<School>(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetSchool(int id, CancellationToken ct)
        => Ok(await client.GetAsync<School>(ApiEndpoint.SchoolById, id, ct));

    [HttpGet("{id:int}/contacts")]
    [ProducesResponseType<List<SchoolContact>>(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetSchoolContacts(int id, CancellationToken ct)
        => Ok(await client.GetListAsync<SchoolContact>(ApiEndpoint.SchoolContactsBySchoolId, id, ct));
}

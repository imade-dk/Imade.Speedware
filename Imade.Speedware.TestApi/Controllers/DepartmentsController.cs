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
public class DepartmentsController(ISpeedwareClient client) : ControllerBase
{
    [HttpGet]
    [ProducesResponseType<List<Department>>(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetDepartments(CancellationToken ct)
        => Ok(await client.GetListAsync<Department>(ApiEndpoint.Departments, ct));

    [HttpGet("{id:int}")]
    [ProducesResponseType<Department>(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetDepartment(int id, CancellationToken ct)
        => Ok(await client.GetAsync<Department>(ApiEndpoint.DepartmentById, id, ct));
}

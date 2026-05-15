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
public class CategoriesController(ISpeedwareClient client) : ControllerBase
{
    [HttpGet]
    [ProducesResponseType<List<Category>>(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetCategories(CancellationToken ct)
        => Ok(await client.GetListAsync<Category>(ApiEndpoint.Categories, ct));
}

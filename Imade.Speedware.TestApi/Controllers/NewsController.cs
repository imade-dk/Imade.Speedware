using Imade.Speedware.Api.Core;
using Imade.Speedware.Api.Filters;
using Imade.Speedware.Api.Interfaces;
using Imade.Speedware.Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace Imade.Speedware.TestApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class NewsController(ISpeedwareClient client) : ControllerBase
{
    [HttpPost]
    [ProducesResponseType<PagedResult<News>>(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetNews([FromBody] NewsLimiter filter, CancellationToken ct)
        => Ok(await client.PostAsync<News, NewsLimiter>(ApiEndpoint.News, filter, ct));

    [HttpGet("{id:int}")]
    [ProducesResponseType<News>(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetNewsItem(int id, CancellationToken ct)
        => Ok(await client.GetAsync<News>(ApiEndpoint.NewsById, id, ct));
}

using Imade.Speedware.Api.Core;
using Imade.Speedware.Api.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Imade.Speedware.TestApi.Controllers;

[ApiController]
[Route("api/[controller]")]
[ProducesResponseType(StatusCodes.Status403Forbidden)]
[ProducesResponseType(StatusCodes.Status404NotFound)]
[ProducesResponseType(StatusCodes.Status500InternalServerError)]
public class BlobsController(ISpeedwareClient client) : ControllerBase
{
    [HttpGet("{id}")]
    [ProducesResponseType<byte[]>(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetBlob(string id, CancellationToken ct)
    {
        var bytes = await client.GetBlobBytesAsync(ApiEndpoint.BlobById, id, ct);
        return File(bytes, "application/octet-stream");
    }
}

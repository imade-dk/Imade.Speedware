using Imade.Speedware.Api.Core;
using Imade.Speedware.Api.Interfaces;
using Imade.Speedware.Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace Imade.Speedware.TestApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RoomsController(ISpeedwareClient client) : ControllerBase
{
    [HttpGet]
    [ProducesResponseType<List<Room>>(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetRooms(CancellationToken ct)
        => Ok(await client.GetListAsync<Room>(ApiEndpoint.Rooms, ct));

    [HttpGet("{id:int}")]
    [ProducesResponseType<Room>(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetRoom(int id, CancellationToken ct)
        => Ok(await client.GetAsync<Room>(ApiEndpoint.RoomById, id, ct));

    [HttpGet("all")]
    [ProducesResponseType<List<Room>>(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetRoomsAll(CancellationToken ct)
        => Ok(await client.GetListAsync<Room>(ApiEndpoint.RoomsAll, ct));
}

using Imade.Speedware.Api.Core;
using Imade.Speedware.Api.Filters;
using Imade.Speedware.Api.Interfaces;
using Imade.Speedware.Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace Imade.Speedware.TestApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PlayBookingsController(ISpeedwareClient client) : ControllerBase
{
    [HttpPost]
    [ProducesResponseType<List<PlayBooking>>(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetPlayBookings([FromBody] PlayBookingRequest filter, CancellationToken ct)
        => Ok(await client.PostAsyncList<PlayBooking, PlayBookingRequest>(ApiEndpoint.PlayBookings, filter, ct));

    [HttpGet("{id:int}")]
    [ProducesResponseType<PlayBooking>(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetPlayBooking(int id, CancellationToken ct)
        => Ok(await client.GetAsync<PlayBooking>(ApiEndpoint.PlayBookingById, id, ct));

    [HttpGet("types")]
    [ProducesResponseType<List<PlayBookingType>>(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetPlayBookingTypes(CancellationToken ct)
        => Ok(await client.GetListAsync<PlayBookingType>(ApiEndpoint.PlayBookingTypes, ct));

    [HttpGet("types/{id:int}")]
    [ProducesResponseType<PlayBookingType>(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetPlayBookingType(int id, CancellationToken ct)
        => Ok(await client.GetAsync<PlayBookingType>(ApiEndpoint.PlayBookingTypeById, id, ct));
}

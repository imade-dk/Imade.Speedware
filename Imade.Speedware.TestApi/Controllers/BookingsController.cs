using Imade.Speedware.Api.Core;
using Imade.Speedware.Api.Filters;
using Imade.Speedware.Api.Interfaces;
using Imade.Speedware.Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace Imade.Speedware.TestApi.Controllers;

[ApiController]
[Route("api/[controller]")]
[ProducesResponseType(StatusCodes.Status403Forbidden)]
[ProducesResponseType(StatusCodes.Status404NotFound)]
[ProducesResponseType(StatusCodes.Status500InternalServerError)]
public class BookingsController(ISpeedwareClient client) : ControllerBase
{
    [HttpPost]
    [ProducesResponseType<PagedResult<Booking>>(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetBookings([FromBody] BookingLimiter filter, CancellationToken ct)
        => Ok(await client.PostAsync<Booking, BookingLimiter>(ApiEndpoint.Bookings, filter, ct));

    [HttpGet("{id:int}")]
    [ProducesResponseType<Booking>(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetBooking(int id, CancellationToken ct)
        => Ok(await client.GetAsync<Booking>(ApiEndpoint.BookingById, id, ct));

    [HttpGet("bookingtypes")]
    [ProducesResponseType<List<BookingType>>(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetBookingTypes(CancellationToken ct)
        => Ok(await client.GetListAsync<BookingType>(ApiEndpoint.BookingTypes, ct));

    [HttpGet("bookingtypes/{id:int}")]
    [ProducesResponseType<BookingType>(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetBookingType(int id, CancellationToken ct)
        => Ok(await client.GetAsync<BookingType>(ApiEndpoint.BookingTypeById, id, ct));

    [HttpPost("cancellations")]
    [ProducesResponseType<PagedResult<Cancellation>>(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetCancellations([FromBody] CancellationsLimiter filter, CancellationToken ct)
        => Ok(await client.PostAsync<Cancellation, CancellationsLimiter>(ApiEndpoint.Cancellations, filter, ct));
}

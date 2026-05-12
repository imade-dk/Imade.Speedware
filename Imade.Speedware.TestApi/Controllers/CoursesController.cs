using Imade.Speedware.Api.Core;
using Imade.Speedware.Api.Interfaces;
using Imade.Speedware.Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace Imade.Speedware.TestApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CoursesController(ISpeedwareClient client) : ControllerBase
{
    [HttpGet]
    [ProducesResponseType<List<Course>>(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetCourses(CancellationToken ct)
        => Ok(await client.GetListAsync<Course>(ApiEndpoint.Courses, ct));

    [HttpGet("{id:int}")]
    [ProducesResponseType<Course>(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetCourse(int id, CancellationToken ct)
        => Ok(await client.GetAsync<Course>(ApiEndpoint.CourseById, id, ct));

    [HttpGet("all")]
    [ProducesResponseType<List<Course>>(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetCoursesAll(CancellationToken ct)
        => Ok(await client.GetListAsync<Course>(ApiEndpoint.CoursesAll, ct));

    [HttpGet("tree")]
    [ProducesResponseType<Tree>(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetCoursesTree(CancellationToken ct)
        => Ok(await client.GetAsync<Tree>(ApiEndpoint.CoursesTree, 0, ct));

    [HttpGet("tree/{id:int}")]
    [ProducesResponseType<List<Course>>(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetCoursesByTree(int id, CancellationToken ct)
        => Ok(await client.GetListAsync<Course>(ApiEndpoint.CoursesByTreeId, id, ct));

    [HttpGet("tree/{id:int}/all")]
    [ProducesResponseType<List<Course>>(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetCoursesByTreeAll(int id, CancellationToken ct)
        => Ok(await client.GetListAsync<Course>(ApiEndpoint.CoursesByTreeIdAll, id, ct));
}

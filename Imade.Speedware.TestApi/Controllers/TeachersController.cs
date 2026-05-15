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
public class TeachersController(ISpeedwareClient client) : ControllerBase
{
    [HttpGet]
    [ProducesResponseType<List<Teacher>>(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetTeachers(CancellationToken ct)
        => Ok(await client.GetListAsync<Teacher>(ApiEndpoint.Teachers, ct));

    [HttpGet("{id:int}")]
    [ProducesResponseType<Teacher>(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetTeacher(int id, CancellationToken ct)
        => Ok(await client.GetAsync<Teacher>(ApiEndpoint.TeacherById, id, ct));

    [HttpGet("department/{id:int}")]
    [ProducesResponseType<List<Teacher>>(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetTeachersByDepartment(int id, CancellationToken ct)
        => Ok(await client.GetListAsync<Teacher>(ApiEndpoint.TeachersByDepartmentId, id, ct));

    [HttpGet("{id:int}/courses")]
    [ProducesResponseType<List<Course>>(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetTeacherCourses(int id, CancellationToken ct)
        => Ok(await client.GetListAsync<Course>(ApiEndpoint.TeachersCoursesByTeacherId, id, ct));
}

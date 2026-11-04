using Asp.Versioning;
using Imade.Speedware.Web.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Imade.Speedware.Web.Controllers
{
    [ApiVersion("1.0")]
    [ApiExplorerSettings(GroupName = "Imade.Speedware.Web")]
    public class SpeedwarePickersController(ITeachersService teachersService, IRoomsService roomsService, ISchoolsService schoolsService, IPublishingTypesService publishingTypesService) : ImadeSpeedwareWebApiControllerBase
    {
        [HttpGet("publishing-types")]
        [ProducesResponseType<List<PublishingTypePickerItemDto>>(StatusCodes.Status200OK)]
        public async Task<List<PublishingTypePickerItemDto>> GetPublishingTypes(CancellationToken cancellationToken)
        {
            var types = await publishingTypesService.GetAllAsync(cancellationToken);
            return types
                .OrderBy(t => t.PublishTypeName)
                .Select(t => new PublishingTypePickerItemDto(t.PublishTypeID, t.PublishTypeName ?? string.Empty))
                .ToList();
        }

        [HttpGet("schools")]
        [ProducesResponseType<List<SchoolPickerItemDto>>(StatusCodes.Status200OK)]
        public async Task<List<SchoolPickerItemDto>> GetSchools(CancellationToken cancellationToken)
        {
            var schools = await schoolsService.GetAllAsync(cancellationToken);
            return schools
                .OrderBy(s => s.Name)
                .Select(s => new SchoolPickerItemDto(s.SchoolId, s.Name ?? string.Empty))
                .ToList();
        }

        [HttpGet("rooms")]
        [ProducesResponseType<List<RoomPickerItemDto>>(StatusCodes.Status200OK)]
        public async Task<List<RoomPickerItemDto>> GetRooms(CancellationToken cancellationToken)
        {
            var rooms = await roomsService.GetAllAsync(cancellationToken);
            return rooms
                .OrderBy(r => r.NameAndSchool)
                .Select(r => new RoomPickerItemDto(r.RoomId, r.NameAndSchool))
                .ToList();
        }

        [HttpGet("teachers")]
        [ProducesResponseType<List<TeacherPickerItemDto>>(StatusCodes.Status200OK)]
        public async Task<List<TeacherPickerItemDto>> GetTeachers(CancellationToken cancellationToken)
        {
            var teachers = await teachersService.GetAllAsync(cancellationToken);
            return teachers
                .Where(t => t.Active)
                .OrderBy(t => t.FullName)
                .Select(t => new TeacherPickerItemDto(t.TeacherId, t.FullName ?? string.Empty))
                .ToList();
        }

        [HttpGet("play-teachers")]
        [ProducesResponseType<List<PlayTeacherPickerItemDto>>(StatusCodes.Status200OK)]
        public async Task<List<PlayTeacherPickerItemDto>> GetPlayTeachers(CancellationToken cancellationToken)
        {
            var teachers = await teachersService.GetAllAsync(cancellationToken);
            return teachers
                .Where(t => t.Active && t.TeacherMasterResourceId != 0)
                .OrderBy(t => t.FullName)
                .Select(t => new PlayTeacherPickerItemDto(t.TeacherMasterResourceId, t.FullName ?? string.Empty))
                .ToList();
        }
    }

    public record TeacherPickerItemDto(int Id, string Name);
    public record PlayTeacherPickerItemDto(int Id, string Name);
    public record RoomPickerItemDto(int Id, string Name);
    public record SchoolPickerItemDto(int Id, string Name);
    public record PublishingTypePickerItemDto(int Id, string Name);
}

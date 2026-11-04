using Asp.Versioning;
using Imade.Speedware.Web.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Imade.Speedware.Web.Controllers
{
    [ApiVersion("1.0")]
    [ApiExplorerSettings(GroupName = "Imade.Speedware.Web")]
    public class SpeedwarePickersController(ITeachersService teachersService, IRoomsService roomsService, ISchoolsService schoolsService, IPublishingTypesService publishingTypesService, IBookingTypesService bookingTypesService, IPlayBookingTypesService playBookingTypesService, IOfferingBaseService offeringBaseService, ICoursesService coursesService) : ImadeSpeedwareWebApiControllerBase
    {
        [HttpGet("courses")]
        [ProducesResponseType<List<CoursePickerItemDto>>(StatusCodes.Status200OK)]
        public async Task<List<CoursePickerItemDto>> GetCourses(CancellationToken cancellationToken)
        {
            var courses = await coursesService.GetAllAsync(cancellationToken);
            return courses
                .Where(c => c.Active)
                .OrderBy(c => c.Name)
                .Select(c => new CoursePickerItemDto(c.CouseId, c.Name ?? string.Empty))
                .ToList();
        }

        [HttpGet("offering-bases")]
        [ProducesResponseType<List<OfferingBasePickerItemDto>>(StatusCodes.Status200OK)]
        public async Task<List<OfferingBasePickerItemDto>> GetOfferingBases(CancellationToken cancellationToken)
        {
            var offeringBases = await offeringBaseService.GetAllAsync(cancellationToken);
            return offeringBases
                .OrderBy(o => o.Name)
                .Select(o => new OfferingBasePickerItemDto(o.OfferingBaseId, o.Name ?? string.Empty))
                .ToList();
        }

        [HttpGet("play-booking-types")]
        [ProducesResponseType<List<PlayBookingTypePickerItemDto>>(StatusCodes.Status200OK)]
        public async Task<List<PlayBookingTypePickerItemDto>> GetPlayBookingTypes(CancellationToken cancellationToken)
        {
            var types = await playBookingTypesService.GetAllAsync(cancellationToken);
            return types
                .Where(t => t.IsActive)
                .OrderBy(t => t.Name)
                .Select(t => new PlayBookingTypePickerItemDto(t.BookingTypeId, t.Name ?? string.Empty))
                .ToList();
        }

        [HttpGet("booking-types")]
        [ProducesResponseType<List<BookingTypePickerItemDto>>(StatusCodes.Status200OK)]
        public async Task<List<BookingTypePickerItemDto>> GetBookingTypes(CancellationToken cancellationToken)
        {
            var types = await bookingTypesService.GetAllAsync(cancellationToken);
            return types
                .OrderBy(t => t.Bookingtype)
                .Select(t => new BookingTypePickerItemDto(t.BookingTypeID, t.Bookingtype ?? string.Empty))
                .ToList();
        }

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
    public record BookingTypePickerItemDto(int Id, string Name);
    public record PlayBookingTypePickerItemDto(int Id, string Name);
    public record OfferingBasePickerItemDto(int Id, string Name);
    public record CoursePickerItemDto(int Id, string Name);
}

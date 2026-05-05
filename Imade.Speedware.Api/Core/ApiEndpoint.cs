using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.ComponentModel;

namespace Imade.Speedadmin.Api.Core
{
	public enum ApiEndpoint
	{

		[Description("lesson")]
		Lesson,
		[Description("lesson/{id}")]
		LessonById,

		[Description("season")]
		Season,
		[Description("season/{id}")]
		SeasonById,

		[Description("blobs/{id}")]
		BlobById,

		[Description("list")]
		List,
		[Description("list/{id}")]
		ListById,

		[Description("bookings")]
		Bookings,
		[Description("bookings/{id}")]
		BookingById,

		[Description("bookings/bookingtypes")]
		BookingTypes,
		[Description("bookings/bookingtypes/{id}")]
		BookingTypeById,

		[Description("bookings/cancellations")]
		Cancellations,

		[Description("bookings/createbooking")]
		CreateBooking,
		[Description("bookings/deletebooking/{id}")]
		DeleteBooking,

		[Description("news")]
		News,
		[Description("news/{id}")]
		NewsById,

		[Description("courses")]
		Courses,
		[Description("courses/{id}")]
		CourseById,
		[Description("courses/all")]
		CoursesAll,
		[Description("courses/tree/{id}")]
		CoursesByTreeId,
		[Description("courses/tree/{id}/all")]
		CoursesByTreeIdAll,
		[Description("courses/tree")]
		CoursesTree,

		[Description("teachers")]
		Teachers,
		[Description("teachers/{id}")]
		TeacherById,
		[Description("teachers/department/{id}")]
		TeachersByDepartmentId,
		[Description("teachers/{id}/Courses")]
		TeachersCoursesByTeacherId,

		[Description("publishtypes")]
		PublishTypes,
		[Description("publishtypes/{id}")]
		PublishTypeById,

		[Description("schools")]
		Schools,
		[Description("schools/{id}")]
		SchoolById,
		[Description("schools/{id}/Contacts")]
		SchoolContactsBySchoolId,

		[Description("departments")]
		Departments,
		[Description("departments/{id}")]
		DepartmentById,

		[Description("rooms")]
		Rooms,
		[Description("rooms/{id}")]
		RoomById,
		[Description("rooms/all")]
		RoomsAll,

		[Description("waitinglist/waitinglistcourses")]
		WaitingListCourses,
		[Description("waitinglist/{id}")]
		WaitingListById,

		[Description("playbooking")]
		PlayBookings,
		[Description("playbooking/{id}")]
		PlayBookingById,

		[Description("playbookingtype")]
		PlayBookingTypes,
		[Description("playbookingtype/{id}")]
		PlayBookingTypeById,

		[Description("subjectareas")]
		SubjectAreas,
		[Description("subjectareas/{id}")]
		SubjectAreaById,

		[Description("offeringbase")]
		OfferingBase,
		[Description("offeringbase/{id}")]
		OfferingBaseById,

		[Description("")]
		Categories
	};
}


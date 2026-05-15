# Speedware TestApi — Endpoint Checklist

## Bookings
- [x] POST   /api/bookings                        (BookingLimiter body)
- [x] GET    /api/bookings/{id}
- [x] GET    /api/bookings/bookingtypes
- [x] GET    /api/bookings/bookingtypes/{id}
- [x] POST   /api/bookings/cancellations           (CancellationsLimiter body)

## Blobs
- [x] GET    /api/blobs/{id}

## Categories
- [x] GET    /api/categories

## Courses
- [x] GET    /api/courses
- [x] GET    /api/courses/{id}
- [x] GET    /api/courses/all
- [x] GET    /api/courses/tree
- [x] GET    /api/courses/tree/{id}
- [x] GET    /api/courses/tree/{id}/all

## Departments
- [x] GET    /api/departments
- [x] GET    /api/departments/{id}

## News
- [x] POST   /api/news                             (NewsLimiter body)
- [x] GET    /api/news/{id}

## OfferingBase
- [x] GET    /api/offeringbase
- [x] GET    /api/offeringbase/{id}

## PlayBookings
- [x] POST   /api/playbookings                     (PlayBookingRequest body)
- [x] GET    /api/playbookings/{id}
- [x] GET    /api/playbookings/types
- [x] GET    /api/playbookings/types/{id}

## PublishTypes
- [x] GET    /api/publishtypes
- [x] GET    /api/publishtypes/{id}

## Rooms
- [x] GET    /api/rooms
- [x] GET    /api/rooms/{id}
- [x] GET    /api/rooms/all

## Schools
- [x] GET    /api/schools
- [x] GET    /api/schools/{id}
- [x] GET    /api/schools/{id}/contacts

## SubjectAreas
- [x] GET    /api/subjectareas
- [x] GET    /api/subjectareas/{id}

## Teachers
- [x] GET    /api/teachers
- [x] GET    /api/teachers/{id}
- [x] GET    /api/teachers/department/{id}
- [x] GET    /api/teachers/{id}/courses

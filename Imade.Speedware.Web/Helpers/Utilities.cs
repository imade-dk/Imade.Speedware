using System;
using System.Collections.Generic;
using System.Text;
using Imade.Speedware.Api.Core;
using Imade.Speedware.Api.Interfaces;
using Imade.Speedware.Api.Models;
using Markdig;
using Markdig.Syntax;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace Imade.Speedware.Web.Helpers
{
    public class Utilities
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IOptions<SpeedwareConfig> _config;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly MarkdownPipeline _markdigPipeline;

        public Utilities(IHttpContextAccessor httpContextAccessor, IOptions<Api.Core.SpeedwareConfig> config, IWebHostEnvironment webHostEnvironment, MarkdownPipeline markdigPipeline)
        {
            _httpContextAccessor = httpContextAccessor;
            _config = config;
            _webHostEnvironment = webHostEnvironment;
            _markdigPipeline = markdigPipeline;
        }

        public string GetServerFilePath(string clientPath)
        {
            return System.IO.Path.Combine(_webHostEnvironment.WebRootPath, clientPath.TrimStart('/'));
        }

        public string GetClientFilePath(ISpeedwareModel model)
        {
            if (model is Teacher)
            {
                if (model is not Teacher m)
                {
                    return string.Empty;
                }
                return Paths.ClientFilePath(m.Blob, Core.FileFolder.Teacher, m.TeacherId, _config.Value.RootUploadFolder);
            }
            else if (model is News)
            {
                if (model is not News m)
                {
                    return string.Empty;
                }
                return Paths.ClientFilePath(m.Blob, Core.FileFolder.News, m.NewsId, _config.Value.RootUploadFolder);
            }
            else if (model is Node)
            {
                if (model is not Node m)
                {
                    return string.Empty;
                }
                return Paths.ClientFilePath(m.Blob, Core.FileFolder.Tree, m.TreeID, _config.Value.RootUploadFolder);
            }
            else if (model is Course)
            {
                if (model is not Course m)
                {
                    return string.Empty;
                }
                return Paths.ClientFilePath(m.Blob, Core.FileFolder.Courses, m.CouseId, _config.Value.RootUploadFolder);
            }
            else if (model is Booking)
            {
                if (model is not Booking m)
                {
                    return string.Empty;
                }
                return Paths.ClientFilePath(m.Blob, Core.FileFolder.Bookings, m.BookingId, _config.Value.RootUploadFolder);
            }
            else if (model is OfferingBase)
            {
                if (model is not OfferingBase m)
                {
                    return string.Empty;
                }
                return Paths.ClientFilePath(m.Blob, Core.FileFolder.OfferingBase, m.OfferingBaseId, _config.Value.RootUploadFolder);
            }
            else if (model is PlayBooking)
            {
                if (model is not PlayBooking m)
                {
                    return string.Empty;
                }
                return Paths.ClientFilePath(m.Blob, Core.FileFolder.PlayBooking, m.BookingId, _config.Value.RootUploadFolder);
            }
            //else if (model is Node)
            //{
            //    var m = model as Node;
            //    return Paths.ClientFilePath(m.Blob, Core.FileFolder.Tree, m.TreeID, _config.Value.RootUploadFolder);
            //}

            return string.Empty;
        }

        public string GetClientFilePath(ISpeedwareModel model, Blob blob)
        {
            if (model is Teacher)
            {
                if (model is not Teacher m)
                {
                    return string.Empty;
                }
                return Paths.ClientFilePath(blob, Core.FileFolder.Teacher, m.TeacherId, _config.Value.RootUploadFolder);
            }
            else if (model is News)
            {
                if (model is not News m)
                {
                    return string.Empty;
                }
                return Paths.ClientFilePath(blob, Core.FileFolder.News, m.NewsId, _config.Value.RootUploadFolder);
            }
            else if (model is Node)
            {
                if (model is not Node m)
                {
                    return string.Empty;
                }
                return Paths.ClientFilePath(blob, Core.FileFolder.Tree, m.TreeID, _config.Value.RootUploadFolder);
            }
            else if (model is Course)
            {
                if (model is not Course m)
                {
                    return string.Empty;
                }
                return Paths.ClientFilePath(blob, Core.FileFolder.Courses, m.CouseId, _config.Value.RootUploadFolder);
            }
            else if (model is Booking)
            {
                if (model is not Booking m)
                {
                    return string.Empty;
                }
                return Paths.ClientFilePath(blob, Core.FileFolder.Bookings, m.BookingId, _config.Value.RootUploadFolder);
            }
            else if (model is OfferingBase)
            {
                if (model is not OfferingBase m)
                {
                    return string.Empty;
                }
                return Paths.ClientFilePath(blob, Core.FileFolder.OfferingBase, m.OfferingBaseId, _config.Value.RootUploadFolder);
            }
            else if (model is PlayBooking)
            {
                if (model is not PlayBooking m)
                {
                    return string.Empty;
                }
                return Paths.ClientFilePath(blob, Core.FileFolder.PlayBooking, m.BookingId, _config.Value.RootUploadFolder);
            }
            //else if (model is Node)
            //{
            //    var m = model as Node;
            //    return Paths.ClientFilePath(m.Blob, Core.FileFolder.Tree, m.TreeID, _config.Value.RootUploadFolder);
            //}

            return string.Empty;
        }



        public bool ImageExcists(string path)
        {
            if (System.IO.File.Exists(System.IO.Path.Combine(_webHostEnvironment.WebRootPath, path.TrimStart('/'))))
            {
                return true;
            }
            return false;
        }


        //public bool HasLocalReferrer
        //{
        //    get
        //    {
        //        if (_httpContextAccessor.HttpContext.Request.GetTypedHeaders().Referer != null && _httpContextAccessor.HttpContext.Request.GetTypedHeaders().Referer.Host.ToLower() == _httpContextAccessor.HttpContext.Request.GetTypedHeaders().Host.Host.ToLower())
        //        {
        //            return true;
        //        }

        //        return false;
        //    }
        //}

        public static int CalculateNumberOfPages(int numberOfItems, int pageSize)
        {
            if (pageSize < 1)
            {
                return 1;
            }
            int numberOfPages = Math.DivRem(numberOfItems, pageSize, out int remainder);
            if (remainder > 0)
            {
                numberOfPages++;
            }

            return numberOfPages;
        }

        public int FlipIntToUnsigned(int value)
        {
            if (value >= 0)
            {
                return value;
            }
            return value - (value * 2);
        }

        public int ParseQuerystringAsInt(string key, int defaultValue = 0)
        {
            var query = _httpContextAccessor.HttpContext?.Request.Query;

            if (query != null
                && query.TryGetValue(key, out var value)
                && int.TryParse(value.ToString(), out int result))
            {
                return result;
            }

            return defaultValue;
        }

        public static string SerializeObjectToString(object obj)
        {
            return JsonConvert.SerializeObject(obj).ToString();
        }

        public  string ParseMarkdownAndHtml(string input) {
            if (string.IsNullOrWhiteSpace(input))
            {
                return string.Empty;
            }
            // Normalize line endings
            //markdown = markdown.Replace("\r\n", "\n").Replace("\n\n", "\n"); // Normalize line endings
            //var html = Markdown.ToHtml(markdownText, MarkdigPipeline);
            var document = Markdown.Parse(input, _markdigPipeline);


            foreach (var list in document.Descendants<ListBlock>())
            {
                list.IsLoose = false;
            }

            var html = document.ToHtml();

            if (string.IsNullOrWhiteSpace(html))
            {
                return string.Empty;
            }
            return html;
        }


        public static List<Booking> ExpandBookingList(PagedResult<Booking> bookingList, bool expandListWithDates)
        {
            if (expandListWithDates)
            {
                var extendedBookingList = new List<Booking>();
                if (bookingList.Results != null && bookingList.Results.Any())
                {
                    foreach (var item in bookingList.Results)
                    {
                        if (item.BookingDates.Any())
                        {
                            foreach (var date in item.BookingDates)
                            {
                                var b = item.Clone();
                                var startDateTimed = date.BookingDate.AddHours(date.StartTime.Hour).AddMinutes(date.StartTime.Minute);
                                b.StartDate = startDateTimed;
                                b.StartTime = startDateTimed;
                                var endDateTimed = date.BookingDate.AddHours(date.EndTime.Hour).AddMinutes(date.EndTime.Minute);
                                b.EndTime = endDateTimed;
                                //b.EndTime = date.EndTime;
                                if (b.StartDate >= DateTime.Today)
                                {
                                    extendedBookingList.Add(b);
                                }
                            }
                        }
                        else
                        {
                            extendedBookingList.Add(item);
                        }
                    }
                }
                return extendedBookingList;
            }
            else
            {
                return bookingList.Results;
            }
        }

        public static List<Booking> ExpandBookingListFromTo(PagedResult<Booking> bookingList, bool expandListWithDates, DateTime from, DateTime to)
        {
            if (expandListWithDates)
            {
                var extendedBookingList = new List<Booking>();
                if (bookingList.Results != null && bookingList.Results.Any())
                {
                    foreach (var item in bookingList.Results)
                    {
                        if (item.BookingDates.Count() > 0)
                        {
                            foreach (var date in item.BookingDates)
                            {
                                var b = item.Clone();
                                var startDateTimed = date.BookingDate.AddHours(date.StartTime.Hour).AddMinutes(date.StartTime.Minute);
                                b.StartDate = startDateTimed;
                                b.StartTime = date.StartTime;
                                b.EndTime = date.EndTime;
                                if (b.StartDate >= from && b.StartDate <= to)
                                {
                                    extendedBookingList.Add(b);
                                }
                            }
                        }
                        else
                        {
                            extendedBookingList.Add(item);
                        }
                    }
                }
                return extendedBookingList;
            }
            else
            {
                return bookingList.Results;
            }
        }

        public static List<Booking> ParseBookingDatesExtentions(DateTime startDate, DateTime endDate, bool isAllDay, string title, string location, Umbraco.Cms.Core.Models.Link link = null, string text = "")
        {
            List<Booking> bookings = new();

            if (startDate.Date < endDate.Date)
            {
                var dateDiff = !isAllDay ? endDate.Subtract(startDate) : endDate.Date.Subtract(startDate.Date);

                if (dateDiff.Days == 1)
                {
                    // add the first day
                    bookings.Add(new Booking
                    {
                        Title = title,
                        StartDate = !isAllDay ? startDate : startDate.Date,
                        StartTime = !isAllDay ? new DateTime(1, 1, 1, startDate.Hour, startDate.Minute, 0) : new DateTime(1, 1, 1, 0, 0, 0),
                        EndTime = new DateTime(1, 1, 1, 0, 0, 0),
                        IsAllDayEvent = isAllDay,
                        Location = location,
                        Text = text,
                        LinkName = link != null ? link.Name : string.Empty,
                        LinkTarget = link != null ? link.Target : string.Empty,
                        LinkUrl = link != null ? link.Url : string.Empty
                    });
                    // add the last day
                    bookings.Add(new Booking
                    {
                        Title = title,
                        StartDate = !isAllDay ? endDate : endDate.Date,
                        StartTime = new DateTime(1, 1, 1, 0, 0, 0),
                        EndTime = !isAllDay ? new DateTime(1, 1, 1, endDate.Hour, endDate.Minute, 0) : new DateTime(1, 1, 1, 0, 0, 0),
                        IsAllDayEvent = isAllDay,
                        Location = location,
                        Text = text,
                        LinkName = link != null ? link.Name : string.Empty,
                        LinkTarget = link != null ? link.Target : string.Empty,
                        LinkUrl = link != null ? link.Url : string.Empty
                    });
                }
                if (dateDiff.Days > 1)
                {

                    // add the first day
                    bookings.Add(new Booking
                    {
                        Title = title,
                        StartDate = !isAllDay ? startDate : startDate.Date,
                        StartTime = !isAllDay ? new DateTime(1, 1, 1, startDate.Hour, startDate.Minute, 0) : new DateTime(1, 1, 1, 0, 0, 0),
                        EndTime = !isAllDay ? new DateTime(1, 1, 1, endDate.Hour, endDate.Minute, 0) : new DateTime(1, 1, 1, 0, 0, 0),
                        IsAllDayEvent = isAllDay,
                        Location = location,
                        Text = text,
                        LinkName = link != null ? link.Name : string.Empty,
                        LinkTarget = link != null ? link.Target : string.Empty,
                        LinkUrl = link != null ? link.Url : string.Empty
                    });
                    // add the days inbetween
                    for (var i = 1; i < dateDiff.Days; i++)
                    {
                        bookings.Add(new Booking
                        {
                            Title = title,
                            StartDate = !isAllDay ? startDate.AddDays(i) : startDate.Date.AddDays(i),
                            StartTime = !isAllDay ? new DateTime(1, 1, 1, startDate.Hour, startDate.Minute, 0) : new DateTime(1, 1, 1, 0, 0, 0),
                            EndTime = !isAllDay ? new DateTime(1, 1, 1, endDate.Hour, endDate.Minute, 0) : new DateTime(1, 1, 1, 0, 0, 0),
                            IsAllDayEvent = isAllDay,
                            Location = location,
                            Text = text,
                            LinkName = link != null ? link.Name : string.Empty,
                            LinkTarget = link != null ? link.Target : string.Empty,
                            LinkUrl = link != null ? link.Url : string.Empty
                        });

                    }

                    // add the last day
                    bookings.Add(new Booking
                    {
                        Title = title,
                        StartDate = !isAllDay ? endDate : endDate.Date,
                        StartTime = !isAllDay ? new DateTime(1, 1, 1, startDate.Hour, startDate.Minute, 0) : new DateTime(1, 1, 1, 0, 0, 0),
                        EndTime = !isAllDay ? new DateTime(1, 1, 1, endDate.Hour, endDate.Minute, 0) : new DateTime(1, 1, 1, 0, 0, 0),
                        IsAllDayEvent = isAllDay,
                        Location = location,
                        Text = text,
                        LinkName = link != null ? link.Name : string.Empty,
                        LinkTarget = link != null ? link.Target : string.Empty,
                        LinkUrl = link != null ? link.Url : string.Empty
                    });



                }
            }
            else if (startDate.Date == endDate.Date)
            {
                bookings.Add(new Booking
                {
                    Title = title,
                    StartDate = !isAllDay ? startDate : startDate.Date,
                    StartTime = !isAllDay ? new DateTime(1, 1, 1, startDate.Hour, startDate.Minute, 0) : new DateTime(1, 1, 1, 0, 0, 0),
                    EndTime = !isAllDay ? new DateTime(1, 1, 1, endDate.Hour, endDate.Minute, 0) : new DateTime(1, 1, 1, 0, 0, 0),
                    IsAllDayEvent = isAllDay,
                    Location = location,
                    Text = text,
                    LinkName = link != null ? link.Name : string.Empty,
                    LinkTarget = link != null ? link.Target : string.Empty,
                    LinkUrl = link != null ? link.Url : string.Empty
                });
            }
            return bookings;

        }

        public static List<PlayBooking> ExpandPlayBookings(List<PlayBooking> bookings, bool expandOnlyForNextMonth = false)
        {
            List<PlayBooking> clonedPlayBookings = new List<PlayBooking>();
            foreach (var item in bookings)
            {
                if (item.TimeSlots.Count() > 1)
                {
                    foreach (var timeSlot in item.TimeSlots)
                    {
                        if (expandOnlyForNextMonth && timeSlot.BookingDate > DateTime.Now.AddMonths(1))
                        {
                            continue;
                        }

                        PlayBooking clone = new PlayBooking(item)
                        {
                            NextTimeSlotDate = timeSlot.BookingDate.Add(timeSlot.StartTime.ToTimeSpan()),
                            TeacherAndRoomOnNextTimeSlot = timeSlot.Resources
                        };
                        clonedPlayBookings.Add(clone);

                    }
                }
                else
                {
                    clonedPlayBookings.Add(item);
                }
            }
            return clonedPlayBookings;
        }

        public string RenderAttribute(string attributeName, IEnumerable<Api.Models.Attribute> attributes, bool htmlDecode = true)
        {
            return GetAttributeValue(attributeName, attributes, htmlDecode);
        }
        public string GetAttributeValue(string attributeName, IEnumerable<Api.Models.Attribute> attributes, bool htmlDecode = true)
        {
            if (attributes.Any())
            {
                var attribute = attributes.FirstOrDefault(x => x.Name == attributeName && !string.IsNullOrWhiteSpace(x.Value));
                if (attribute is not null)
                {
                    if (htmlDecode)
                    {
                        return System.Web.HttpUtility.HtmlDecode(attribute.Value ?? string.Empty);
                    }
                    return attribute.Value ?? string.Empty;
                }
            }
            return string.Empty;
        }

        public static string ParseVideoUrl(string url)
        {
            if (url.IndexOf("youtube.com") > -1 || url.IndexOf("youtu.be") > -1 || url.IndexOf("vimeo.com") > -1)
            {
                return GetVideoId(url);
            }
            else
            {
                return url;
            }
            //return string.Empty;
        }
        private static string GetVideoId(string url)
        {
            try
            {
                var uri = new Uri(url);
                var query = System.Web.HttpUtility.ParseQueryString(uri.Query);
                if (query.AllKeys.Contains("v"))
                {
                    return query["v"] ?? string.Empty;
                }
                return uri.Segments.Last() ?? string.Empty;
            }
            catch { }
            return string.Empty;
        }

    }
}

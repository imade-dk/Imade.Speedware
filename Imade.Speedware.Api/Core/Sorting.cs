using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imade.Speedadmin.Api.Core
{
    public class Sorting
    {
        public enum NewsBy
        {
            CreatedDate,
            Title,
            Firstname,
            Lastname
        }

        public enum SchoolsBy
        {
            Name
        }

        public enum BookingsBy
        {
            StartDate,
            TeacherName,
            BookingTypeId,
            School
        }

        public enum CancellationsBy
        {
            Date
        }
    }
}

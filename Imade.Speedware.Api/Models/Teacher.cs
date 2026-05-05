using Imade.Speedware.Api.Interfaces;
using Imade.Speedware.Api.Models.SpeedwareViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Imade.Speedware.Api.Models
{
    [Serializable]
    public class Teacher : TeacherViewModel, ISpeedwareModel, IBlob
    {

        //[JsonPropertyName("Name")]
        //public string Wind { get; set; }
        public string FullName
        {
            get { return $"{Name} {Surname}"; }
        }
        public List<Course> Courses { get; set; } = new List<Course>();
    }
}

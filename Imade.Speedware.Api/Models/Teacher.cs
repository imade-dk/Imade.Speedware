using Imade.Speedadmin.Api.Interfaces;
using Imade.Speedadmin.Api.Models.SpeedwareViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Imade.Speedadmin.Api.Models
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

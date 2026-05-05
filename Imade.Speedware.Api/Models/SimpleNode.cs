using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imade.Speedadmin.Api.Models
{
    public class SimpleNode
    {
        public int TreeID { get; set; }
        public string NodeName { get; set; }
        public int ParentID { get; set; }
        public bool Active { get; set; }
        public bool ParentActive { get; set; }
        public IEnumerable<Node> ChildNodes { get; set; } = new List<Node>();
        public IEnumerable<TreeCourse> Courses { get; set; } = new List<TreeCourse>();
    }
}

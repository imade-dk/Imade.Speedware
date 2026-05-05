using Imade.Speedadmin.Api.Interfaces;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imade.Speedadmin.Api.Models
{
    [Serializable]
    public class Attribute : IAttribute
    {
        public string Name { get; set; }
        public string Value { get; set; }
        public object ValueAsObject { get; set; }
        public string AttributeType { get; set; }
        public int Sequence { get; set; }
    }
}

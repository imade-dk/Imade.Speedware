using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imade.Speedadmin.Api.Interfaces
{
    public interface IAttribute
    {
        string Name { get; set; }
        string Value { get; set; }
        object ValueAsObject { get; set; }
        string AttributeType { get; set; }
        int Sequence { get; set; }
    }
}

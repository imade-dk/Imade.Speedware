using Imade.Speedadmin.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imade.Speedadmin.Api.Interfaces
{
    public interface IBlobs
    {
        public IEnumerable<Blob> Blobs { get; set; }
    }

    public interface IBlob
    {
        public Blob Blob { get; set; }
    }
}

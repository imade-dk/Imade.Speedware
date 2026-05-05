using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imade.Speedadmin.Api.Models.SpeedwareViewModels
{
    public abstract class NewsViewModel
    {
        public int NewsId { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
		public bool HasPicture { get; set; }
		public IEnumerable<Blob> Blobs { get; set; }
        public Blob Blob { get; set; }

    }
}

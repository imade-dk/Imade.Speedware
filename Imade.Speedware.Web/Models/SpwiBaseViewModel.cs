using System;
using System.Collections.Generic;
using System.Text;
using Umbraco.Cms.Core.Models.PublishedContent;

namespace Imade.Speedware.Web.Models
{
    public class SpwiBaseViewModel : PublishedContentWrapped
    {
        public SpwiBaseViewModel(IPublishedContent content, IPublishedValueFallback publishedValueFallback) : base(content, publishedValueFallback)
        {
            
        }
    }
}

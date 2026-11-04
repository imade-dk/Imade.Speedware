using System;
using System.Collections.Generic;
using System.Text;
using Umbraco.Cms.Core.Models.Blocks;
using Umbraco.Cms.Core.Models.PublishedContent;
using USNSiteBuilder.Core.Models;

namespace Imade.Speedware.Web.Models
{
    public class SpwiBlock<T> where T : class
    {
        public SpwiBlock(SiteBuilderBaseViewModel baseViewModel, IPublishedElement content, IPublishedElement settings, T item, string pageLayout = "")
        {
            BaseModel = baseViewModel;
            BlockContent = content;
            BlockSettings = settings;
            PageLayout = pageLayout;
            Item = item;
        }

        public string PageLayout { get; set; }
        public SiteBuilderBaseViewModel BaseModel { get; set; }
        public IPublishedElement? BlockSettings { get; set; }
        public IPublishedElement BlockContent { get; set; }
        public T Item { get; set; }
    }
}

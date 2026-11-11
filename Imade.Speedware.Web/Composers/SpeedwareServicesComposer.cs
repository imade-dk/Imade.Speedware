using Imade.Speedware.Api.Extensions;
using Imade.Speedware.Web.Services;
using Microsoft.Extensions.DependencyInjection;
using Umbraco.Cms.Core.Composing;
using Umbraco.Cms.Core.DependencyInjection;
using Markdig;

namespace Imade.Speedware.Web.Composers
{
    public class SpeedwareServicesComposer : IComposer
    {
        public void Compose(IUmbracoBuilder builder)
        {
            builder.Services.AddSpeedwareApiClient(builder.Config);

            builder.Services.AddScoped<ITeachersService, TeachersService>();
            builder.Services.AddScoped<ISchoolsService, SchoolsService>();
            builder.Services.AddScoped<IDepartmentsService, DepartmentsService>();
            builder.Services.AddScoped<IRoomsService, RoomsService>();
            builder.Services.AddScoped<IPublishingTypesService, PublishingTypesService>();
            builder.Services.AddScoped<IBookingTypesService, BookingTypesService>();
            builder.Services.AddScoped<IPlayBookingTypesService, PlayBookingTypesService>();
            builder.Services.AddScoped<IOfferingBaseService, OfferingBaseService>();
            builder.Services.AddScoped<ICoursesService, CoursesService>();
            builder.Services.AddScoped<ICoursesTreeService, CoursesTreeService>();
            builder.Services.AddScoped<IBlobService, BlobService>();

            builder.Services.AddSingleton<Helpers.Utilities>();
            builder.Services.AddSingleton<MarkdownPipeline>(sp => {
                return new MarkdownPipelineBuilder()
                    .UseAdvancedExtensions()
                    .Build();
            });
        }
    }
}

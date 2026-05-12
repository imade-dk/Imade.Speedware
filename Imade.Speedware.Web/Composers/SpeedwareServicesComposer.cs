using Imade.Speedware.Api.Extensions;
using Imade.Speedware.Web.Services;
using Microsoft.Extensions.DependencyInjection;
using Umbraco.Cms.Core.Composing;
using Umbraco.Cms.Core.DependencyInjection;

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
            builder.Services.AddScoped<IBlobService, BlobService>();
        }
    }
}

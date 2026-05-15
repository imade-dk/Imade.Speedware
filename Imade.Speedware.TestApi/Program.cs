using Imade.Speedware.Api.Extensions;
using Imade.Speedware.TestApi.Filters;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers(o => o.Filters.Add<SpeedwareExceptionFilter>());
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c => c.SwaggerDoc("v1", new() { Title = "Speedware Test API", Version = "v1" }));
builder.Services.AddSpeedwareApiClient(builder.Configuration);

var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Speedware Test API v1"));
app.MapControllers();

await app.RunAsync();

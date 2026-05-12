using System;
using System.Net.Http.Headers;
using Imade.Speedware.Api.Core;
using Imade.Speedware.Api.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace Imade.Speedware.Api.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddSpeedwareApiClient(this IServiceCollection services, IConfiguration config)
        {
            services.Configure<SpeedwareConfig>(config.GetSection(SpeedwareConfig.SpeedwareSection));

            services.AddHttpClient<ISpeedwareClient, SpeedwareClient>((provider, client) =>
            {
                var speedwareConfig = provider.GetRequiredService<IOptions<SpeedwareConfig>>().Value;

                var apiKey = speedwareConfig.GetApiKey();
                if (string.IsNullOrWhiteSpace(apiKey))
                    throw new InvalidOperationException("Speedware API key is not configured. Set speedware.ApiKeys or speedware.ApiKey in appsettings.json.");
                if (string.IsNullOrWhiteSpace(speedwareConfig.BaseUrl))
                    throw new InvalidOperationException("Speedware BaseUrl is not configured.");

                client.BaseAddress = new Uri(speedwareConfig.BaseUrl);
                client.Timeout = TimeSpan.FromMinutes(10);
                client.DefaultRequestHeaders.Add("Authorization", apiKey);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            });

            return services;
        }
    }
}

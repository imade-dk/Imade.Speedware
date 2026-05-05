using System;
using System.Net.Http.Headers;
using Imade.Speedadmin.Api.Core;
using Imade.Speedadmin.Api.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace Imade.Speedadmin.Api.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddSpeedwareApiClient(this IServiceCollection services, IConfiguration config)
        {
            services.Configure<SpeedwareConfig>(config.GetSection(SpeedwareConfig.SpeedwareSection));

            services.AddHttpClient<ISpeedwareClient, SpeedwareClient>((provider, client) =>
            {
                var speedwareConfig = provider.GetRequiredService<IOptions<SpeedwareConfig>>().Value;

                if (string.IsNullOrWhiteSpace(speedwareConfig.ApiKey))
                    throw new InvalidOperationException("Speedware ApiKey is not configured.");
                if (string.IsNullOrWhiteSpace(speedwareConfig.BaseUrl))
                    throw new InvalidOperationException("Speedware BaseUrl is not configured.");

                client.BaseAddress = new Uri(speedwareConfig.BaseUrl);
                client.Timeout = TimeSpan.FromMinutes(10);
                client.DefaultRequestHeaders.Add("Authorization", speedwareConfig.ApiKey);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            });

            return services;
        }
    }
}

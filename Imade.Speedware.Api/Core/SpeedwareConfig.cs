using System;
using System.Collections.Generic;
using System.Linq;

namespace Imade.Speedware.Api.Core
{
    public class SpeedwareConfig
    {
        public const string SpeedwareSection = "speedware";

        /// <summary>Backward-compat single key. Ignored when ApiKeys is non-empty.</summary>
        public string ApiKey { get; set; } = string.Empty;
        public List<SpeedwareApiKey> ApiKeys { get; set; } = [];

        public string BaseUrl { get; set; } = "https://api.speedadmin.dk/v1/";
        public string SchoolIdentifier { get; set; } = string.Empty;
        public string RootUploadFolder { get; set; } = "speedware";
        public int CacheDuration { get; set; } = 10;

        public string GetApiKey(string? name = null)
        {
            if (ApiKeys.Count > 0)
            {
                if (name is null)
                    return ApiKeys[0].ApiKey;

                return ApiKeys.FirstOrDefault(k => k.Name.Equals(name, StringComparison.OrdinalIgnoreCase))?.ApiKey
                    ?? throw new InvalidOperationException($"No API key configured with name '{name}'.");
            }

            return ApiKey;
        }
    }
}

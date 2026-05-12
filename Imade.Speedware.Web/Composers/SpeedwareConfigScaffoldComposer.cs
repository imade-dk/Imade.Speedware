using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Json.Nodes;
using Imade.Speedware.Api.Core;
using Umbraco.Cms.Core.Composing;
using Umbraco.Cms.Core.DependencyInjection;

namespace Imade.Speedware.Web.Composers
{
    public class SpeedwareConfigScaffoldComposer : IComposer
    {
        public void Compose(IUmbracoBuilder builder)
        {
            try
            {
                var appsettingsPath = Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json");

                if (!File.Exists(appsettingsPath))
                    return;

                var root = JsonNode.Parse(File.ReadAllText(appsettingsPath));
                if (root is not JsonObject rootObject)
                    return;

                if (rootObject.ContainsKey(SpeedwareConfig.SpeedwareSection))
                    return;

                var defaults = new SpeedwareConfig();
                rootObject[SpeedwareConfig.SpeedwareSection] = new JsonObject
                {
                    [nameof(SpeedwareConfig.ApiKeys)] = new JsonArray
                    {
                        new JsonObject
                        {
                            [nameof(SpeedwareApiKey.Name)]   = string.Empty,
                            [nameof(SpeedwareApiKey.ApiKey)] = string.Empty,
                        }
                    },
                    [nameof(SpeedwareConfig.BaseUrl)]          = defaults.BaseUrl,
                    [nameof(SpeedwareConfig.SchoolIdentifier)] = defaults.SchoolIdentifier,
                    [nameof(SpeedwareConfig.RootUploadFolder)] = defaults.RootUploadFolder,
                    [nameof(SpeedwareConfig.CacheDuration)]    = defaults.CacheDuration,
                };

                File.WriteAllText(appsettingsPath, rootObject.ToJsonString(new JsonSerializerOptions
                {
                    WriteIndented = true,
                    Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
                }));
            }
            catch
            {
                // Scaffolding is a convenience step; never break startup.
            }
        }
    }
}

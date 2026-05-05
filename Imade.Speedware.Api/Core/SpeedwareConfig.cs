namespace Imade.Speedadmin.Api.Core
{
    public class SpeedwareConfig
    {
        public const string SpeedwareSection = "speedware";
        public string ApiKey { get; set; } = string.Empty;
        public string BaseUrl { get; set; } = "https://api.speedadmin.dk/v1/";
        public string SchoolIdentifier { get; set; } = string.Empty;
        public string RootUploadFolder { get; set; } = "speedware";
        public int CacheDuration { get; set; } = 10;
    }
}

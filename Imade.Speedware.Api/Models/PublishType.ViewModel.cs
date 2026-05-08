using System.Text.Json.Serialization;

namespace Imade.Speedware.Api.Models;

public partial class PublishType
{
    public int PublishTypeID { get; set; }
    [JsonPropertyName("PublishType")]
    public string? PublishTypeName { get; set; }
}

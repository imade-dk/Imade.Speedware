using System.Text.Json.Serialization;

namespace Imade.Speedware.Api.Models;

public partial class Season
{
    public int SeasonId { get; set; }
    [JsonPropertyName("Season")]
    public string? Name { get; set; }
}

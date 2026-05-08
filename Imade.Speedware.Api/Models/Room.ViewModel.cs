using System.Text.Json.Serialization;

namespace Imade.Speedware.Api.Models;

public partial class Room
{
    public int RoomId { get; set; }
    public int RoomMasterResourceId { get; set; } = 0;
    [JsonPropertyName("Room")]
    public string? Name { get; set; }
    public string? School { get; set; }
    public string? Address { get; set; }
    public string? ZipCode { get; set; }
    public string? Phone { get; set; }
    public string? Email { get; set; }
}

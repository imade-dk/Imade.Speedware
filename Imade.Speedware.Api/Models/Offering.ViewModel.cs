namespace Imade.Speedware.Api.Models;


public partial class Offering
{
    public int OfferingId { get; set; }
    public int OfferingBaseId { get; set; }
    public string? PublicName { get; set; }
    public bool IsOngoing { get; set; }
    public bool IsEnsemble { get; set; }

}

using Imade.Speedware.Api.Interfaces;

namespace Imade.Speedware.Api.Models;

public partial class OfferingBase : ISpeedwareModel, IBlob
{
    public List<Teacher> Teachers { get; set; } = [];
}

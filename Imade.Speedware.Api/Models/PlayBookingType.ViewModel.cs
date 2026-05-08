namespace Imade.Speedware.Api.Models;

	public partial class PlayBookingType
	{
		public int BookingTypeId { get; set; }
		public string? Name { get; set; }
		public BookingV2TypeType Type { get; set; }
		public bool IsActive { get; set; }
		public string? Color { get; set; }
	}

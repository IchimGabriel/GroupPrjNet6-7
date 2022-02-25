namespace HolidayPlaner.Api.Models
{
    public class HolidayComponent
    {
		public int Id { get; set; }

		public int HolidayId { get; set; }

		public string? Name { get; set; }

		public string? Description { get; set; }

		public DateTimeOffset StartDateTime { get; set; }

		public DateTimeOffset EndDateTime { get; set; }
	}
}

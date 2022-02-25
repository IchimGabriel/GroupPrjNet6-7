using System.ComponentModel.DataAnnotations;

namespace HolidayPlaner.Api.Models
{
    public class Holiday
    {
		[Key]
		public int Id { get; set; }

		[Required]
		public string? Name { get; set; }

		[Required]
		public DateTime StartDate { get; set; }

		[Required]
		public DateTime EndDate { get; set; }
	}
}

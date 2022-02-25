namespace HolidayPlaner.Api.Models
{
    public class Repo
    {
		private readonly List<Holiday> MyHolidays = new()
        {
			new Holiday 
			{
				Id = 1,
				Name = "Ink landscape painting",
				StartDate = new DateTime(2022, 5, 5),
				EndDate = new DateTime(2022, 5, 25)
			},
			new Holiday
			{
				Id=2,
				Name="Watercolor mix advance training",
				StartDate = new DateTime(2022, 6, 12),
				EndDate = new DateTime(2022, 6, 20)
			},
			new Holiday
			{
				Id=3,
				Name="Brush techniq",
				StartDate = new DateTime(2022, 8, 10),
				EndDate = new DateTime(2022, 8, 16)
			}
		};

		public List<Holiday> Get()
		{
			return MyHolidays;
		}

		public Holiday Get(int id)
		{
			return MyHolidays.First(t => t.Id == id);
		}

		public void Add(Holiday newHoliday)
		{

			MyHolidays.Add(newHoliday);

		}

		public void Update(Holiday holidayToUpdate)
		{

			MyHolidays.Remove(MyHolidays.First(t => t.Id == holidayToUpdate.Id));
			Add(holidayToUpdate);

		}

		public void Remove(int id)
		{
			MyHolidays.Remove(MyHolidays.First(t => t.Id == id));
		}
	}
}

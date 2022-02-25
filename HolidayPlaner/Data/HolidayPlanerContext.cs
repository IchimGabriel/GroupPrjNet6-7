using HolidayPlaner.Api.Models;
using Microsoft.EntityFrameworkCore;


namespace HolidayPlaner.Api.Data
{
    public class HolidayPlanerContext : DbContext
    {
		public HolidayPlanerContext(DbContextOptions<HolidayPlanerContext> options)
		: base(options) { }

        public HolidayPlanerContext()
        {}
		public DbSet<Holiday> Holidays { get; set; }

        //http://thedatafarm.com/uncategorized/seeding-ef-with-json-data/
        public static void SeedData(IServiceProvider serviceProvider)
		{
			using (var serviceScope = serviceProvider
				.GetRequiredService<IServiceScopeFactory>().CreateScope())
			{
				var context = serviceScope.ServiceProvider.GetRequiredService<HolidayPlanerContext>();

				context.Database.EnsureCreated();

				//var context = servicesScope.ServiceProvider.GetRequiredService<HolidayPlanerContext>();
				//await context.Database.MigrateAsync();

				if (context.Holidays.Any()) return;

				context.Holidays.AddRange(new Holiday[]
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
				});
				context.SaveChanges();
			}
		}
	}
}

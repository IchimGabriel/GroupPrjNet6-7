using HolidayPlaner.Api.Data;
using HolidayPlaner.Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HolidayPlaner.Api.Controllers
{
	[Route("api/[controller]")]
	public class HolidayPlanerController : ControllerBase
    {
		HolidayPlanerContext _context;
		public HolidayPlanerController(HolidayPlanerContext context)
		{
			_context = context;
		}

		// GET api/Holidays
		[HttpGet]
		public async Task<IActionResult> GetAsync()
		{

			var trips = await _context.Holidays
				.AsNoTracking()
				.ToListAsync();
			return Ok(trips);

		}

		// GET api/Holidays/5
		[HttpGet("{id}")]
        public Holiday Get(int id) => _context.Holidays.Find(id);

		// POST api/Holidays
		[HttpPost]
		public IActionResult Post([FromBody] Holiday value)
		{

			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			_context.Holidays.Add(value);
			_context.SaveChanges();

			return Ok();

		}

		// PUT api/Holidays/5
		[HttpPut("{id}")]
		public async Task<IActionResult> PutAsync(int id, [FromBody] Holiday value)
		{

			if (!_context.Holidays.Any(t => t.Id == id))
			{
				return NotFound();
			}

			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}
			_context.Holidays.Update(value);
			await _context.SaveChangesAsync();

			return Ok();

		}

		// DELETE api/Holidays/5
		[HttpDelete("{id}")]
		public IActionResult Delete(int id)
		{

			var myTrip = _context.Holidays.Find(id);

			if (myTrip == null)
			{
				return NotFound();
			}

			_context.Holidays.Remove(myTrip);
			_context.SaveChanges();

			// DELETE FROM Holidays WHERE id=?

			return NoContent();

		}
	}
}

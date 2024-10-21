using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Parcial_1.API.Data;
using Parcial_1.Entities;

namespace Parcial_1.API.Controllers
{
    [ApiController]
    [Route("/api/reservations")]
    public class ReservationsController : ControllerBase
    {
        private readonly DataContext dataContext;

        public ReservationsController(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync(Reservation reservation)
        {
            dataContext.Reservations.Add(reservation);
            await dataContext.SaveChangesAsync();
            return Ok(reservation);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Reservation>> GetAsync(int id)
        {
            return Ok(await dataContext.Reservations.FirstOrDefaultAsync(x => x.Id == id));
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Reservation>>> GetAsync()
        {
            var reservations = await dataContext.Reservations.ToListAsync();
            return Ok(reservations);
        }

        [HttpPut]
        public async Task<ActionResult> Put(Reservation reservation)
        {
            dataContext.Reservations.Update(reservation);
            await dataContext.SaveChangesAsync();
            return Ok(reservation);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var affectedRows = await dataContext.Reservations
                .Where(x => x.Id == id)
                .ExecuteDeleteAsync();
            if (affectedRows == 0)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}

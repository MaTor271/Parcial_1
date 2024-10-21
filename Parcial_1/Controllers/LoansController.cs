using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Parcial_1.API.Data;
using Parcial_1.Entities;

namespace Parcial_1.API.Controllers
{
    [ApiController]
    [Route("/api/loans")]
    public class LoansController : ControllerBase
    {
        private readonly DataContext dataContext;

        public LoansController(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync(Loan loan)
        {
            dataContext.Loans.Add(loan);
            await dataContext.SaveChangesAsync();
            return Ok(loan);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Loan>> GetAsync(int id)
        {
            return Ok(await dataContext.Loans.FirstOrDefaultAsync(x => x.Id == id));
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Loan>>> GetAsync()
        {
            var loans = await dataContext.Loans.ToListAsync();
            return Ok(loans);
        }

        [HttpPut]
        public async Task<ActionResult> Put(Loan loan)
        {
            dataContext.Loans.Update(loan);
            await dataContext.SaveChangesAsync();
            return Ok(loan);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var affectedRows = await dataContext.Loans
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

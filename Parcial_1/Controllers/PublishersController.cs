using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Parcial_1.API.Data;
using Parcial_1.Entities;

namespace Parcial_1.API.Controllers
{
    [ApiController]
    [Route("/api/publishers")]
    public class PublishersController : ControllerBase
    {
        private readonly DataContext dataContext;

        public PublishersController(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync(Publisher publisher)
        {
            dataContext.Publishers.Add(publisher);
            await dataContext.SaveChangesAsync();
            return Ok(publisher);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Publisher>> GetAsync(int id)
        {
            return Ok(await dataContext.Publishers.FirstOrDefaultAsync(x => x.Id == id));
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Publisher>>> GetAsync()
        {
            var publishers = await dataContext.Publishers.ToListAsync();
            return Ok(publishers);
        }

        [HttpPut]
        public async Task<ActionResult> Put(Publisher publisher)
        {
            dataContext.Publishers.Update(publisher);
            await dataContext.SaveChangesAsync();
            return Ok(publisher);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var affectedRows = await dataContext.Publishers
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

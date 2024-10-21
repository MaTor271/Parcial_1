using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Parcial_1.API.Data;
using Parcial_1.Entities;

namespace Parcial_1.API.Controllers
{
    [ApiController]
    [Route("/api/categories")]
    public class CategoriesController : ControllerBase
    {
        private readonly DataContext dataContext;

        public CategoriesController(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync(Category category)
        {
            dataContext.Categories.Add(category);
            await dataContext.SaveChangesAsync();
            return Ok(category);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Category>> GetAsync(int id)
        {
            return Ok(await dataContext.Categories.FirstOrDefaultAsync(x => x.Id == id));
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Category>>> GetAsync()
        {
            var categories = await dataContext.Categories.ToListAsync();
            return Ok(categories);
        }

        [HttpPut]
        public async Task<ActionResult> Put(Category category)
        {
            dataContext.Categories.Update(category);
            await dataContext.SaveChangesAsync();
            return Ok(category);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var affectedRows = await dataContext.Categories
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

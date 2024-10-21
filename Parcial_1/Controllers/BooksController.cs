using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Parcial_1.API.Data;
using Parcial_1.Entities;

namespace Parcial_1.API.Controllers
{
    [ApiController]
    [Route("/api/books")]
    public class BooksController : ControllerBase
    {
        private readonly DataContext dataContext;

        public BooksController(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync(Book book)
        {
            dataContext.Books.Add(book);
            await dataContext.SaveChangesAsync();
            return Ok(book);
        }
        [HttpGet("{id:int}")]
        public async Task<ActionResult<IEnumerable<Book>>> GetAsync(int id)
        {
            
            return Ok(await dataContext.Books.FirstOrDefaultAsync(x=>x.Id==id));
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Book>>> GetAsync()
        {            
            var books = await dataContext.Books.ToListAsync();
            return Ok(books); 
        }
        [HttpPut]
        public async Task<ActionResult> Put(Book book)
        {
            dataContext.Books.Update(book);
            await dataContext.SaveChangesAsync();
            return Ok(book);
        }
        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var afectedRows = await dataContext.Books
                .Where(x => x.Id == id)
                .ExecuteDeleteAsync();
            if (afectedRows == 0)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}

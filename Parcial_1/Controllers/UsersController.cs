using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Parcial_1.API.Data;
using Parcial_1.Entities;

namespace Parcial_1.API.Controllers
{
    [ApiController]
    [Route("/api/users")]
    public class UsersController : ControllerBase
    {
        private readonly DataContext dataContext;

        public UsersController(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync(User user)
        {
            dataContext.Users.Add(user);
            await dataContext.SaveChangesAsync();
            return Ok(user);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<User>> GetAsync(int id)
        {
            return Ok(await dataContext.Users.FirstOrDefaultAsync(x => x.Id == id));
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetAsync()
        {
            var users = await dataContext.Users.ToListAsync();
            return Ok(users);
        }

        [HttpPut]
        public async Task<ActionResult> Put(User user)
        {
            dataContext.Users.Update(user);
            await dataContext.SaveChangesAsync();
            return Ok(user);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var affectedRows = await dataContext.Users
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

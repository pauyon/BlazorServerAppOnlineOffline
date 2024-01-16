using BlazorServerApp.DataStorageSqlite;
using BlazorServerApp.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BlazorServerApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserOfflineController : ControllerBase
    {
        private readonly SqliteDataContext _sqliteContext;

        public UserOfflineController(SqliteDataContext sqliteContext)
        {
            _sqliteContext = sqliteContext;
        }

        [HttpGet]
        public async Task<ActionResult<List<User>>> GetAllUsers()
        {
            var users = await _sqliteContext.Users.ToListAsync();

            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<User>>> GetUser(int id)
        {
            var user = await _sqliteContext.Users.FindAsync(id);

            if (user == null)
            {
                return BadRequest("User does not exist.");
            }

            return Ok(user);
        }

        [HttpPost]
        public async Task<ActionResult<List<User>>> AddUser(User user)
        {
            _sqliteContext.Users.Add(user);
            await _sqliteContext.SaveChangesAsync();

            return Ok(await _sqliteContext.Users.ToListAsync());
        }
    }
}

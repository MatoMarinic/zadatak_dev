using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using zadatak_dev.Data;
using zadatak_dev.Models;

namespace zadatak_dev.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly DataContext _context;
        public UsersController(DataContext context) => _context = context;
        [HttpGet]
        public async Task<IEnumerable<User_Test>> Get() => await _context.Users_Test.ToListAsync();

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(User_Test), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(int id)
        {
            var user = await _context.Users_Test.FindAsync(id);
            return user == null ? NotFound() : Ok(user);

        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> Create(User_Test users)
        {
            await _context.Users_Test.AddAsync(users);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = users.Id_User }, users);
        }
    }
}

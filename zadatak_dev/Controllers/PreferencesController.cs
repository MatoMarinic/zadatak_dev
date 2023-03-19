using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using zadatak_dev.Data;
using zadatak_dev.Models;

namespace zadatak_dev.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PreferencesController : ControllerBase
    {
        private readonly DataContext _context;
        public PreferencesController(DataContext context) => _context = context;

        [HttpGet]
        public async Task<IEnumerable<Preference_Test>> Get() => await _context.Preferences_Test.ToListAsync();
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Preference_Test), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(int id)
        {
            var preference = await _context.Preferences_Test.FindAsync(id);
            return preference == null ? NotFound() : Ok(preference);

        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> Create(Preference_Test preferences)
        {
            _context.Preferences_Test.Add(preferences);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetById), new { id = preferences.Id_Preference }, preferences);
        }
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var preferenceToDelete = await _context.Preferences_Test.FindAsync(id);
            if (preferenceToDelete == null) return NotFound();
            _context.Preferences_Test.Remove(preferenceToDelete);
            await _context.SaveChangesAsync();
            return NoContent();
        }

    }
}

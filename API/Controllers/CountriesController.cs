using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace API.Controllers
{
    public class CountriesController : BaseController
    {
        private readonly DataContext _context;

        public CountriesController(DataContext context)
        {
            _context = context;
        }

        [HttpGet] // api/Countries
        public async Task<ActionResult<List<Country>>> GetCountries()
        {
            return await _context.Countries.ToListAsync();
        }

        [HttpGet("{id}")] //api/Activities/{id}
        public async Task<ActionResult<Country>> GetCountry(Guid id)
        {
            return await _context.Countries.FindAsync(id);
        }

        [HttpGet("speak/{language}")] //api/Countries/{languages}
        public async Task<ActionResult<List<Country>>> GetCountriesThatSpeak(string language)
        {
            return await _context.Countries.Where((Country country) => country.Language.ToLower() == language.ToLower()).ToListAsync();
        }
    }
}
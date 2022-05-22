using Application.Countries;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace API.Controllers
{
    public class CountriesController : BaseController
    {
        

        [HttpGet] // api/Countries
        public async Task<ActionResult<List<Country>>> GetCountries()
        {
            return await Mediator.Send(new List.Query());
        }

        [HttpGet("{id}")] //api/Activities/{id}
        public async Task<ActionResult<Country>> GetCountry(Guid id)
        {
            return await Mediator.Send(new Details.Query{Id = id});
        }


        [HttpGet("speak/{language}")] //api/Countries/{languages}
        public async Task<ActionResult<List<Country>>> GetCountriesThatSpeak(string language)
        {
            return await Mediator.Send(new Language.Query{Language = language});
        }
    }
}
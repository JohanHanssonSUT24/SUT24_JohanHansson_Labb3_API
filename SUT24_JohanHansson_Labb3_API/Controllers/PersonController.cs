using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SUT24_JohanHansson_Labb3_API.Controllers.Data;
using SUT24_JohanHansson_Labb3_API.Models;
using SUT24_JohanHansson_Labb3_API.Models.DTOs;

namespace SUT24_JohanHansson_Labb3_API.Controllers
{
    [Route("api/[controller]")]//States that this is an API-controller
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly ApiDbContext _context;

        public PersonController(ApiDbContext context)
        {
            _context = context;
        }
        [HttpGet]//Get all persons from db
        public async Task<ActionResult<IEnumerable<Person>>> GetAllPersons()
        {
            return Ok(await _context.Persons.ToListAsync());

        }
        [HttpGet("{id}/interests")]//Get all interests connected to one person throu PersonInterest-table
        public async Task<ActionResult<IEnumerable<Interest>>> GetInterestForPerson(int id)
        {
            var interests = await _context.PersonInterests
                .Where(pi => pi.PersonId == id)//Find correct person
                .Include(pi => pi.Interest)//Get related Interest-objects
                .Select(pi => pi.Interest)//Return only relevant Interests
                .ToListAsync();

            return interests;
        }
        [HttpPost("{id}/interest/{interestId}")]//Add interest to a spefic person
        public async Task<IActionResult> AddInterests(int id, int interestId)
        {
            var exists = await _context.PersonInterests//Check if Interest already exists
                .AnyAsync(pi => pi.PersonId == id && pi.InterestId == interestId);
            if (exists) return BadRequest("Intresset finns redan tillagt");//Error message

            var pi = new PersonInterest //Create new connection between person and interest.
            {
                PersonId = id,
                InterestId = interestId
            };
            _context.PersonInterests.Add(pi);
            await _context.SaveChangesAsync();

            return Ok();
        }
      
    }
}

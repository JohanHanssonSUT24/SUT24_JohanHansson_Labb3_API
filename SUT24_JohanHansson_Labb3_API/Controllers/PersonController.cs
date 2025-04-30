using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SUT24_JohanHansson_Labb3_API.Controllers.Data;
using SUT24_JohanHansson_Labb3_API.Models;
using SUT24_JohanHansson_Labb3_API.Models.DTOs;

namespace SUT24_JohanHansson_Labb3_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly ApiDbContext _context;

        public PersonController(ApiDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Person>>> GetAllPersons()
        {
            return Ok(await _context.Persons.ToListAsync());

        }
        [HttpGet("{id}/interests")]
        public async Task<ActionResult<IEnumerable<Interest>>> GetInterestForPerson(int id)
        {
            var interests = await _context.PersonInterests
                .Where(pi => pi.PersonId == id)
                .Include(pi => pi.Interest)
                .Select(pi => pi.Interest)
                .ToListAsync();

            return interests;
        }
        [HttpPost("{id}/interest/{interestId}")]
        public async Task<IActionResult> AddInterests(int id, int interestId)
        {
            var exists = await _context.PersonInterests
                .AnyAsync(pi => pi.PersonId == id && pi.InterestId == interestId);
            if (exists) return BadRequest("Intresset finns redan tillagt");

            var pi = new PersonInterest
            {
                PersonId = id,
                InterestId = interestId
            };
            _context.PersonInterests.Add(pi);
            await _context.SaveChangesAsync();

            return Ok();
        }
        //[HttpGet("{id}/links")]
        //public async Task<ActionResult<IEnumerable<string>>> GetLinks(int id)
        //{
        //    var links = await _context.Links
        //        .Where(l => l.PersonInterestId == id)
        //        .Select(l => l.Url)
        //        .ToListAsync();

        //    return Ok(links);
        //}
        //[HttpPost("{personId}/interest/{interestId}/links")]
        //public async Task<IActionResult> AddLink(int personId, int interestId, [FromBody] string url)
        //{
        //    var pi = await _context.PersonInterests
        //        .FirstOrDefaultAsync(pi => pi.PersonId == personId && pi.InterestId == interestId);

        //    if (pi == null) return NotFound("Kopplingen finns inte.");

        //    var link = new Link
        //    {
        //        Url = url,
        //        PersonInterestId = pi.Id,
                
        //    };

        //    _context.Links.Add(link);
        //    await _context.SaveChangesAsync();

        //    var linkDto = new LinkDto(link.Id, link.Url);
        //    return Ok(linkDto);
        //}
    }
}

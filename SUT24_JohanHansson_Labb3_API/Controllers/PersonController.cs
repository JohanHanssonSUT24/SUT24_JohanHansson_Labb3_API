using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SUT24_JohanHansson_Labb3_API.Controllers.Data;
using SUT24_JohanHansson_Labb3_API.Models;

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
            var doesExist = await _context.PersonInterests.FindAsync(id, interestId);
            if (doesExist != null) return BadRequest("Intresset finns redan tillagt");

            var pi = new PersonInterest
            {
                PersonId = id,
                InterestId = interestId
            };
            _context.PersonInterests.Add(pi);
            await _context.SaveChangesAsync();

            return Ok();
        }
        [HttpGet("{id}/links")]
        public async Task<ActionResult<IEnumerable<string>>> GetLinks(int id)
        {
            var links = await _context.Links
                .Where(l => l.PersonId == id)
                .Select(l => l.Url)
                .ToListAsync();

            return links;
        }
        [HttpPost("{id}/interest/{interestId}/links")]
        public async Task<IActionResult> AddLink(int id, int interestId, [FromBody] string url)
        {
            var pi = await _context.PersonInterests.FindAsync(id, interestId);
            if (pi == null) return NotFound("Kopplingen finns inte.");

            var link = new Link
            {
                Url = url,
                PersonId = id,
                InterestId = interestId
            };

            _context.Links.Add(link);
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SUT24_JohanHansson_Labb3_API.Controllers.Data;
using SUT24_JohanHansson_Labb3_API.Models;

namespace SUT24_JohanHansson_Labb3_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LinksController : ControllerBase
    {
        private readonly ApiDbContext _context;

        public LinksController(ApiDbContext context)
        {
            _context = context;
        }

        [HttpGet("person/{personId}")]
        public async Task<ActionResult<IEnumerable<Link>>> GetLinks(int personId)
        {
            return await _context.Links
                .Where(l => l.PersonId == personId)
                .ToListAsync();
        }
        [HttpPost]
        public async Task<ActionResult<Link>> AddLink(Link link)
        {
            var personInterest = await _context.PersonInterests
                .FindAsync(link.PersonId, link.InterestId);
            if(personInterest == null)
            {
                return BadRequest("Personen är har inte detta intresset.");
            }

            _context.Links.Add(link);
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}

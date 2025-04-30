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
    public class LinksController : ControllerBase
    {
        private readonly ApiDbContext _context;

        public LinksController(ApiDbContext context)
        {
            _context = context;
        }

        [HttpGet("person/{personId}")]
        public async Task<ActionResult<IEnumerable<LinkDto>>> GetLinksForPerson(int personId)
        {
            var links = await _context.Links
                .Include(l => l.PersonInterest)
                .Where(l => l.PersonInterest.PersonId == personId)
                .Select(l => new LinkDto(l.Id, l.Url))
                .ToListAsync();
            return Ok(links);
         
        }
        [HttpPost]
        public async Task<ActionResult<Link>> AddLink(CreateLinkRequest request)
        {
            var pi = await _context.PersonInterests
                .FirstOrDefaultAsync(pi => pi.PersonId == request.PersonId && pi.InterestId == request.InterestId);
            if(pi == null)
            {
                return BadRequest("Personen har inte detta intresset.");
            }
            var newLink = new Link()
            {
                Url = request.Url,
                PersonInterestId = pi.Id

            };
            _context.Links.Add(newLink);
            await _context.SaveChangesAsync();
            return Ok(newLink);
        }

    }
}

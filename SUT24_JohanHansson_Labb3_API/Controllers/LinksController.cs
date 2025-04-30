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
    public class LinksController : ControllerBase
    {
        private readonly ApiDbContext _context;

        public LinksController(ApiDbContext context)
        {
            _context = context;
        }

        [HttpGet("person/{personId}")]//Get all links connected to a persons interests.
        public async Task<ActionResult<IEnumerable<LinkDto>>> GetLinksForPerson(int personId)
        {
            var links = await _context.Links 
                .Include(l => l.PersonInterest) //Load PersonInterest data
                .Where(l => l.PersonInterest.PersonId == personId) //Filter to match PersonId
                .Select(l => new LinkDto(l.Id, l.Url))//Get only Id and Url from DTO
                .ToListAsync();
            return Ok(links);
         
        }
        [HttpPost]//Add new link connected to a persons interest.
        public async Task<ActionResult<LinkDto>> AddLink(CreateLinkRequest request)
        {
            var pi = await _context.PersonInterests//Find PersonInterest that matches entered PersonId and InterestId
                .FirstOrDefaultAsync(pi => pi.PersonId == request.PersonId && pi.InterestId == request.InterestId);
            if(pi == null)
            {
                return BadRequest("Personen har inte detta intresset.");//Error message if match not found.
            }
            var newLink = new Link()
            {
                Url = request.Url,
                PersonInterestId = pi.Id

            };
            _context.Links.Add(newLink);
            await _context.SaveChangesAsync();

            var linkDto = new LinkDto(newLink.Id, newLink.Url);//Create variable to be able to re-use DTO
            return Ok(linkDto);
        }

    }
}

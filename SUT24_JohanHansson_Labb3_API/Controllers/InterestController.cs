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
    public class InterestController : ControllerBase
    {
        private readonly ApiDbContext _context;

        public InterestController(ApiDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Interest>>> GetAllInterest()
        {
            return Ok(await _context.Interests.ToListAsync());
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Interest>> GetInterestById(int id)
        {
            var interest = await _context.Interests.FindAsync(id);
            if (interest == null) return NotFound();
            return Ok(interest);
        }
        [HttpPost]
        public async Task<ActionResult<Interest>> CreateInterest([FromBody] CreateInterestRequest request)
        {
            var interest = new Interest
            {
                Title = request.Title,
                Description = request.Description
            };
            _context.Interests.Add(interest);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetInterestById), new { id = interest.Id}, interest);
        }
    }
}

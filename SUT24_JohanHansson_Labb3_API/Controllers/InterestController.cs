using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SUT24_JohanHansson_Labb3_API.Controllers.Data;
using SUT24_JohanHansson_Labb3_API.Models;

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
            return await _context.Interests.ToListAsync();
        }
        [HttpPost]
        public async Task<ActionResult<Interest>> CreateInterest(Interest interest)
        {
            _context.Interests.Add(interest);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetAllInterest), new { id = interest.Id}, interest);
        }
    }
}

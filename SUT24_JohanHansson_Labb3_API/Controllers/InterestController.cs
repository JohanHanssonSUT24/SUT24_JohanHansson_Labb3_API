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
    public class InterestController : ControllerBase
    {
        private readonly ApiDbContext _context;

        public InterestController(ApiDbContext context)
        {
            _context = context;
        }

        [HttpGet]//Get all interests from db.
        public async Task<ActionResult<IEnumerable<Interest>>> GetAllInterest()
        {
            return Ok(await _context.Interests.ToListAsync());//Return all interests async with a 200 status
        }
        [HttpGet("{id}")]//Get seperate interests based on Id.
        public async Task<ActionResult<Interest>> GetInterestById(int id)
        {
            var interest = await _context.Interests.FindAsync(id);//Find interest based on id. If found return OK.
            if (interest == null) return NotFound();
            return Ok(interest);
        }
        [HttpPost]//Create a new interest
        public async Task<ActionResult<Interest>> CreateInterest([FromBody] CreateInterestRequest request)//Creats interestobject with request from DTO
        {
            var interest = new Interest
            {
                Title = request.Title,
                Description = request.Description
            };
            _context.Interests.Add(interest);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetInterestById), new { id = interest.Id}, interest);//Returns a 201 Created with link
        }
    }
}

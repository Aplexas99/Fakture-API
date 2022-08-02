using FaktureAPI.Data;
using FaktureAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FaktureAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PartnerController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public PartnerController(ApplicationContext context) => _context = context;


        [HttpGet]
        public async Task<IEnumerable<Partner>> Get() => await _context.Partners.ToListAsync();
        
        [HttpGet("id")]
        [ProducesResponseType(typeof(Partner), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(int id)
        {
            var partner = await _context.Partners.FindAsync();
            return partner == null ? NotFound() : Ok(partner);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> Create(Partner partner)
        {
            await _context.Partners.AddAsync(partner);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = partner.Id }, partner);
        }


        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<IActionResult> Update(int id, Partner partner)
        {
            if (id != partner.Id) return BadRequest();

            _context.Entry(partner).State = EntityState.Modified;   
            await _context.SaveChangesAsync();

            return NoContent();
        }

    }
}

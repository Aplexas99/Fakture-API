using FaktureAPI.Data;
using FaktureAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FaktureAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BillBodyController : ControllerBase
    {

        private readonly ApplicationContext _context;

        public BillBodyController(ApplicationContext context) => _context = context;


        [HttpGet]
        public async Task<IEnumerable<BillBody>> Get() => await _context.BillBodies.ToListAsync();

        [HttpGet("id")]
        [ProducesResponseType(typeof(BillBody), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(int id)
        {
            var billBody = await _context.BillBodies.FindAsync();
            return billBody == null ? NotFound() : Ok(billBody);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> Create(BillBody billBody)
        {
            await _context.BillBodies.AddAsync(billBody);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = billBody.Id }, billBody);
        }


        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<IActionResult> Update(int id, BillBody billBody)
        {
            if (id != billBody.Id) return BadRequest();

            _context.Entry(billBody).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<IActionResult> Delete(int id)
        {
            var billBodyToDelete = await _context.BillBodies.FindAsync(id);

            if (billBodyToDelete == null) return NotFound();

            _context.BillBodies.Remove(billBodyToDelete);
            await _context.SaveChangesAsync();
            return NoContent();
        }

    }
}

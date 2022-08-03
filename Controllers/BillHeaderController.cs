using FaktureAPI.Data;
using FaktureAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FaktureAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BillHeaderController : ControllerBase
    {

        private readonly ApplicationContext _context;

        public BillHeaderController(ApplicationContext context) => _context = context;


        [HttpGet]
        public async Task<IEnumerable<BillHeader>> Get() => await _context.BillHeaders.ToListAsync();

        [HttpGet("id")]
        [ProducesResponseType(typeof(BillHeader), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(int id)
        {
            var billHeader = await _context.BillHeaders.FindAsync();
            return billHeader == null ? NotFound() : Ok(billHeader);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> Create(BillHeader billHeader)
        {
            await _context.BillHeaders.AddAsync(billHeader);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = billHeader.Id }, billHeader);
        }


        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<IActionResult> Update(int id, BillHeader billHeader)
        {
            if (id != billHeader.Id) return BadRequest();

            _context.Entry(billHeader).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<IActionResult> Delete(int id)
        {
            var billHeaderToDelete = await _context.BillHeaders.FindAsync(id);

            if (billHeaderToDelete == null) return NotFound();

            _context.BillHeaders.Remove(billHeaderToDelete);
            await _context.SaveChangesAsync();
            return NoContent();
        }


    }
}

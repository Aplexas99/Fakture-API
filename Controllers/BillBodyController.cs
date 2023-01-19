using AutoMapper;
using FaktureAPI.Data;
using FaktureAPI.DTOs;
using FaktureAPI.Models;
using FaktureAPI.Repository;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FaktureAPI.Controllers
{
    [EnableCors("CorsPolicy")]
    [Route("api/[controller]")]
    [ApiController]
    public class BillBodyController : ControllerBase
    {

        private IRepositoryWrapper _repository;
        private IMapper _mapper;

        
        public BillBodyController(IRepositoryWrapper repository, IMapper mapper)
        {

            _repository = repository;
            _mapper = mapper;
        }


        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var billBodies =  await _repository.BillBody.GetAll();

                var billBodiesResult = _mapper.Map<IEnumerable<BillBodyDTO>>(billBodies);
                

                return Ok(billBodiesResult);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpGet("{id}", Name = "BillBodyById")]
        [ProducesResponseType(typeof(BillBody), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var billbody = await _repository.BillBody.GetById(id);
                if (billbody is null)
                {
                    
                    return NotFound();
                }
                else
                {
                    var billBodyResult = _mapper.Map<BillBodyDTO>(billbody);
                    return Ok(billBodyResult);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> Create(BillBody billBody)
        {
            var newBody = _mapper.Map<BillBody>(billBody);

            _repository.BillBody.CreateBody(newBody);
            await _repository.SaveAsync();

            return CreatedAtRoute(nameof(GetById), new { id = newBody.Id }, newBody);
        }


        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<IActionResult> Update(int id, [FromBody]BillBodyForUpdateDTO billBody)
        {
            
            var body = await _repository.BillBody.GetById(id);

            _mapper.Map(billBody, body);

            _repository.BillBody.UpdateBody(body);
            await _repository.SaveAsync();

    
            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<IActionResult> Delete(int id)
        {
            var billBodyToDelete = await _repository.BillBody.GetById(id);

            if (billBodyToDelete == null) return NotFound();

            _repository.BillBody.DeleteBody(billBodyToDelete);

            await _repository.SaveAsync();

            return NoContent();
        }

    }
}

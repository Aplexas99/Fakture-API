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
    public class BillHeaderController : ControllerBase
    {

        private IRepositoryWrapper _repository;
        private IMapper _mapper;

        public BillHeaderController(IRepositoryWrapper repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

      

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var billHeaders = await _repository.BillHeader.GetAll();

                var billHeadersResult = _mapper.Map<IEnumerable<BillHeaderDTO>>(billHeaders);

                return Ok(billHeadersResult);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpGet("{id}", Name= "BillHeaderById")]
        [ProducesResponseType(typeof(BillHeader), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var billheader = await _repository.BillHeader.GetById(id);
                if (billheader is null)
                {

                    return NotFound();
                }
                else
                {
                    var billHeaderResult = _mapper.Map<BillHeaderDTO>(billheader);
                    return Ok(billHeaderResult);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
        }


        

        [HttpGet("BodiesWithHeaderId")]
        [ProducesResponseType(typeof(BillHeader), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<List<BillBody>> GetBillBodiesByHeaderId(int headerId)
        {
            List<BillBody> billBodies = new List<BillBody>();
            IEnumerable<BillBody> bodies = await _repository.BillBody.GetBillBodiesByBillHeaderId(headerId);

            foreach (var body in bodies)
            {
                billBodies.Add(body);
            }
            return billBodies;
        }


        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> Create(BillHeader billHeader)
        {
            try
            {
                if (billHeader is null)
                {
                    return BadRequest("BillHeader object is null");
                }

                if (!ModelState.IsValid)
                {
                    return BadRequest("Invalid model object");
                }

                var newHeader = _mapper.Map<BillHeader>(billHeader);

                _repository.BillHeader.Create(newHeader);
                await _repository.SaveAsync();

                return CreatedAtRoute("BillHeaderById", new { id = newHeader.Id }, newHeader);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<IActionResult> Update(int id, [FromBody] BillHeaderForUpdateDTO billHeader)
        {
            try
            {
                if (billHeader is null)
                {
                    return BadRequest("BillHeader object is null");
                }

                if (!ModelState.IsValid)
                {
                    return BadRequest("Invalid model object");
                }

                var header = await _repository.BillHeader.GetById(id);

                _mapper.Map(billHeader, header);

                _repository.BillHeader.Update(header);
                await _repository.SaveAsync();

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var header = await _repository.BillHeader.GetById(id);

                if (header is null)
                {
                    return NotFound();
                }

                _repository.BillHeader.Delete(header);
                await _repository.SaveAsync();

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
        }
    }
}

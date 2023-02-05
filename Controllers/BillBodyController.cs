using AutoMapper;
using FaktureAPI.Data;
using FaktureAPI.DTOs;
using FaktureAPI.Logger;
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

        private readonly ILoggerManager _logger;
        
        public BillBodyController(IRepositoryWrapper repository, IMapper mapper, ILoggerManager logger)
        {

            _repository = repository;
            _mapper = mapper;
            _logger = logger;
        }


        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var billBodies =  await _repository.BillBody.GetAll();

                if (billBodies is null)
                {
                    _logger.LogError("BillBody is null");
                    return NotFound();
                }
                else
                {
                    _logger.LogInfo($"Returned all bill bodies");
                    var billBodiesResult = _mapper.Map<IEnumerable<BillBodyDTO>>(billBodies);


                    return Ok(billBodiesResult);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError("Something went wrong inside GetAllBillBodies action: {ex.Message}");
                return StatusCode(500, "Internal server error");
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
                    _logger.LogError($"BillBody with id: {id}, hasn't been found in db.");
                    return BadRequest("BillBody is null");
                }
                else
                {
                    _logger.LogInfo($"Returned BillBody with id:{id}");
                    var billBodyResult = _mapper.Map<BillBodyDTO>(billbody);
                    return Ok(billBodyResult);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError("Something went wrong inside BillBody.GetById");
                return StatusCode(500,ex.Message);
            }
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> Create(BillBodyDTO billBody)
        {
            try
            {

                if (billBody is null)
                {
                    _logger.LogError("Billbody is null");
                    return BadRequest("Billbody is null");
                }
                if (!ModelState.IsValid)
                {
                    _logger.LogError("Invalid Billbody object sent from client");
                    return BadRequest("Invalid model object");

                }

                var newBody = _mapper.Map<BillBody>(billBody);

                _repository.BillBody.CreateBody(newBody);
                await _repository.SaveAsync();

                var createdBody = _mapper.Map<BillBodyDTO>(newBody);
                _logger.LogInfo("Billbody created");
                return CreatedAtRoute("BillBodyById", new { id = newBody.Id }, createdBody);


            }
            catch (Exception ex)
            {
                _logger.LogError("Something went wrong inside BillBody Create()");
                return StatusCode(500, ex.Message);
            }
           }


        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<IActionResult> Update(int id, [FromBody]BillBodyForUpdateDTO billBody)
        {
            try { 
            
                var body = await _repository.BillBody.GetById(id);
                if(body == null)
                {
                    _logger.LogError("BillBody is null");
                    return BadRequest("BillBody is null");
                }
                if (!ModelState.IsValid)
                {
                    _logger.LogError("Invalid BillBody model");
                    return BadRequest("Invalid BillBody model");
                }
                _mapper.Map(billBody, body);

                _repository.BillBody.UpdateBody(body);
                await _repository.SaveAsync();

                _logger.LogInfo($"Updated BillBody with id: {id}");

                return NoContent();
            }
            catch(Exception ex)
            {
                _logger.LogError("Something went wrong inside BillBody Update");
                return StatusCode(500, ex.Message);    
            }
            
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<IActionResult> Delete(int id)
        {
            try { 
            
                var billBodyToDelete = await _repository.BillBody.GetById(id);

            if (billBodyToDelete == null) {
                _logger.LogError("Billbody wasn't found in database");
                return NotFound();
            }
                _repository.BillBody.DeleteBody(billBodyToDelete);

                await _repository.SaveAsync();
                _logger.LogInfo($"Deleted Billbody with id: {id}");
                return NoContent();
            }
            catch(Exception ex)
            {
                _logger.LogError("Something went wrong inside BillBody Delete()");
                return StatusCode(500, ex.Message);
            }
        }

    }
}

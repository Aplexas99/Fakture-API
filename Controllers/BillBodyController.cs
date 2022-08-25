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
                

                return Ok(billBodies);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    /*    [HttpGet("id")]
        [ProducesResponseType(typeof(BillBody), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
      */ 

    }
}

using AutoMapper;
using FaktureAPI.Data;
using FaktureAPI.DTOs;
using FaktureAPI.Models;
using FaktureAPI.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FaktureAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PartnerController : ControllerBase
    {
        private IRepositoryWrapper _repository;
        private IMapper _mapper;

        public PartnerController(IRepositoryWrapper repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var partners = await _repository.Partner.GetAll();

                var partnersResult = _mapper.Map<IEnumerable<PartnerDTO>>(partners);

                return Ok(partnersResult);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}", Name = "PartnerById")]
        [ProducesResponseType(typeof(Partner), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var partner = await _repository.Partner.GetById(id);
                if (partner is null)
                {
                    return NotFound();
                }
                else
                {
                    var partnerResult = _mapper.Map<PartnerDTO>(partner);
                    return Ok(partnerResult);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

            [HttpPost]
        public async Task<IActionResult> CreatePartner(Partner partner)
        {
            try
            {
                if (partner is null)
                {
                    return BadRequest("Partner object is null");
                }
                if (!ModelState.IsValid)
                {
                    return BadRequest("Invalid model object");
                }

                var newPartner = _mapper.Map<Partner>(partner);

                _repository.Partner.CreatePartner(newPartner);
                await _repository.SaveAsync();

                return CreatedAtRoute("PartnerById", new { id = newPartner.Id }, newPartner);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePartner(int id, [FromBody] PartnerForUpdateDTO partner)
        {
            try
            {
                if (partner is null)
                {
                    return BadRequest("Partner object is null");
                }
                if (!ModelState.IsValid)
                {
                    return BadRequest("Invalid model object");
                }

                var partnerEntity = await _repository.Partner.GetById(id);
                if (partnerEntity is null)
                {
                    return NotFound();
                }

                _mapper.Map(partner, partnerEntity);

                _repository.Partner.UpdatePartner(partnerEntity);
                await _repository.SaveAsync();

                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePartner(int id)
        {
            try
            {
                var partner = await _repository.Partner.GetById(id);
                if (partner is null)
                {
                    return NotFound();
                }

                _repository.Partner.DeletePartner(partner);
                await _repository.SaveAsync();

                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        
        


    }
}

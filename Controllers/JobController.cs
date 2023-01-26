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
    public class JobController : ControllerBase
    {
        private IRepositoryWrapper _repository;
        private IMapper _mapper;

        public JobController(IRepositoryWrapper repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var jobs = await _repository.Job.GetAll();

                var jobsResult = _mapper.Map<IEnumerable<JobDTO>>(jobs);

                return Ok(jobsResult);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}", Name = "JobById")]
        [ProducesResponseType(typeof(Job), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var job = await _repository.Job.GetById(id);
                if (job is null)
                {
                    return NotFound();
                }
                else
                {
                    var jobResult = _mapper.Map<JobDTO>(job);
                    return Ok(jobResult);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

            [HttpPost]
        public async Task<IActionResult> CreateJob(Job job)
        {
            try
            {
                if (job is null)
                {
                    return BadRequest("Job object is null");
                }
                if (!ModelState.IsValid)
                {
                    return BadRequest("Invalid model object");
                }

                var newJob = _mapper.Map<Job>(job);

                _repository.Job.CreateJob(newJob);
                await _repository.SaveAsync();

                return CreatedAtRoute("JobById", new { id = newJob.Id }, newJob);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateJob(int id, [FromBody] JobForUpdateDTO job)
        {
            try
            {
                if (job is null)
                {
                    return BadRequest("Job object is null");
                }
                if (!ModelState.IsValid)
                {
                    return BadRequest("Invalid model object");
                }

                var jobEntity = await _repository.Job.GetById(id);
                if (jobEntity is null)
                {
                    return NotFound();
                }

                _mapper.Map(job, jobEntity);

                _repository.Job.UpdateJob(jobEntity);
                await _repository.SaveAsync();

                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteJob(int id)
        {
            try
            {
                var job = await _repository.Job.GetById(id);
                if (job is null)
                {
                    return NotFound();
                }

                _repository.Job.DeleteJob(job);
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

using Microsoft.AspNetCore.Mvc;

using Microsoft.AspNetCore.Authorization;
using System.Data;
using MediatR;
using Application.Operations.Jobs.Commands;
using Application.DTOs.Respponces;
using Application.Operations.Jobs.Queries;
using Application.Operations.Managers.Commands;

namespace ServiceStation.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobController : ControllerBase
    {
        private IMediator Mediator;

        public JobController(IMediator mediator)
        {
            Mediator = mediator;
        }


        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            await Mediator.Send(new DeleteJobCommand { Id = id });

            return NoContent();
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Create(CreateJobCommand comand)
        {
            await Mediator.Send(comand);
            return NoContent();

        }




        //GET: api/jobs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<JobDTO>>> GetAllAsync()
        {
            try
            {
                var results = await Mediator.Send(new GetJobsQuery());


                return Ok(results);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "вот так вот!");
            }
        }
        //GET: api/jobs
        [HttpGet("{id}")]
        public async Task<ActionResult<JobDTO>> GetByIdAsync(int id)
        {
            try
            {
                var results = await Mediator.Send(new GetJobByIdQuery() {Id = id });


                return Ok(results);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "вот так вот!");
            }
        }

        [HttpPut]
        public async Task Update(UpdateJobCommand comand)
        {

            try
            {
                await Mediator.Send(comand);
               
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }








        /*
         //GET: api/jobs/Id
         [Authorize]
         [HttpGet("{id}")]
         public async Task<ActionResult<JobResponse>> GetByIdAsync(int id)
         {
             try
             {
                 var result = await _UnitOfBisnes._JobService.GetByIdAsync(id);
                 if (result == null)
                 {
                     _logger.LogInformation($"Івент із Id: {id}, не був знайдейний у базі даних");
                     return NotFound();
                 }
                 else
                 {
                     _logger.LogInformation($"Отримали івент з бази даних!");
                     return Ok(result);
                 }

             }
             catch (Exception ex)
             {
                 _logger.LogError($"Транзакція сфейлилась! Щось пішло не так у методі GetAllEventsAsync() - {ex.Message}");
                 return StatusCode(StatusCodes.Status500InternalServerError, "вот так вот!");
             }
         }

         //GET: api/jobs/Id
         [Authorize]
         [HttpGet("user/{id}")]
         public async Task<ActionResult<ClientsJobsResponse>> GetByUserIdAsync(int id)
         {
             try
             {
                 var result = await _UnitOfBisnes._JobService.GetAllClientsJobsAsync(id);
                 if (result == null)
                 {
                     _logger.LogInformation($"Івент із Id: {id}, не був знайдейний у базі даних");
                     return NotFound();
                 }
                 else
                 {
                     _logger.LogInformation($"Отримали івент з бази даних!");
                     return Ok(result);
                 }

             }
             catch (Exception ex)
             {
                 _logger.LogError($"Транзакція сфейлилась! Щось пішло не так у методі GetAllEventsAsync() - {ex.Message}");
                 return StatusCode(StatusCodes.Status500InternalServerError, "вот так вот!");
             }
         }
         //POST: api/jobs
         *//*  [HttpPost]
           public async Task<ActionResult> PostAsync([FromBody] JobRequest job)
           {
               try
               {
                   if (job == null)
                   {
                       _logger.LogInformation($"Ми отримали пустий json зі сторони клієнта");
                       return BadRequest("Обєкт івенту є null");
                   }
                   if (!ModelState.IsValid)
                   {
                       _logger.LogInformation($"Ми отримали некоректний json зі сторони клієнта");
                       return BadRequest("Обєкт івенту є некоректним");
                   }
                   await _UnitOfBisnes._JobService.PostAsync(job);
                   return StatusCode(StatusCodes.Status201Created);
               }
               catch (Exception ex)
               {
                   _logger.LogError($"Транзакція сфейлилась! Щось пішло не так у методі PostAsync - {ex.Message}");
                   return StatusCode(StatusCodes.Status500InternalServerError, "вот так вот!");
               }
           }*//*
         //POST: api/jobs
         [Authorize]
         [HttpPost]
         public async Task<ActionResult> PostNewAsync([FromBody] NewJobRequest job)
         {
             try
             {
                 if (job == null)
                 {
                     _logger.LogInformation($"Ми отримали пустий json зі сторони клієнта");
                     return BadRequest("Обєкт івенту є null");
                 }
                 if (!ModelState.IsValid)
                 {
                     _logger.LogInformation($"Ми отримали некоректний json зі сторони клієнта");
                     return BadRequest("Обєкт івенту є некоректним");
                 }
                 await _UnitOfBisnes._JobService.PostNewJobAsync(job);
                 return StatusCode(StatusCodes.Status201Created);
             }
             catch (Exception ex)
             {
                 _logger.LogError($"Транзакція сфейлилась! Щось пішло не так у методі PostAsync - {ex.Message}");
                 return StatusCode(StatusCodes.Status500InternalServerError, "вот так вот!");
             }
         }

         //POST: api/jobs/id
         [Authorize]
         [HttpPut("{id}")]
         public async Task<ActionResult> UpdateAsync(int id, [FromBody] JobRequest job)
         {
             try
             {
                 if (job == null)
                 {
                     _logger.LogInformation($"Ми отримали пустий json зі сторони клієнта");
                     return BadRequest("Обєкт івенту є null");
                 }
                 if (!ModelState.IsValid)
                 {
                     _logger.LogInformation($"Ми отримали некоректний json зі сторони клієнта");
                     return BadRequest("Обєкт івенту є некоректним");
                 }
                 job.Id = id;

                 await _UnitOfBisnes._JobService.UpdateAsync(id, job);
                 return StatusCode(StatusCodes.Status204NoContent);
             }
             catch (Exception ex)
             {
                 _logger.LogError($"Транзакція сфейлилась! Щось пішло не так у методі PostAsync - {ex.Message}");
                 return StatusCode(StatusCodes.Status500InternalServerError, "вот так вот!");
             }
         }*/

        //GET: api/jobs/Id
        /*  [Authorize]
          [HttpDelete("{id}")]
          public async Task<ActionResult> DeleteByIdAsync(int id)
          {
              try
              {


                  return NoContent();
              }
              catch (Exception ex)
              {
                  _logger.LogError($"Транзакція сфейлилась! Щось пішло не так у методі GetAllAsync() - {ex.Message}");
                  return StatusCode(StatusCodes.Status500InternalServerError, "вот так вот!");
              }
          }*/

    }
}

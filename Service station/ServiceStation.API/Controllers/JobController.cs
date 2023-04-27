﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ServiceStation.DAL.Entities;
using ServiceStation.DAL.Repositories.Contracts;
using ServiceStation.BAL.Services;
using ServiceStation.BAL.Services.Interfaces;

namespace ServiceStation.API.Controllers
{     
    [Route("api/[controller]")]
    [ApiController]
    public class JobController : ControllerBase
    {

        private IJobService _JobService;

        private readonly ILogger<JobController> _logger;
            private IUnitOfWork _ADOuow;
            public JobController(
                ILogger<JobController> logger,
                IUnitOfWork ado_unitofwork,
                 IJobService JobService
                )
            {
                _logger = logger;
                _ADOuow = ado_unitofwork;
            _JobService = JobService;
            }

            //GET: api/jobs
            [HttpGet]
            public async Task<ActionResult<IEnumerable<Job>>> GetAllEventsAsync()
            {
                try
                {
                var results = await _JobService.GetAllAsync();


                    _logger.LogInformation($"Отримали всі івенти з бази даних!");
                    return Ok(results);
                }
                catch (Exception ex)
                {
                    _logger.LogError($"Транзакція сфейлилась! Щось пішло не так у методі GetAllEventsAsync() - {ex.Message}");
                    return StatusCode(StatusCodes.Status500InternalServerError, "вот так вот!");
                }
            }

        //GET: api/jobs/Id
        [HttpGet("{id}")]
            public async Task<ActionResult<Job>> GetByIdAsync(int id)
            {
                try
                {
                    var result = await _JobService.GetByIdAsync(id);
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
        [HttpPost]
            public async Task<ActionResult> PostJobAsync([FromBody] Job job)
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
                var created_id = await _JobService.PostAsync(job);
                    return StatusCode(StatusCodes.Status201Created);
                }
                catch (Exception ex)
                {
                    _logger.LogError($"Транзакція сфейлилась! Щось пішло не так у методі PostEventAsync - {ex.Message}");
                    return StatusCode(StatusCodes.Status500InternalServerError, "вот так вот!");
                }
            }

        //POST: api/jobs/id
        [HttpPut("{id}")]
            public async Task<ActionResult> UpdateEventAsync(int id, [FromBody] Job job)
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

                await _JobService.UpdateAsync(id, job);
                    return StatusCode(StatusCodes.Status204NoContent);
                }
                catch (Exception ex)
                {
                    _logger.LogError($"Транзакція сфейлилась! Щось пішло не так у методі PostEventAsync - {ex.Message}");
                    return StatusCode(StatusCodes.Status500InternalServerError, "вот так вот!");
                }
            }

        //GET: api/jobs/Id
        [HttpDelete("{id}")]
            public async Task<ActionResult> DeleteByIdAsync(int id)
            {
                try
                {
                    var event_entity = await _JobService.GetByIdAsync(id);
                    if (event_entity == null)
                    {
                        _logger.LogInformation($"Запис із Id: {id}, не був знайдейний у базі даних");
                        return NotFound();
                    }

                    await _JobService.DeleteByIdAsync(id);
                    return NoContent();
                }
                catch (Exception ex)
                {
                    _logger.LogError($"Транзакція сфейлилась! Щось пішло не так у методі GetAllAsync() - {ex.Message}");
                    return StatusCode(StatusCodes.Status500InternalServerError, "вот так вот!");
                }
            }

        }
    }

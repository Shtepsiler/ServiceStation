﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ServiceStation.BAL.Services.Interfaces;
using ServiceStation.DAL.Entities;
using ServiceStation.DAL.Repositories.Contracts;

namespace ServiceStation.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PartController : ControllerBase
    {

        private IUnitOfBisnes _UnitOfBisnes;

        private readonly ILogger<PartController> _logger;
        public PartController(
            ILogger<PartController> logger,
             IUnitOfBisnes UnitOfBisnes
            )
        {
            _logger = logger;
            _UnitOfBisnes = UnitOfBisnes;
        }

        //GET: api/jobs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Part>>> GetAllAsync()
        {
            try
            {
                var results = await _UnitOfBisnes._PartService.GetAllAsync();


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
        public async Task<ActionResult<Part>> GetByIdAsync(int id)
        {
            try
            {
                var result = await _UnitOfBisnes._PartService.GetByIdAsync(id);
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
        public async Task<ActionResult> PostAsync([FromBody] Part part)
        {
            try
            {
                if (part == null)
                {
                    _logger.LogInformation($"Ми отримали пустий json зі сторони клієнта");
                    return BadRequest("Обєкт івенту є null");
                }
                if (!ModelState.IsValid)
                {
                    _logger.LogInformation($"Ми отримали некоректний json зі сторони клієнта");
                    return BadRequest("Обєкт івенту є некоректним");
                }
                var created_id = await _UnitOfBisnes._PartService.PostAsync(part);
                return StatusCode(StatusCodes.Status201Created);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Транзакція сфейлилась! Щось пішло не так у методі PostAsync - {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError, "вот так вот!");
            }
        }

        //POST: api/jobs/id
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateAsync(int id, [FromBody] Part part)
        {
            try
            {
                if (part == null)
                {
                    _logger.LogInformation($"Ми отримали пустий json зі сторони клієнта");
                    return BadRequest("Обєкт івенту є null");
                }
                if (!ModelState.IsValid)
                {
                    _logger.LogInformation($"Ми отримали некоректний json зі сторони клієнта");
                    return BadRequest("Обєкт івенту є некоректним");
                }
                part.Id = id;

                await _UnitOfBisnes._PartService.UpdateAsync(id, part);
                return StatusCode(StatusCodes.Status204NoContent);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Транзакція сфейлилась! Щось пішло не так у методі PostAsync - {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError, "вот так вот!");
            }
        }

        //GET: api/jobs/Id
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteByIdAsync(int id)
        {
            try
            {
                var event_entity = await _UnitOfBisnes._PartService.GetByIdAsync(id);
                if (event_entity == null)
                {
                    _logger.LogInformation($"Запис із Id: {id}, не був знайдейний у базі даних");
                    return NotFound();
                }

                await _UnitOfBisnes._PartService.DeleteByIdAsync(id);
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

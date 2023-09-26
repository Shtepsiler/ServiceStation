﻿using Microsoft.AspNetCore.Mvc;
using ServiceStation.DAL.Entities;

using ServiceStation.BLL.Services.Interfaces;
using ServiceStation.BLL.DTO.Responses;
using ServiceStation.BLL.DTO.Requests;
using Microsoft.AspNetCore.Authorization;

namespace ServiceStation.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ModelController : ControllerBase
    {

        private IUnitOfBisnes _UnitOfBisnes;

        private readonly ILogger<ModelController> _logger;
        public ModelController(
            ILogger<ModelController> logger,
             IUnitOfBisnes UnitOfBisnes
            )
        {
            _logger = logger;
            _UnitOfBisnes = UnitOfBisnes;
        }

        //GET: api/jobs
        [HttpGet]
    

        public async Task<ActionResult<IEnumerable<ModelResponse>>> GetAllAsync()
        {
            try
            {
                var results = await _UnitOfBisnes._ModelService.GetAllAsync();


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
        [Authorize]

        public async Task<ActionResult<ModelResponse>> GetByIdAsync(int id)
        {
            try
            {
                var result = await _UnitOfBisnes._ModelService.GetByIdAsync(id);
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
        [Authorize]

        public async Task<ActionResult> PostAsync([FromBody] ModelRequest manager)
        {
            try
            {
                if (manager == null)
                {
                    _logger.LogInformation($"Ми отримали пустий json зі сторони клієнта");
                    return BadRequest("Обєкт івенту є null");
                }
                if (!ModelState.IsValid)
                {
                    _logger.LogInformation($"Ми отримали некоректний json зі сторони клієнта");
                    return BadRequest("Обєкт івенту є некоректним");
                }
                await _UnitOfBisnes._ModelService.PostAsync(manager);
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
        [Authorize]

        public async Task<ActionResult> UpdateAsync(int id, [FromBody] ModelRequest manager)
        {
            try
            {
                if (manager == null)
                {
                    _logger.LogInformation($"Ми отримали пустий json зі сторони клієнта");
                    return BadRequest("Обєкт івенту є null");
                }
                if (!ModelState.IsValid)
                {
                    _logger.LogInformation($"Ми отримали некоректний json зі сторони клієнта");
                    return BadRequest("Обєкт івенту є некоректним");
                }
                manager.Id = id;

                await _UnitOfBisnes._ModelService.UpdateAsync(id, manager);
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
        [Authorize]

        public async Task<ActionResult> DeleteByIdAsync(int id)
        {
            try
            {
                var event_entity = await _UnitOfBisnes._ModelService.GetByIdAsync(id);
                if (event_entity == null)
                {
                    _logger.LogInformation($"Запис із Id: {id}, не був знайдейний у базі даних");
                    return NotFound();
                }

                await _UnitOfBisnes._ModelService.DeleteByIdAsync(id);
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

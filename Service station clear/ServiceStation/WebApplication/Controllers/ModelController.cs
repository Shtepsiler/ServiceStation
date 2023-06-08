using Application.DTOs.Respponces;
using Application.Operations.Jobs.Queries;
using Application.Operations.Models.Commands;
using Application.Operations.Models.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;

namespace WebApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ModelController : ControllerBase
    {
        public IMediator Mediator { get; }

        public ModelController(IMediator mediator)
        {
            Mediator = mediator;
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            await Mediator.Send(new DeleteModelCommand() {Id = id });
            return NoContent();

        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Create(CreateModelCommand comand)
        {
            await Mediator.Send(comand);
            return NoContent();

        }
        //GET: api/jobs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ModelDTO>>> GetAllAsync()
        {
            try
            {
                var results = await Mediator.Send(new GetModelsQuery());


                return Ok(results);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "вот так вот!");
            }
        }        //GET: api/jobs
        [HttpGet("{id}")]
        public async Task<ActionResult<ModelDTO>> GetByIdAsync(int id)
        {
            try
            {
                var results = await Mediator.Send(new GetModelByIdQuery() { Id = id });


                return Ok(results);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "вот так вот!");
            }
        }
        [HttpPut]
        public async Task Update(UpdateModelCommand comand)
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
    }
}

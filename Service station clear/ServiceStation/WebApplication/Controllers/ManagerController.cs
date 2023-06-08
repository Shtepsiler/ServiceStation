using Application.DTOs.Respponces;
using Application.Operations.Jobs.Queries;
using Application.Operations.Managers.Commands;
using Application.Operations.Managers.Queries;
using Application.Operations.Models.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ManagerController : ControllerBase
    {
        public IMediator Mediator { get; }

        public ManagerController(IMediator mediator)
        {
            Mediator = mediator;
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            await Mediator.Send(new DeleteManagerCommand() { Id = id });
            return NoContent();

        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Create(CreateManagerCommand comand)
        {
            await Mediator.Send(comand);
            return NoContent();

        }
        //GET: api/jobs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ManagerDTO>>> GetAllAsync()
        {
            try
            {
                var results = await Mediator.Send(new GetManagersQuery());


                return Ok(results);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "вот так вот!");
            }
        }        //GET: api/jobs
        [HttpGet("{id}")]
        public async Task<ActionResult<ManagerDTO>> GetByIdAsync(int id)
        {
            try
            {
                var results = await Mediator.Send(new GetManagerByIdQuery() { Id = id });


                return Ok(results);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "вот так вот!");
            }
        }
        [HttpPut]
        public async Task Update(UpdateManagerCommand comand)
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

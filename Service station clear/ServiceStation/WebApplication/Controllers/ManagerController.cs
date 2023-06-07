using Application.Operations.Managers.Commands;
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


    }
}

using Application.DTOs.Respponces;
using Application.Operations.Jobs.Queries;
using Application.Operations.Mechanics.Commands;
using Application.Operations.Mechanics.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;

namespace WebApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MechanicController : ControllerBase
    {
        public IMediator Mediator { get; }

        public MechanicController(IMediator mediator)
        {
            Mediator = mediator;
        }



        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            await Mediator.Send(new DeleteMechanicCommand() {Id = id });
            return NoContent();

        }



        [HttpPost]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Create(CreateMechanicCommand comand)
        {
            await Mediator.Send(comand);
            return NoContent();

        }



        //GET: api/jobs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MechanicDTO>>> GetAllAsync()
        {
            try
            {
                var results = await Mediator.Send(new GetMechanicsQuery());


                return Ok(results);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "вот так вот!");
            }
        }       
        
        
        
        
        //GET: api/jobs
        [HttpGet("{id}")]
        public async Task<ActionResult<MechanicDTO>> GetByIdAsync(int id)
        {
            try
            {
                var results = await Mediator.Send(new GetMechaincByIdQuery() { Id = id });


                return Ok(results);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "вот так вот!");
            }
        }





        [HttpPut]
        public async Task Update(UpdateMechanicCommand comand)
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

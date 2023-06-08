using Application.DTOs.Respponces;
using Application.Operations.Jobs.Queries;
using Application.Operations.Models.Commands;
using Application.Operations.Orders.Commands;
using Application.Operations.Orders.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;

namespace WebApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        public IMediator Mediator { get; }

        public OrderController(IMediator mediator)
        {
            Mediator = mediator;
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            await Mediator.Send(new DeleteOrderCommand() {Id = id });
            return NoContent();

        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Create(CreateOrderCommand comand)
        {
            await Mediator.Send(comand);
            return NoContent();

        }
        //GET: api/jobs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrderDTO>>> GetAllAsync()
        {
            try
            {
                var results = await Mediator.Send(new GetOrdersQuery());


                return Ok(results);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "вот так вот!");
            }
        }        //GET: api/jobs
        [HttpGet("{id}")]
        public async Task<ActionResult<OrderDTO>> GetByIdAsync(int id)
        {
            try
            {
                var results = await Mediator.Send(new GetOrderByIdQuery() { Id = id });


                return Ok(results);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "вот так вот!");
            }
        }
        [HttpPut]
        public async Task Update(UpdateOrderCommand comand)
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

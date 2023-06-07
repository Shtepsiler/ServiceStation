using Application.DTOs.Respponces;
using Application.Operations.Clients.Queries;
using Application.Operations.Jobs.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientsController : ControllerBase
    {      
        private readonly IMediator Mediator;

        public ClientsController(IMediator mediator)
        {
            Mediator = mediator;
        }


        //GET: api/jobs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ClientDTO>>> GetAllAsync()
        {
            try
            {
                var results = await Mediator.Send(new GetClientsQuery());


                return Ok(results);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "вот так вот!");
            }
        }
    }
}

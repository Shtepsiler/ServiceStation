using Application.DTOs.Respponces;
using Application.Operations.Jobs.Queries;
using Application.Operations.Models.Commands;
using Application.Operations.Vendors.Commands;
using Application.Operations.Vendors.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;

namespace WebApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VendorsController : ControllerBase
    {
        public IMediator Mediator { get; }

        public VendorsController(IMediator mediator)
        {
            Mediator = mediator;
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            await Mediator.Send(new DeleteVendorCommand() {Id = id });
            return NoContent();

        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Create(CreateVendorCommand comand)
        {
            await Mediator.Send(comand);
            return NoContent();

        }
        //GET: api/jobs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<VendorDTO>>> GetAllAsync()
        {
            try
            {
                var results = await Mediator.Send(new GetVendorsQuery());


                return Ok(results);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "вот так вот!");
            }
        }        //GET: api/jobs
        [HttpGet("{id}")]
        public async Task<ActionResult<VendorDTO>> GetByIdAsync(int id)
        {
            try
            {
                var results = await Mediator.Send(new GetVendorByIdQuery() { Id = id });


                return Ok(results);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "вот так вот!");
            }
        }

        [HttpPut]
        public async Task Update(UpdateVendorCommand comand)
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

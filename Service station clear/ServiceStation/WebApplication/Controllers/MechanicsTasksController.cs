﻿using Application.Operations.MechanicsTasks.Commands;
using Application.Operations.Models.Commands;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;

namespace WebApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MechanicsTasksController : ControllerBase
    {
        public IMediator Mediator { get; }

        public MechanicsTasksController(IMediator mediator)
        {
            Mediator = mediator;
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            await Mediator.Send(new DeleteMechanicTaskCommand() {Id = id });
            return NoContent();

        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Create(CreateMechanicTaskCommand comand)
        {
            await Mediator.Send(comand);
            return NoContent();

        }


    }
}

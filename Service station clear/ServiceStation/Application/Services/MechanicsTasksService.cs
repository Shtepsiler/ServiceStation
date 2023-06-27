using Application.DTOs.Respponces;
using Application.Interfaces;
using Application.Operations.Jobs.Queries;
using Application.Operations.MechanicsTasks.Commands;
using Application.Operations.MechanicsTasks.Queries;
using Application.Operations.Models.Commands;
using MediatR;
using System.Runtime.CompilerServices;

namespace Application.Services
{

    public class MechanicsTasksService : IMechanicsTasksService
    {
        public IMediator Mediator { get; }

        public MechanicsTasksService(IMediator mediator)
        {
            Mediator = mediator;
        }

        public async Task Delete(int id)
        {
            try
            {
                await Mediator.Send(new DeleteMechanicTaskCommand() { Id = id });
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public async Task Create(CreateMechanicTaskCommand comand)
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

        public async Task<IEnumerable<MechanicsTasksDTO>> GetAllAsync()
        {
            try
            {
                var results = await Mediator.Send(new GetMechanicsTasksQuery());


                return results;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        public async Task<MechanicsTasksDTO> GetByIdAsync(int id)
        {
            try
            {
                var results = await Mediator.Send(new GetMechanicTaskByIdQuery() { Id = id });


                return results;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public async Task Update(UpdateMechanicTaskCommand comand)
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

using Application.DTOs.Respponces;
using Application.Interfaces;
using Application.Operations.Jobs.Queries;
using Application.Operations.Managers.Commands;
using Application.Operations.Managers.Queries;
using Application.Operations.Models.Commands;
using MediatR;

namespace Application.Services
{

    public class ManagerService : IManagerService
    {
        public IMediator Mediator { get; }

        public ManagerService(IMediator mediator)
        {
            Mediator = mediator;
        }


        public async Task Delete(int id)
        {
            await Mediator.Send(new DeleteManagerCommand() { Id = id });

        }

        public async Task Create(CreateManagerCommand comand)
        {
            await Mediator.Send(comand);

        }

        public async Task<IEnumerable<ManagerDTO>> GetAllAsync()
        {
            try
            {
                var results = await Mediator.Send(new GetManagersQuery());


                return results;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public async Task<ManagerDTO> GetByIdAsync(int id)
        {
            try
            {
                var results = await Mediator.Send(new GetManagerByIdQuery() { Id = id });


                return results;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
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

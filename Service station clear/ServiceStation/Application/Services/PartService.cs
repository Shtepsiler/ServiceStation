using Application.DTOs.Respponces;
using Application.Interfaces;
using Application.Operations.Jobs.Queries;
using Application.Operations.Models.Commands;
using Application.Operations.Parts.Commands;
using Application.Operations.Parts.Queries;
using MediatR;


namespace Application.Services
{

    public class PartService : IPartService
    {
        public IMediator Mediator { get; }

        public PartService(IMediator mediator)
        {
            Mediator = mediator;
        }


        public async Task Delete(int id)
        {
            await Mediator.Send(new DeletePartCommand() { Id = id });

        }


        public async Task Create(CreatePartCommand comand)
        {
            await Mediator.Send(comand);

        }


        public async Task<IEnumerable<PartDTO>> GetAllAsync()
        {
            try
            {
                var results = await Mediator.Send(new Application.Operations.Parts.Queries.GetPartsQuery());


                return results;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public async Task<PartDTO> GetByIdAsync(int id)
        {
            try
            {
                var results = await Mediator.Send(new GetPartByIdQuery() { Id = id });


                return results;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task Update(UpdatePartCommand comand)
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

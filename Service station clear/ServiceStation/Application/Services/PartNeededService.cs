using Application.DTOs.Respponces;
using Application.Interfaces;
using Application.Operations.Jobs.Queries;
using Application.Operations.Models.Commands;
using Application.Operations.PartsNeeded.Commands;
using Application.Operations.PartsNeeded.Queries;
using MediatR;


namespace Application.Services
{

    public class PartNeededService : IPartNeededService
    {
        public IMediator Mediator { get; }

        public PartNeededService(IMediator mediator)
        {
            Mediator = mediator;
        }


        public async Task Delete(int id)
        {
            await Mediator.Send(new DeletePartNeededCommand() { Id = id });

        }

        public async Task Create(CreatePartsNeededCommand comand)
        {
            await Mediator.Send(comand);


        }


        public async Task<IEnumerable<PartNeededDTO>> GetAllAsync()
        {
            try
            {
                var results = await Mediator.Send(new GetPartsNeededQuery());


                return results;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public async Task<PartNeededDTO> GetByIdAsync(int id)
        {
            try
            {
                var results = await Mediator.Send(new GetPartNeededByIdQuery() { Id = id });


                return results;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task Update(UpdatePartneededCommand comand)
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

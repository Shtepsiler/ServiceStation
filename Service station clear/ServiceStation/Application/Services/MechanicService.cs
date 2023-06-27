using Application.DTOs.Respponces;
using Application.Interfaces;
using Application.Operations.Jobs.Queries;
using Application.Operations.Mechanics.Commands;
using Application.Operations.Mechanics.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;


namespace Application.Services
{

    public class MechanicService : IMechanicService
    {
        public IMediator Mediator { get; }

        public MechanicService(IMediator mediator)
        {
            Mediator = mediator;
        }



        public async Task Delete(int id)
        {
            try
            {
                await Mediator.Send(new DeleteMechanicCommand() { Id = id });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }




        public async Task Create(CreateMechanicCommand comand)
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



        public async Task<IEnumerable<MechanicDTO>> GetAllAsync()
        {
            try
            {
                var results = await Mediator.Send(new GetMechanicsQuery());


                return results;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }




        public async Task<MechanicDTO> GetByIdAsync(int id)
        {
            try
            {
                var results = await Mediator.Send(new GetMechaincByIdQuery() { Id = id });


                return results;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }





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

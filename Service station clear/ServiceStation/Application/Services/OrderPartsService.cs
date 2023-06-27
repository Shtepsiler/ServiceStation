using Application.DTOs.Respponces;
using Application.Interfaces;
using Application.Operations.Jobs.Queries;
using Application.Operations.Models.Commands;
using Application.Operations.OrderParts.Commands;
using Application.Operations.OrderParts.Queries;
using MediatR;

namespace Application.Services
{

    public class OrderPartsService : IOrderPartsService
    {
        public IMediator Mediator { get; }

        public OrderPartsService(IMediator mediator)
        {
            Mediator = mediator;
        }

        public async Task Delete(int id)
        {
            await Mediator.Send(new DeleteOrderPartCommand() { Id = id });

        }

        public async Task Create(CreateOrderPartCommand comand)
        {
            await Mediator.Send(comand);

        }

        public async Task<IEnumerable<OrderPartDTO>> GetAllAsync()
        {
            try
            {
                var results = await Mediator.Send(new GetOrdersRatrsQuery());


                return results;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public async Task<OrderPartDTO> GetByIdAsync(int id)
        {
            try
            {
                var results = await Mediator.Send(new GetOrderPartByIdQuery() { Id = id });


                return results;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task Update(UpdateOrderPartCommand comand)
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

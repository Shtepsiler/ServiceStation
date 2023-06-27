using Application.DTOs.Respponces;
using Application.Interfaces;
using Application.Operations.Jobs.Queries;
using Application.Operations.Models.Commands;
using Application.Operations.Orders.Commands;
using Application.Operations.Orders.Queries;
using MediatR;


namespace Application.Services
{

    public class OrderService : IOrderService
    {
        public IMediator Mediator { get; }

        public OrderService(IMediator mediator)
        {
            Mediator = mediator;
        }


        public async Task Delete(int id)
        {
            try
            {
                await Mediator.Send(new DeleteOrderCommand() { Id = id });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task Create(CreateOrderCommand comand)
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

        public async Task<IEnumerable<OrderDTO>> GetAllAsync()
        {
            try
            {
                var results = await Mediator.Send(new GetOrdersQuery());


                return results;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public async Task<OrderDTO> GetByIdAsync(int id)
        {
            try
            {
                var results = await Mediator.Send(new GetOrderByIdQuery() { Id = id });


                return results;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
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

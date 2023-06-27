using Application.DTOs.Respponces;
using Application.Interfaces;
using Application.Operations.Clients.Queries;
using Application.Operations.Jobs.Queries;
using MediatR;


namespace Application.Services
{

    public class ClientsService : IClientsService
    {
        private readonly IMediator Mediator;

        public ClientsService(IMediator mediator)
        {
            Mediator = mediator;
        }


        //GET: api/jobs
        public async Task<IEnumerable<ClientDTO>> GetAllAsync()
        {
            try
            {
                var results = await Mediator.Send(new GetClientsQuery());


                return results;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

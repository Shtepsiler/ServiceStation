using Application.DTOs.Respponces;
using Application.Interfaces;
using Application.Operations.Jobs.Queries;
using Application.Operations.Models.Commands;
using Application.Operations.Vendors.Commands;
using Application.Operations.Vendors.Queries;
using MediatR;

namespace Application.Services
{

    public class VendorsService : IVendorsService
    {
        public IMediator Mediator { get; }

        public VendorsService(IMediator mediator)
        {
            Mediator = mediator;
        }



        public async Task Delete(int id)
        {
            await Mediator.Send(new DeleteVendorCommand() { Id = id });

        }


        public async Task Create(CreateVendorCommand comand)
        {
            await Mediator.Send(comand);


        }


        public async Task<IEnumerable<VendorDTO>> GetAllAsync()
        {
            try
            {
                var results = await Mediator.Send(new GetVendorsQuery());


                return results;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public async Task<VendorDTO> GetByIdAsync(int id)
        {
            try
            {
                var results = await Mediator.Send(new GetVendorByIdQuery() { Id = id });


                return results;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


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

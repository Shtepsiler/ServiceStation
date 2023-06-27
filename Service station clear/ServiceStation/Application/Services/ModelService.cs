using Application.DTOs.Respponces;
using Application.Interfaces;
using Application.Operations.Jobs.Queries;
using Application.Operations.Models.Commands;
using Application.Operations.Models.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using System.Runtime.CompilerServices;

namespace Application.Services
{

    public class ModelService : IModelService
    {
        public IMediator Mediator { get; }

        public ModelService(IMediator mediator)
        {
            Mediator = mediator;
        }


        public async Task Delete(int id)
        {
            try
            {
                await Mediator.Send(new DeleteModelCommand() { Id = id });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task Create(CreateModelCommand comand)
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

        public async Task<IEnumerable<ModelDTO>> GetAllAsync()
        {
            try
            {
                var results = await Mediator.Send(new GetModelsQuery());


                return results;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<ModelDTO> GetByIdAsync(int id)
        {
            try
            {
                var results = await Mediator.Send(new GetModelByIdQuery() { Id = id });


                return results;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task Update(UpdateModelCommand comand)
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

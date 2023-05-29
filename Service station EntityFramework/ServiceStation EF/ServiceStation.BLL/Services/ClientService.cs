using AutoMapper;
using ServiceStation.BLL.DTO.Requests;
using ServiceStation.BLL.DTO.Responses;
using ServiceStation.BLL.Services.Interfaces;
using ServiceStation.DAL.Entities;
using ServiceStation.DAL.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceStation.BLL.Services
{
    public class ClientService : IClientService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        public ClientService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task RewokeRefreshToken(string clientMame,string token)
        {
            try
            {
                
                var tok = unitOfWork._TokenRepository.GeTokenByClientName(clientMame);
                if (tok.Result.ClientSecret==token)
                tok.Result.ExpirationDate = DateTime.Now.AddDays(1);
                else
               throw new UnauthorizedAccessException("No valid refresh token");
            }
            catch(Exception ex) { throw ex; }


        }

        public async Task<ClientResponse> GetClientByName(string name)
        {
            try
            {
                return mapper.Map<Client, ClientResponse>(await unitOfWork._ClientManager.FindByNameAsync(name));
            }
            catch (Exception ex) { throw ex; }

        }
 










    }

}

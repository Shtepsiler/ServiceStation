using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using ServiceStation.BLL.DTO.Requests;
using ServiceStation.BLL.DTO.Responses;
using ServiceStation.BLL.Factories.Interfaces;
using ServiceStation.BLL.Services.Interfaces;
using ServiceStation.DAL.Entities;
using ServiceStation.DAL.Exceptions;
using ServiceStation.DAL.Repositories.Contracts;


namespace ServiceStation.BLL.Services
{
    public class IdentityService : IIdentityService
    {
        private readonly IUnitOfWork unitOfWork;

        private readonly IMapper mapper;

        private readonly IJwtSecurityTokenFactory tokenFactory;

        private readonly UserManager<Client> userManager;

        public async Task<JwtResponse> SignInAsync(ClientSignInRequest request)
        {
            var user = await userManager.FindByNameAsync(request.UserName)
                ?? throw new EntityNotFoundException(
                    $"{nameof(Client)} with user name {request.UserName} not found.");

            if (!await userManager.CheckPasswordAsync(user, request.Password))
            {
                throw new EntityNotFoundException("Incorrect username or password.");
            }

            var jwtToken = tokenFactory.BuildToken(user);
            return new() { Token = SerializeToken(jwtToken), ClientId = user.Id };
        }

        public async Task<JwtResponse> SignUpAsync(ClientSignUpRequest request)
        {
            var user = mapper.Map<ClientSignUpRequest, Client>(request);
            var signUpResult = await userManager.CreateAsync(user, request.Password);

            if (!signUpResult.Succeeded)
            {
                string errors = string.Join("\n",
                    signUpResult.Errors.Select(error => error.Description));

                throw new ArgumentException(errors);
            }

            await unitOfWork.SaveChangesAsync();

            var jwtToken = tokenFactory.BuildToken(user);
            return new() { Token = SerializeToken(jwtToken) };
        }

        private static string SerializeToken(JwtSecurityToken jwtToken) =>
            new JwtSecurityTokenHandler().WriteToken(jwtToken);

        public IdentityService(
            IUnitOfWork unitOfWork,
            IMapper mapper,
            IJwtSecurityTokenFactory tokenFactory)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
            this.tokenFactory = tokenFactory;
            userManager = this.unitOfWork._ClientManager;
        }
    }
}

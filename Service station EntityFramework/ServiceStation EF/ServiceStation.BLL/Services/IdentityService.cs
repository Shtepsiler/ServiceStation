using AutoMapper;
using Azure.Core;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Configuration;
using Microsoft.Identity.Client;
using Microsoft.IdentityModel.Tokens;
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

        private readonly UserManager<Client> userManager;

        private readonly ITokenService tokenService;
        private readonly EmailSender emailSender;
        public IdentityService(
        IUnitOfWork unitOfWork,
        IMapper mapper,
        ITokenService tokenService
        )
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
            userManager = this.unitOfWork._ClientManager;
            this.tokenService = tokenService;
        }

        public async Task<JwtResponse> SignInAsync(ClientSignInRequest request)
        {
            var user = await userManager.FindByNameAsync(request.UserName)
                ?? throw new EntityNotFoundException(
                    $"{nameof(Client)} with user name {request.UserName} not found.");

            if (!await userManager.CheckPasswordAsync(user, request.Password))
            {
                throw new EntityNotFoundException("Incorrect username or password.");
            }

            var jwtToken = tokenService.BuildToken(user);
            return new() {Id=user.Id ,Token = tokenService.SerializeToken(jwtToken), ClientName = user.UserName, RefreshToken= tokenService.GetRefreshToken(user.UserName) };
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
            var newClient = await userManager.FindByNameAsync(request.UserName);



            try
            {
              //  var newClient = await userManager.FindByNameAsync(request.UserName);
                var jwtToken = tokenService.BuildToken(user);
            return new() {ClientName = newClient.UserName  , Token = tokenService.SerializeToken(jwtToken), RefreshToken = tokenService.GetRefreshToken(user.UserName) };
            }
            catch (Exception ex) { throw new Exception("database troble"); }
        }


    }
}

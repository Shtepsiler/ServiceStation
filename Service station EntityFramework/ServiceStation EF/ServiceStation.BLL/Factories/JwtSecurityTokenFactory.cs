using ServiceStation.BLL.Configurations;
using ServiceStation.DAL.Entities;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using TeamworkSystem.BusinessLogicLayer.Interfaces;

namespace ServiceStation.BLL.Factories
{
    public class JwtSecurityTokenFactory : IJwtSecurityTokenFactory
    {
        private readonly JwtTokenConfiguration jwtTokenConfiguration;

        public JwtSecurityToken BuildToken(Client client) => new(
            issuer: jwtTokenConfiguration.Issuer,
            audience: jwtTokenConfiguration.Audience,
            claims: GetClaims(client),
            expires: JwtTokenConfiguration.ExpirationDate,
            signingCredentials: jwtTokenConfiguration.Credentials);

        private static List<Claim> GetClaims(Client client) => new()
        {
            new(JwtRegisteredClaimNames.UniqueName, client.UserName),
            new(ClaimTypes.Name, client.UserName),
            new(ClaimTypes.Authentication, client.Id),
        };

        public JwtSecurityTokenFactory(JwtTokenConfiguration jwtTokenConfiguration) =>
            this.jwtTokenConfiguration = jwtTokenConfiguration;
    }
}

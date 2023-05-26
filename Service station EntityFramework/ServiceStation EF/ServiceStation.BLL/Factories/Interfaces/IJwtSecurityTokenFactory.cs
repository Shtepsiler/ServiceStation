using ServiceStation.DAL.Entities;
using System.IdentityModel.Tokens.Jwt;

namespace TeamworkSystem.BusinessLogicLayer.Interfaces
{   
    public interface IJwtSecurityTokenFactory
    {
        JwtSecurityToken BuildToken(Client client);
    }
}

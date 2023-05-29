using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServiceStation.BLL.DTO.Requests;
using ServiceStation.BLL.Services.Interfaces;

namespace ServiceStation.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private IUnitOfBisnes _UnitOfBisnes;

        public ClientController(IUnitOfBisnes unitOfBisnes)
        {
            _UnitOfBisnes = unitOfBisnes;
        }

        [HttpPost("GetAccessTokenByRefreshToken")]
        public async Task<IActionResult> RenewAccessToken([FromBody] string requesttoken)
        {
            try
            {
                var newToken = _UnitOfBisnes._TokenService.GetAccessTokenByRefreshToken(requesttoken);

                return Ok(newToken);
            }
            catch (Exception ex) { throw ex; }


        }






    }
}

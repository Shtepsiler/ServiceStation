using ServiceStation.BLL.DTO.Requests;
using ServiceStation.BLL.DTO.Responses;
using System.Threading.Tasks;

namespace ServiceStation.BLL.Services.Interfaces
{
    public interface IIdentityService
    {
        Task<JwtRtquest> SignInAsync(ClientSignInRequest request);

        Task<JwtRtquest> SignUpAsync(ClientSignUpRequest request);


    //    Task SignUpWihtoutjvtAsync(ClientSignUpRequest request);
    }
}

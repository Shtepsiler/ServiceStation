using BlazorAppForClient.Authentication;
using BlazorAppForClient.Extensions;
using BlazorAppForClient.Interfaces;
using BlazorAppForClient.ViewModels;
using System.Net.Http;
using System.Threading.Tasks;


namespace BlazorAppForClient.Services
{
    public class IdentityService : IIdentityService
    {
        private readonly ApiHttpClient httpClient;

        private readonly ApiAuthenticationStateProvider stateProvider;

        public async Task<JwtViewModel> SignInAsync(UserSignInViewModel viewModel) =>
            await ExecuteRequestAsync("signIn", viewModel);

        public async Task<JwtViewModel> SignUpAsync(UserSignUpViewModel viewModel) =>
            await ExecuteRequestAsync("signUp", viewModel);

        private async Task<JwtViewModel> ExecuteRequestAsync<T>(string requestUri, T model)
        {
            var jwtModel = await httpClient.PostWithoutAuthorizationAsync<T, JwtViewModel>(
                requestUri,
                model);

            await stateProvider.MarkUserAsAuthenticatedAsync(jwtModel.token,jwtModel.id);
            return jwtModel;
        }

        public async Task SingOutAsync()
        {
            await stateProvider.MarkUserAsLoggedOutAsync();
        }

        public IdentityService(
            HttpClient httpClient,
            ApiAuthenticationStateProvider stateProvider)
        {
            this.httpClient = new ApiHttpClientBuilder(httpClient).AddAuthorization(stateProvider)
                                                                  .Build();

            this.stateProvider = stateProvider;
        }
    }
}

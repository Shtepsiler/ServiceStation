using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using BlazorAppForClient.Authentication;
using BlazorAppForClient.Extensions;
using BlazorAppForClient.Interfaces;
using BlazorAppForClient.ViewModels;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.Extensions.Options;

namespace BlazorAppForClient.Services
{
    public class UsersService : IUsersService
    {
        private readonly HttpClient httpClient;

        private readonly ApiAuthenticationStateProvider stateProvider;


        private async Task<AuthenticationHeaderValue> GenerateAuthorizationHeaderAsync() =>
 new("Bearer", await stateProvider.GetJwtTokenAsync());
        private async Task<T> GetAsync<T>()
        {
            httpClient.DefaultRequestHeaders.Authorization = await GenerateAuthorizationHeaderAsync();
            var response = await httpClient.GetAsync($"{await stateProvider.GetClientNameAsync()}");
            var responseBody = await response.Content.ReadAsStringAsync();
            StatusCodeHandler.TryHandleStatusCode(response.StatusCode, responseBody);
            return JsonSerializer.Deserialize<T>(responseBody);
        }




        public async Task<UserViewModel> GetByNameAsync() =>
            await GetAsync<UserViewModel>();





        public async Task UpdateAsync(UserViewModel viewModel) =>
            await PutAsync(await stateProvider.GetClientNameAsync(), viewModel);
        public async Task PutAsync<T>(string requestUri, T viewModel)
        {
            httpClient.DefaultRequestHeaders.Authorization = await GenerateAuthorizationHeaderAsync();
            var response = await httpClient.PutAsJsonAsync(requestUri, viewModel);
            var responseBody = await response.Content.ReadAsStringAsync();
            StatusCodeHandler.TryHandleStatusCode(response.StatusCode, responseBody);
        }

        public async Task DeleteAsync() =>
            await DeleteAsync($"{await stateProvider.GetClientNameAsync()}");

        public async Task DeleteAsync(string requestUri)
        {
            var response = await httpClient.DeleteAsync(requestUri);
            var responseBody = await response.Content.ReadAsStringAsync();
            StatusCodeHandler.TryHandleStatusCode(response.StatusCode, responseBody);
        }

        public UsersService(HttpClient httpClient, ApiAuthenticationStateProvider state)
        {
            this.httpClient = httpClient;
            this.stateProvider = state;
        }
            
    }
}

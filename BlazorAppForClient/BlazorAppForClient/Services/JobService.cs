using BlazorAppForClient.Extensions;
using BlazorAppForClient.Interfaces;
using BlazorAppForClient.ViewModels;
using Blazored.LocalStorage;
using System.Net.Http;
using System.Text.Json;

namespace BlazorAppForClient.Services
{
    public class JobService : IJobService
    {
        private readonly HttpClient _httpClient;


        private readonly ILocalStorageService _localStorage;
        public JobService(ILocalStorageService localStorage, HttpClient httpClient) {
        _localStorage = localStorage;
            _httpClient = httpClient;
            
        }

        public async Task<JobViewModel> GetAsync(int id)
        {
            return await GetAsync<JobViewModel>($"{id}");
        }
        private async Task<T> GetAsync<T>(string requestUri)
        {
            //  httpClient.DefaultRequestHeaders.Authorization = await GenerateAuthorizationHeaderAsync();
            var response = await _httpClient.GetAsync(requestUri);
            var responseBody = await response.Content.ReadAsStringAsync();
            StatusCodeHandler.TryHandleStatusCode(response.StatusCode, responseBody);
            return JsonSerializer.Deserialize<T>(responseBody);
        }

        /*        private async Task<JobViewModel> ExecuteRequestAsync<T>(string requestUri, T model)
                {
                    var jwtModel = await _httpClient.PostWithoutAuthorizationAsync<T, JobViewModel>(
                        requestUri,
                        model);

                    return jwtModel;
                }*/

        public async Task SafeTolocalStorage()
        {
            JobViewModel jobViewModel = new JobViewModel() {id=1, modelId = 1, managerId =1 };

            await _localStorage.SetItemAsync<JobViewModel>("JobModel", jobViewModel);
        }
    }
}

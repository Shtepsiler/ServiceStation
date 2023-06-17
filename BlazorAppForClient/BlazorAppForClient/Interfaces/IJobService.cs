using BlazorAppForClient.ViewModels;

namespace BlazorAppForClient.Interfaces
{
    public interface IJobService
    {

        Task<JobViewModel> GetAsync(int id);
        Task SafeTolocalStorage();

    }
}

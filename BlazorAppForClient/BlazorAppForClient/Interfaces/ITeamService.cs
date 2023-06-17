using BlazorAppForClient.ViewModels;

namespace BlazorAppForClient.Interfaces
{
    public interface ITeamService
    {
        Task<MechanicViewModel> GetAsync(int id);
        Task<IEnumerable<MechanicViewModel>> GetAllAsync();

    }
}

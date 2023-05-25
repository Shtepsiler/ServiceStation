
using ServiceStation.DAL.Entities;

namespace ServiceStation.BLL.Services.Interfaces
{
    public interface IJobService
    {
        Task DeleteByIdAsync(int id);
        Task UpdateAsync(int id, Job job);
        Task PostAsync(Job job);
        Task<Job> GetByIdAsync(int id);
        Task<IEnumerable<Job>> GetAllAsync();


    }
}

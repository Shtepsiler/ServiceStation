using ServiceStation.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceStation.BAL.Services.Interfaces
{
    public interface IJobService
    {
        Task DeleteByIdAsync(int id);
        Task UpdateAsync(int id, Job job);
        Task<int> PostAsync(Job job);
        Task<Job> GetByIdAsync(int id);
        Task<IEnumerable<Job>> GetAllAsync();


    }
}

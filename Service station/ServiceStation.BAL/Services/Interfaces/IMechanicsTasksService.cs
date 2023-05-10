using ServiceStation.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceStation.BAL.Services.Interfaces
{
    public interface IMechanicsTasksService
    {
        Task<IEnumerable<MechanicsTasks>> GetAllAsync();
        Task<MechanicsTasks> GetByIdAsync(int id);
        Task<int> PostAsync(MechanicsTasks task);
        Task DeleteByIdAsync(int id);
        Task UpdateAsync(int id, MechanicsTasks task);


    }
}

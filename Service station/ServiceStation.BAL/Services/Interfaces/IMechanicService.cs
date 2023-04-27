using ServiceStation.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceStation.BAL.Services.Interfaces
{
    public interface IMechanicService
    {
        Task<IEnumerable<Mechanic>> GetAllAsync();
        Task<Mechanic> GetByIdAsync(int id);
        Task<int> PostAsync(Mechanic job);
        Task DeleteByIdAsync(int id);
        Task UpdateAsync(int id, Mechanic job);


    }
}

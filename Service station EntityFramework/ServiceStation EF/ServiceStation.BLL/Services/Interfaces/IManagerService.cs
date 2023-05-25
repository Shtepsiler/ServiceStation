using ServiceStation.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceStation.BLL.Services.Interfaces
{
    public interface IManagerService
    {
        Task<IEnumerable<Manager>> GetAllAsync();
        Task<Manager> GetByIdAsync(int id);
        Task PostAsync(Manager manager);
        Task DeleteByIdAsync(int id);
        Task UpdateAsync(int id, Manager manager);
    }
}

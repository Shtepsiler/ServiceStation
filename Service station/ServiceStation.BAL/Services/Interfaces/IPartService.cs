using ServiceStation.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceStation.BAL.Services.Interfaces
{
    public interface IPartService
    {
     Task<IEnumerable<Part>> GetAllAsync();
        Task<Part> GetByIdAsync(int id);
        Task<int> PostAsync(Part part);
        Task DeleteByIdAsync(int id);
        Task UpdateAsync(int id, Part part);


    }
}

using ServiceStation.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceStation.BAL.Services.Interfaces
{
    public interface IPartNeededService
    {
     Task<IEnumerable<PartNeeded>> GetAllAsync();
        Task<PartNeeded> GetByIdAsync(int id);
        Task<int> PostAsync(PartNeeded partNeeded);
        Task DeleteByIdAsync(int id);
        Task UpdateAsync(int id, PartNeeded partNeeded);


    }
}

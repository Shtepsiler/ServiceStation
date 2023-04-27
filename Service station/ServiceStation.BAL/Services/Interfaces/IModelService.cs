using ServiceStation.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceStation.BAL.Services.Interfaces
{
    public interface IModelService
    {
     Task<IEnumerable<Model>> GetAllAsync();
        Task<Model> GetByIdAsync(int id);
        Task<int> PostAsync(Model model);
        Task DeleteByIdAsync(int id);
        Task UpdateAsync(int id, Model model);


    }
}

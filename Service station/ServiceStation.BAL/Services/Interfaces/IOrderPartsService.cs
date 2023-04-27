using ServiceStation.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceStation.BAL.Services.Interfaces
{
    public interface IOrderPartsService
    {
     Task<IEnumerable<OrderPart>> GetAllAsync();
        Task<OrderPart> GetByIdAsync(int id);
        Task<int> PostAsync(OrderPart orderPart);
        Task DeleteByIdAsync(int id);
        Task UpdateAsync(int id, OrderPart orderPart);


    }
}

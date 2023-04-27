using ServiceStation.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceStation.BAL.Services.Interfaces
{
    public interface IOrderService
    {
     Task<IEnumerable<Order>> GetAllAsync();
        Task<Order> GetByIdAsync(int id);
        Task<int> PostAsync(Order order);
        Task DeleteByIdAsync(int id);
        Task UpdateAsync(int id, Order order);


    }
}

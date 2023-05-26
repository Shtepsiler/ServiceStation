using ServiceStation.BLL.DTO.Requests;
using ServiceStation.BLL.DTO.Responses;
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
        Task<IEnumerable<ManagerResponse>> GetAllAsync();
        Task<ManagerResponse> GetByIdAsync(int id);
        Task PostAsync(ManagerRequest manager);
        Task DeleteByIdAsync(int id);
        Task UpdateAsync(int id, ManagerRequest manager);
    }
}

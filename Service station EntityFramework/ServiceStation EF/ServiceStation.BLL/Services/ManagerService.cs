using ServiceStation.BLL.Services.Interfaces;
using ServiceStation.DAL.Entities;
using ServiceStation.DAL.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceStation.BLL.Services
{
    public class ManagerService : IManagerService
    {
        public readonly IUnitOfWork _unitOfWork;

        public ManagerService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Manager>> GetAllAsync()
        {
            try
            {
                var results = await _unitOfWork._ManagerRepository.GetAsync();
                return results;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<Manager> GetByIdAsync(int id)
        {
            try
            {
                var result = await _unitOfWork._ManagerRepository.GetByIdAsync(id);
                if (result == null)
                {
                    return null;
                }
                else
                {
                    return result;
                }

            }
            catch (Exception ex)
            {
                return null;
            }
        }


        public async Task PostAsync(Manager Manager)
        {
            try
            {

                await _unitOfWork._ManagerRepository.InsertAsync(Manager);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task UpdateAsync(int id, Manager Manager)
        {

            try
            {


                var event_entity = await _unitOfWork._ManagerRepository.GetByIdAsync(id);
                if (event_entity == null)
                {

                }

                await _unitOfWork._ManagerRepository.UpdateAsync(Manager);
            }
            catch (Exception ex)
            {

            }
        }


        public async Task DeleteByIdAsync(int id)
        {
            try
            {
                var event_entity = await _unitOfWork._ManagerRepository.GetByIdAsync(id);
                if (event_entity == null)
                {

                }

                await _unitOfWork._ManagerRepository.DeleteAsync(id);
            }
            catch (Exception ex)
            {

            }
        }

    }
}

using ServiceStation.BAL.Services.Interfaces;
using ServiceStation.DAL.Entities;
using ServiceStation.DAL.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ServiceStation.BAL.Services
{
    public class MechanicsTasksService : IMechanicsTasksService
    {
        public readonly IUnitOfWork _unitOfWork;

        public MechanicsTasksService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        
        public async Task<IEnumerable<MechanicsTasks>> GetAllAsync()
        {
            try
            {
                var results = await _unitOfWork._MechanicsTasksRepository.GetAllAsync();
                _unitOfWork.Commit();
                return results;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<MechanicsTasks> GetByIdAsync(int id)
        {
            try
            {
                var result = await _unitOfWork._MechanicsTasksRepository.GetAsync(id);
                _unitOfWork.Commit();
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


        public async Task<int> PostAsync(MechanicsTasks task)
        {
            try
            {

                var created_id = await _unitOfWork._MechanicsTasksRepository.AddAsync(task);
                _unitOfWork.Commit();
                return created_id;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task UpdateAsync(int id, MechanicsTasks task)
        {

            try
            {
               

                var event_entity = await _unitOfWork._MechanicsTasksRepository.GetAsync(id);
                if (event_entity == null)
                {
                    
                }

                await _unitOfWork._MechanicsTasksRepository.ReplaceAsync(task);
                _unitOfWork.Commit();
            }
            catch (Exception ex)
            {
               
            }
        }


        public async Task DeleteByIdAsync(int id)
        {
            try
            {
                var event_entity = await _unitOfWork._MechanicsTasksRepository.GetAsync(id);
                if (event_entity == null)
                {

                }

                await _unitOfWork._MechanicsTasksRepository.DeleteAsync(id);
                _unitOfWork.Commit();
            }
            catch (Exception ex)
            {

            }
        }


    }
}

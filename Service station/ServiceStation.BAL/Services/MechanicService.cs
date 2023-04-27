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
    public class MechanicService : IMechanicService
    {
        public readonly IUnitOfWork _unitOfWork;

        public MechanicService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        
        public async Task<IEnumerable<Mechanic>> GetAllAsync()
        {
            try
            {
                var results = await _unitOfWork._MechanicRepository.GetAllAsync();
                _unitOfWork.Commit();
                return results;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<Mechanic> GetByIdAsync(int id)
        {
            try
            {
                var result = await _unitOfWork._MechanicRepository.GetAsync(id);
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


        public async Task<int> PostAsync(Mechanic mechanic)
        {
            try
            {

                var created_id = await _unitOfWork._MechanicRepository.AddAsync(mechanic);
                _unitOfWork.Commit();
                return created_id;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task UpdateAsync(int id, Mechanic mechanic)
        {

            try
            {
               

                var event_entity = await _unitOfWork._MechanicRepository.GetAsync(id);
                if (event_entity == null)
                {
                    
                }

                await _unitOfWork._MechanicRepository.ReplaceAsync(mechanic);
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
                var event_entity = await _unitOfWork._MechanicRepository.GetAsync(id);
                if (event_entity == null)
                {

                }

                await _unitOfWork._MechanicRepository.DeleteAsync(id);
                _unitOfWork.Commit();
            }
            catch (Exception ex)
            {

            }
        }


    }
}

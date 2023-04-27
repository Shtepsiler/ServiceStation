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
    public class PartNeededService : IPartNeededService
    {
        public readonly IUnitOfWork _unitOfWork;

        public PartNeededService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        
        public async Task<IEnumerable<PartNeeded>> GetAllAsync()
        {
            try
            {
                var results = await _unitOfWork._PartNeededRepository.GetAllAsync();
                _unitOfWork.Commit();
                return results;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<PartNeeded> GetByIdAsync(int id)
        {
            try
            {
                var result = await _unitOfWork._PartNeededRepository.GetAsync(id);
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


        public async Task<int> PostAsync(PartNeeded partNeeded)
        {
            try
            {

                var created_id = await _unitOfWork._PartNeededRepository.AddAsync(partNeeded);
                _unitOfWork.Commit();
                return created_id;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task UpdateAsync(int id, PartNeeded partNeeded)
        {

            try
            {
               

                var event_entity = await _unitOfWork._PartNeededRepository.GetAsync(id);
                if (event_entity == null)
                {
                    
                }

                await _unitOfWork._PartNeededRepository.ReplaceAsync(partNeeded);
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
                var event_entity = await _unitOfWork._PartNeededRepository.GetAsync(id);
                if (event_entity == null)
                {

                }

                await _unitOfWork._PartNeededRepository.DeleteAsync(id);
                _unitOfWork.Commit();
            }
            catch (Exception ex)
            {

            }
        }


    }
}

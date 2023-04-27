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
    public class PartService : IPartService
    {
        public readonly IUnitOfWork _unitOfWork;

        public PartService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        
        public async Task<IEnumerable<Part>> GetAllAsync()
        {
            try
            {
                var results = await _unitOfWork._PartRepository.GetAllAsync();
                _unitOfWork.Commit();
                return results;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<Part> GetByIdAsync(int id)
        {
            try
            {
                var result = await _unitOfWork._PartRepository.GetAsync(id);
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


        public async Task<int> PostAsync(Part part)
        {
            try
            {

                var created_id = await _unitOfWork._PartRepository.AddAsync(part);
                _unitOfWork.Commit();
                return created_id;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task UpdateAsync(int id, Part part)
        {

            try
            {
               

                var event_entity = await _unitOfWork._PartRepository.GetAsync(id);
                if (event_entity == null)
                {
                    
                }

                await _unitOfWork._PartRepository.ReplaceAsync(part);
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
                var event_entity = await _unitOfWork._PartRepository.GetAsync(id);
                if (event_entity == null)
                {

                }

                await _unitOfWork._PartRepository.DeleteAsync(id);
                _unitOfWork.Commit();
            }
            catch (Exception ex)
            {

            }
        }


    }
}

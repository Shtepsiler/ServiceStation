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
    public class ModelService : IModelService
    {
        public readonly IUnitOfWork _unitOfWork;

        public ModelService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        
        public async Task<IEnumerable<Model>> GetAllAsync()
        {
            try
            {
                var results = await _unitOfWork._ModelRepository.GetAllAsync();
                _unitOfWork.Commit();
                return results;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<Model> GetByIdAsync(int id)
        {
            try
            {
                var result = await _unitOfWork._ModelRepository.GetAsync(id);
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


        public async Task<int> PostAsync(Model Model)
        {
            try
            {

                var created_id = await _unitOfWork._ModelRepository.AddAsync(Model);
                _unitOfWork.Commit();
                return created_id;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task UpdateAsync(int id, Model Model)
        {

            try
            {
               

                var event_entity = await _unitOfWork._ModelRepository.GetAsync(id);
                if (event_entity == null)
                {
                    
                }

                await _unitOfWork._ModelRepository.ReplaceAsync(Model);
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
                var event_entity = await _unitOfWork._ModelRepository.GetAsync(id);
                if (event_entity == null)
                {

                }

                await _unitOfWork._ModelRepository.DeleteAsync(id);
                _unitOfWork.Commit();
            }
            catch (Exception ex)
            {

            }
        }


    }
}

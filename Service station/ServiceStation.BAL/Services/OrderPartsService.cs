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
    public class OrderPartsService : IOrderPartsService
    {
        public readonly IUnitOfWork _unitOfWork;

        public OrderPartsService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        
        public async Task<IEnumerable<OrderPart>> GetAllAsync()
        {
            try
            {
                var results = await _unitOfWork._OrderPartRepository.GetAllAsync();
                _unitOfWork.Commit();
                return results;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<OrderPart> GetByIdAsync(int id)
        {
            try
            {
                var result = await _unitOfWork._OrderPartRepository.GetAsync(id);
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


        public async Task<int> PostAsync(OrderPart orderPart)
        {
            try
            {

                var created_id = await _unitOfWork._OrderPartRepository.AddAsync(orderPart);
                _unitOfWork.Commit();
                return created_id;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task UpdateAsync(int id, OrderPart orderPart)
        {

            try
            {
               

                var event_entity = await _unitOfWork._OrderPartRepository.GetAsync(id);
                if (event_entity == null)
                {
                    
                }

                await _unitOfWork._OrderPartRepository.ReplaceAsync(orderPart);
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
                var event_entity = await _unitOfWork._OrderPartRepository.GetAsync(id);
                if (event_entity == null)
                {

                }

                await _unitOfWork._OrderPartRepository.DeleteAsync(id);
                _unitOfWork.Commit();
            }
            catch (Exception ex)
            {

            }
        }


    }
}

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
    public class OrderService : IOrderService
    {
        public readonly IUnitOfWork _unitOfWork;

        public OrderService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        
        public async Task<IEnumerable<Order>> GetAllAsync()
        {
            try
            {
                var results = await _unitOfWork._OrderRepository.GetAllAsync();
                _unitOfWork.Commit();
                return results;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<Order> GetByIdAsync(int id)
        {
            try
            {
                var result = await _unitOfWork._OrderRepository.GetAsync(id);
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


        public async Task<int> PostAsync(Order order)
        {
            try
            {

                var created_id = await _unitOfWork._OrderRepository.AddAsync(order);
                _unitOfWork.Commit();
                return created_id;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task UpdateAsync(int id, Order order)
        {

            try
            {
               

                var event_entity = await _unitOfWork._OrderRepository.GetAsync(id);
                if (event_entity == null)
                {
                    
                }

                await _unitOfWork._OrderRepository.ReplaceAsync(order);
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
                var event_entity = await _unitOfWork._OrderRepository.GetAsync(id);
                if (event_entity == null)
                {

                }

                await _unitOfWork._OrderRepository.DeleteAsync(id);
                _unitOfWork.Commit();
            }
            catch (Exception ex)
            {

            }
        }


    }
}

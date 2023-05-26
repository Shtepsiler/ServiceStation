using AutoMapper;
using ServiceStation.BLL.DTO.Requests;
using ServiceStation.BLL.DTO.Responses;
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
        public readonly IMapper _maper;

        public ManagerService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<ManagerResponse>> GetAllAsync()
        {
            try
            {
                var results =(List<Manager>) await _unitOfWork._ManagerRepository.GetAsync();
                return _maper.Map<List<Manager>,List<ManagerResponse>>(results);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<ManagerResponse> GetByIdAsync(int id)
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
                    return _maper.Map<Manager, ManagerResponse>(result);
                }

            }
            catch (Exception ex)
            {
                return null;
            }
        }


        public async Task PostAsync(ManagerRequest Manager)
        {
            try
            {

                await _unitOfWork._ManagerRepository.InsertAsync( _maper.Map<ManagerRequest, Manager>(Manager));

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task UpdateAsync(int id, ManagerRequest Manager)
        {

            try
            {


                var event_entity = await _unitOfWork._ManagerRepository.GetByIdAsync(id);
                if (event_entity == null)
                {
                    throw new Exception();

                }

                await _unitOfWork._ManagerRepository.UpdateAsync(_maper.Map<ManagerRequest, Manager>(Manager));
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }


        public async Task DeleteByIdAsync(int id)
        {
            try
            {
                var event_entity = await _unitOfWork._ManagerRepository.GetByIdAsync(id);
                if (event_entity == null)
                {
                    throw new Exception();
                }

                await _unitOfWork._ManagerRepository.DeleteAsync(id);
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }

    }
}

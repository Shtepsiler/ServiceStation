using ServiceStation.BAL.Services.Interfaces;
using ServiceStation.DAL.Entities;
using ServiceStation.DAL.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ServiceStation.BAL.Services
{
    public class JobService : IJobService
    {
        public readonly IUnitOfWork _unitOfWork;

        public JobService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Job>> GetAllAsync()
        {
            try
            {
                var results = await _unitOfWork._JobRepository.GetAllAsync();
                _unitOfWork.Commit();
                return results;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<Job> GetByIdAsync(int id)
        {
            try
            {
                var result = await _unitOfWork._JobRepository.GetAsync(id);
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


        public async Task<int> PostAsync( Job job)
        {
            try
            {

                var created_id = await _unitOfWork._JobRepository.AddAsync(job);
                _unitOfWork.Commit();
                return created_id;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task UpdateAsync(int id, Job job)
        {

            try
            {
               

                var event_entity = await _unitOfWork._JobRepository.GetAsync(id);
                if (event_entity == null)
                {
                    
                }

                await _unitOfWork._JobRepository.ReplaceAsync(job);
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
                var event_entity = await _unitOfWork._JobRepository.GetAsync(id);
                if (event_entity == null)
                {

                }

                await _unitOfWork._JobRepository.DeleteAsync(id);
                _unitOfWork.Commit();
            }
            catch (Exception ex)
            {

            }
        }
        public async Task UpdateStatus(int jobid, string status)
        {
            try
            {
                await _unitOfWork._JobRepository.UpdateStatus(jobid, status);
                _unitOfWork.Commit();
            }
            catch (Exception e)
            {
            }


        }

    }
}

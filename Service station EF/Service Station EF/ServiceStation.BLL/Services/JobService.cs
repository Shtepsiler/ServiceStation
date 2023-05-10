using ServiceStation.BLL.Services.Interfaces;
using ServiceStation.DAL.Entities;
using ServiceStation.DAL.Interfaces.Contracts;



namespace ServiceStation.BLL.Services
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
                var results = await _unitOfWork._JobRepository.GetAsync();
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
                var result = await _unitOfWork._JobRepository.GetByIdAsync(id);
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


        public async Task PostAsync(Job job)
        {
            try
            {

                await _unitOfWork._JobRepository.InsertAsync(job);
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


                var event_entity = await _unitOfWork._JobRepository.GetByIdAsync(id);
                if (event_entity == null)
                {

                }

                await _unitOfWork._JobRepository.UpdateAsync(job);
            }
            catch (Exception ex)
            {

            }
        }


        public async Task DeleteByIdAsync(int id)
        {
            try
            {
                var event_entity = await _unitOfWork._JobRepository.GetByIdAsync(id);
                if (event_entity == null)
                {

                }

                await _unitOfWork._JobRepository.DeleteAsync(id);
               
            }
            catch (Exception ex)
            {

            }
        }


    }
}

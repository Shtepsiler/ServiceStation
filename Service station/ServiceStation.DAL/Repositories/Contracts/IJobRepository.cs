using ServiceStation.DAL.Entities;


namespace ServiceStation.DAL.Repositories.Contracts
{
    public interface IJobRepository : IGenericRepository<Job>
    {
         Task UpdateStatus(int jobid, string status);
    }
}

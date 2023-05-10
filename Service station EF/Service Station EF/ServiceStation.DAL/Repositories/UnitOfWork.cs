using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using ServiceStation.DAL.Interfaces.Contracts;
using ServiceStation.DAL.Repositories.Contracts;
using ServiceStationDatabase.Data;

namespace ServiceStation.DAL.Data.Contracts
{
    public class UnitOfWork : IUnitOfWork
    {
        protected readonly ServiceStationIdentityDBContext databaseContext;
        
        public IJobRepository _JobRepository { get; set; }
       public IModelRepository _ModelRepository { get; set; }

        public async Task SaveChangesAsync()
        {
            await databaseContext.SaveChangesAsync();
        }

        public UnitOfWork(
            ServiceStationIdentityDBContext databaseContext,
            IJobRepository jobRepository,
            IModelRepository modelRepository
          )
        {
            this.databaseContext = databaseContext;
            this._JobRepository = jobRepository;
            this._ModelRepository = modelRepository;
          
        }
    }
}

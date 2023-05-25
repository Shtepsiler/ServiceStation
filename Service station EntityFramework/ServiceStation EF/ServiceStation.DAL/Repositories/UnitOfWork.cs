using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using ServiceStation.DAL.Data;
using ServiceStation.DAL.Repositories.Contracts;

namespace ServiceStation.DAL.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        protected readonly ServiceStationDContext databaseContext;

        public IJobRepository _JobRepository { get; set; }
        public IModelRepository _ModelRepository { get; set; }

        public async Task SaveChangesAsync()
        {
            await databaseContext.SaveChangesAsync();
        }

        public UnitOfWork(
            ServiceStationDContext databaseContext,
            IJobRepository jobRepository,
            IModelRepository modelRepository
          )
        {
            this.databaseContext = databaseContext;
            _JobRepository = jobRepository;
            _ModelRepository = modelRepository;

        }
    }
}

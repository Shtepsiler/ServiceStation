using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ServiceStation.DAL.Data;
using ServiceStation.DAL.Entities;
using ServiceStation.DAL.Repositories.Contracts;

namespace ServiceStation.DAL.Repositories
{
    public class JobRepository : GenericRepository<Job>, IJobRepository
    {
       


       

        public JobRepository(ServiceStationDContext databaseContext)
            : base(databaseContext)
        {
        }
    }
}

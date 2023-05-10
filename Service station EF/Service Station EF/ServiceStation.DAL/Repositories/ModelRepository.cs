using ServiceStation.DAL.Data;
using ServiceStation.DAL.Entities;
using ServiceStation.DAL.Repositories.Contracts;
using ServiceStationDatabase.Data;
using System.Data;
using System.Data.SqlClient;

namespace ServiceStation.DAL.Repositories
{
    public class ModelRepository : GenericRepository<Model>, IModelRepository
    {





        public ModelRepository(ServiceStationIdentityDBContext databaseContext)
            : base(databaseContext)
        {
        }
    }
}

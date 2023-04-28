using ServiceStation.DAL.Entities;
using ServiceStation.DAL.Repositories.Contracts;
using System.Data;
using System.Data.SqlClient;

namespace ServiceStation.DAL.Repositories
{
    public class PartNeededRepository : GenericRepository<PartNeeded>, IPartNeededRepository
    {
        public PartNeededRepository(SqlConnection sqlConnection, IDbTransaction dbtransaction) : base(sqlConnection, dbtransaction, "PartNeeded")
        {
        }

    }
}

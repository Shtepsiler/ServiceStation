using ServiceStation.DAL.Entities;
using ServiceStation.DAL.Repositories.Contracts;
using System.Data;
using System.Data.SqlClient;

namespace ServiceStation.DAL.Repositories
{
    public class PartRepository : GenericRepository<Part>, IPartRepository
    {
        public PartRepository(SqlConnection sqlConnection, IDbTransaction dbtransaction) : base(sqlConnection, dbtransaction, "Users")
        {
        }

    }
}

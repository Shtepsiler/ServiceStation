using ServiceStation.DAL.Entities;
using ServiceStation.DAL.Repositories.Contracts;
using System.Data;
using System.Data.SqlClient;

namespace ServiceStation.DAL.Repositories
{
    public class JobRepository : GenericRepository<Job>, IJobRepository
    {
        public JobRepository(SqlConnection sqlConnection, IDbTransaction dbtransaction) : base(sqlConnection, dbtransaction, "Jobs")
        {
            //////////////
            //Gallery SQL
            //////////////
        }

    }
}

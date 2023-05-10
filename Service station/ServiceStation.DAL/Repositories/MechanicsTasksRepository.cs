using ServiceStation.DAL.Entities;
using ServiceStation.DAL.Repositories.Contracts;
using System.Data;
using System.Data.SqlClient;

namespace ServiceStation.DAL.Repositories
{
    public class MechanicsTasksRepository : GenericRepository<MechanicsTasks>, IMechanicsTasksRepository
    {
        public MechanicsTasksRepository(SqlConnection sqlConnection, IDbTransaction dbtransaction) : base(sqlConnection, dbtransaction, "MechanicsTasks")
        {

        }


    }
}

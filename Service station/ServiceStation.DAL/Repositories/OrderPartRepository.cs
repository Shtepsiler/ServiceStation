using ServiceStation.DAL.Entities;
using ServiceStation.DAL.Repositories.Contracts;
using System.Data;
using System.Data.SqlClient;

namespace ServiceStation.DAL.Repositories
{
    public class OrderPartRepository : GenericRepository<OrderPart>, IOrderPartRepository
    {
        public OrderPartRepository(SqlConnection sqlConnection, IDbTransaction dbtransaction) : base(sqlConnection, dbtransaction, "Categories")
        {
        }


    }
}

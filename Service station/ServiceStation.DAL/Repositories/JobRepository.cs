using Dapper;
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
        // створити апдей статусу

        public async Task UpdateStatus(int jobid, string status) {
            try
            {
                await _sqlConnection.ExecuteAsync($"UPDATE Jobs SET Status=@Status WHERE Id=@Id",
               param: new { Status = status, Id = jobid },
               transaction: _dbTransaction);
            }
            catch (Exception e)
            {
                await Console.Out.WriteLineAsync("Not found Id or other errors");
            }
        
        
        }



    }
}

using Dapper;
using ServiceStation.DAL.Entities;
using ServiceStation.DAL.Repositories.Contracts;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;

namespace ServiceStation.DAL.Repositories
{
    public class MechanicsTasksRepository : GenericRepository<MechanicsTasks>, IMechanicsTasksRepository
    {
        public MechanicsTasksRepository(SqlConnection sqlConnection, IDbTransaction dbtransaction) : base(sqlConnection, dbtransaction, "MechanicsTasks")
        {

        }
        // створити апдей статусу
        public async Task UpdateStatus(int taskId, string status)
        {
            try
            {
                await _sqlConnection.ExecuteAsync($"UPDATE MechanicsTasks SET Status=@Status WHERE Id=@Id",
               param: new { Status = status, Id = taskId },
               transaction: _dbTransaction);
            }
            catch (Exception e)
            {
                await Console.Out.WriteLineAsync("Not found Id or other errors");
            }
        }

        public async Task<IEnumerable<MechanicsTasks>> GetMechanicsTasksByMIdAndJId(int mechanicId,int jobId)
        {

            try
            {
             return   await _sqlConnection.QueryAsync<MechanicsTasks>($"SELECT * FROM MechanicsTasks WHERE JobId=@JobId and MechanicId=@MechanicId",
               param: new { JobId = jobId, MechanicId = mechanicId },
               transaction: _dbTransaction);
            }
            catch (Exception e)
            {
                await Console.Out.WriteLineAsync("Not found Id or other errors");
                throw new Exception("Tasks is not found");
            }

        }


    }
}

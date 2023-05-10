using ServiceStation.DAL.Repositories.Contracts;
using System.Data;

namespace ServiceStation.DAL.Repositories
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        public IJobRepository _JobRepository { get; }
        public IMechanicRepository _MechanicRepository { get; }
        public IModelRepository _ModelRepository { get; }
        public IMechanicsTasksRepository _MechanicsTasksRepository { get; }
        public IPartNeededRepository _PartNeededRepository { get; }
        public IPartRepository _PartRepository { get; }

        readonly IDbTransaction _dbTransaction;


        public UnitOfWork(
        IJobRepository JobRepository,
        IMechanicRepository MechanicRepository ,
        IModelRepository ModelRepository ,
        IMechanicsTasksRepository MechanicsTasksRepository,
        IPartNeededRepository PartNeededRepository ,
        IPartRepository PartRepository,
        IDbTransaction dbTransaction
            )
        {

            _JobRepository = JobRepository;
             _MechanicRepository = MechanicRepository;
             _ModelRepository = ModelRepository;
            _MechanicsTasksRepository = MechanicsTasksRepository;
             _PartNeededRepository = PartNeededRepository;
            _PartRepository = PartRepository;
            _dbTransaction = dbTransaction;
        }

        public void Commit()
        {
            try
            {
                _dbTransaction.Commit();
                // By adding this we can have muliple transactions as part of a single request
                //_dbTransaction.Connection.BeginTransaction();
            }
            catch (Exception ex)
            {
                _dbTransaction.Rollback();
                Console.WriteLine(ex.Message);
            }
        }
        public void Dispose()
        {
            //Close the SQL Connection and dispose the objects
            _dbTransaction.Connection?.Close();
            _dbTransaction.Connection?.Dispose();
            _dbTransaction.Dispose();
        }
    }
}
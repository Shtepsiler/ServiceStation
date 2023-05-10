using ServiceStation.DAL.Repositories.Contracts;

namespace ServiceStation.DAL.Repositories.Contracts
{
    public interface IUnitOfWork : IDisposable
    {
        IJobRepository _JobRepository { get; }
        IMechanicRepository _MechanicRepository { get; }
        IModelRepository _ModelRepository { get; }
        IMechanicsTasksRepository _MechanicsTasksRepository { get; } 
        IPartNeededRepository _PartNeededRepository { get; }
        IPartRepository _PartRepository { get; }
      
        void Commit();
        void Dispose();
    }
}

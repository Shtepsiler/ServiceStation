using ServiceStation.DAL.Repositories.Contracts;

namespace ServiceStation.DAL.Repositories.Contracts
{
    public interface IUnitOfWork : IDisposable
    {
        IJobRepository _JobRepository { get; }
        IMechanicRepository _MechanicRepository { get; }
        IModelRepository _ModelRepository { get; }
        IOrderPartRepository _OrderPartRepository { get; }
        IOrderRepository _OrderRepository { get; }
        IPartNeededRepository _PartNeededRepository { get; }
        IPartRepository _PartRepository { get; }
      
        void Commit();
        void Dispose();
    }
}

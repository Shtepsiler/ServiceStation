using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using ServiceStation.DAL.Repositories.Contracts;

namespace ServiceStation.DAL.Interfaces.Contracts
{
    public interface IUnitOfWork
    {
        IJobRepository _JobRepository { get; }
        IModelRepository _ModelRepository { get; }
        Task SaveChangesAsync();
    }
}

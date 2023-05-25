using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace ServiceStation.DAL.Repositories.Contracts
{
    public interface IUnitOfWork
    {
        IJobRepository _JobRepository { get; }
        IModelRepository _ModelRepository { get; }
        Task SaveChangesAsync();
    }
}

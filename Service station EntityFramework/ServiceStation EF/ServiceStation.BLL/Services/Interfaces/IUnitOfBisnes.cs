

namespace ServiceStation.BLL.Services.Interfaces
{
    public interface IUnitOfBisnes
    {
        IJobService _JobService { get; }
        IModelService _ModelService { get; }
        IManagerService _ManagerService { get; }
    }
}

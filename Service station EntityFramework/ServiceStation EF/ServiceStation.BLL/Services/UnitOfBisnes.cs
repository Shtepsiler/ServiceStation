using ServiceStation.BLL.Services.Interfaces;

namespace ServiceStation.BLL.Services
{
    public class UnitOfBisnes : IUnitOfBisnes
    {
        public IJobService _JobService { get; }
        public IModelService _ModelService { get; }
        public IManagerService _ManagerService { get; }


                
        public UnitOfBisnes(IJobService jobService,
            IModelService modelService,
            IManagerService managerService)
        {
            _JobService = jobService;
            _ModelService = modelService;
            _ManagerService = managerService;   
        }
    }
}

using ServiceStation.BLL.Services.Interfaces;

namespace ServiceStation.BLL.Services
{
    public class UnitOfBisnes : IUnitOfBisnes
    {
        public IJobService _JobService { get; }
        public IModelService _ModelService { get; }

        
        
        public UnitOfBisnes(IJobService jobService,
            IModelService modelService)
        {
            _JobService = jobService;
            _ModelService = modelService;
        }
    }
}

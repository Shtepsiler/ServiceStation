using ServiceStation.BAL.Services.Interfaces;
using ServiceStation.DAL.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceStation.BAL.Services
{
    public class UnitOfBisnes : IUnitOfBisnes
    {
        public IJobService _JobService { get; }
        public IMechanicService _MechanicService { get; }
        public IModelService _ModelService { get; }
        public IMechanicsTasksService _MechanicsTasksService { get; }
        public IPartNeededService _PartNeededService { get; }
        public IPartService _PartService { get; }   
        
        
        public UnitOfBisnes(IJobService jobService,
            IMechanicService mechanicService,
            IModelService modelService,
            IMechanicsTasksService MechanicsTasksService, 
            IPartNeededService partNeededService, 
            IPartService partService)
        {
            _JobService = jobService;
            _MechanicService = mechanicService;
            _ModelService = modelService;
            _MechanicsTasksService = MechanicsTasksService;
            _PartNeededService = partNeededService;
            _PartService = partService;
        }
    }
}

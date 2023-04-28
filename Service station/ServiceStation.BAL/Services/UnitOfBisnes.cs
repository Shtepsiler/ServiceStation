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
        public IOrderPartsService _OrderPartsService { get; }
        public IOrderService _OrderService { get; }
        public IPartNeededService _PartNeededService { get; }
        public IPartService _PartService { get; }   
        
        
        public UnitOfBisnes(IJobService jobService,
            IMechanicService mechanicService,
            IModelService modelService, 
            IOrderPartsService orderPartsService,
            IOrderService orderService, 
            IPartNeededService partNeededService, 
            IPartService partService)
        {
            _JobService = jobService;
            _MechanicService = mechanicService;
            _ModelService = modelService;
            _OrderPartsService = orderPartsService;
            _OrderService = orderService;
            _PartNeededService = partNeededService;
            _PartService = partService;
        }
    }
}

using Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class UnitOfServices : IUnitOfServices
    {

        public IClientsService _clientsService { get; }

        public IJobService _jobService { get; }

        public IManagerService _managerService { get; }

        public IMechanicService _mechanicService { get; }

        public IMechanicsTasksService _mechanicsTasksService { get; }

        public IModelService _modelService { get; }

        public IOrderPartsService _orderPartsService { get; }

        public IOrderService _orderService { get; }

        public IPartNeededService _partNeededService { get; }

        public IPartService _partService { get; }

        public IVendorsService _vendorsService { get; }

        public UnitOfServices(IClientsService clientsService, IJobService jobService, IManagerService managerService, IMechanicService mechanicService, IMechanicsTasksService mechanicsTasksService, IModelService modelService, IOrderPartsService orderPartsService, IOrderService orderService, IPartNeededService partNeededService, IPartService partService, IVendorsService vendorsService)
        {
            _clientsService = clientsService;
            _jobService = jobService;
            _managerService = managerService;
            _mechanicService = mechanicService;
            _mechanicsTasksService = mechanicsTasksService;
            _modelService = modelService;
            _orderPartsService = orderPartsService;
            _orderService = orderService;
            _partNeededService = partNeededService;
            _partService = partService;
            _vendorsService = vendorsService;
        }
    }
}

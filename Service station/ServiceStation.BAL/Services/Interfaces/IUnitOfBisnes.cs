using ServiceStation.DAL.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceStation.BAL.Services.Interfaces
{
    public interface IUnitOfBisnes
    {
        IJobService _JobService { get; }
        IMechanicService _MechanicService { get; }
        IModelService _ModelService { get; }
        IMechanicsTasksService _MechanicsTasksService { get; }
        IPartNeededService _PartNeededService { get; }
        IPartService _PartService { get; }
    }
}

using Microsoft.Extensions.Diagnostics.HealthChecks;
using System.Collections;
using TaskManagerForMechanic.DAL;
using TaskManagerForMechanic.DAL.Entitys;

using TaskManagerForMechanic.WEB.Extensions;

namespace TaskManagerForMechanic.WEB.GraphQl
{
    public class Query
    {
     
        [UseApplicationDbContext]
        public List<Job> GetJobs([ScopedService] TaskManagerDbContext context ) =>
            context.Jobs.ToList();
        [UseApplicationDbContext]

        public List<Mechanic> GetMechanics([ScopedService] TaskManagerDbContext context) =>
            context.Mechanics.ToList();
        [UseApplicationDbContext]

        public List<MechanicsTasks> GetMechanicsTasks([ScopedService] TaskManagerDbContext context) =>
             context.MechanicsTasks.ToList();



        [UseApplicationDbContext]

        public Mechanic GetMechanic([ScopedService] TaskManagerDbContext context, int id)
        {

            var mechanic = context.Mechanics.Where(p => p.Id == id).First();
            return mechanic;
        }


        [UseApplicationDbContext]

        public Job GetJob([ScopedService] TaskManagerDbContext context, int id)
        {

            var mechanic = context.Jobs.Where(p => p.Id == id).First();
            return mechanic;
        }


        [UseApplicationDbContext]

        public MechanicsTasks GetMechanicsTask([ScopedService] TaskManagerDbContext context, int id)
        {

            var mechanic = context.MechanicsTasks.Where(p => p.Id == id).First();
            return mechanic;
        }

        [UseApplicationDbContext]

        public List<MechanicsTasks> GetMechanicsTaskByMechanicId([ScopedService] TaskManagerDbContext context, int MechanicId)
        {

            var mechanic = context.MechanicsTasks.Where(p => p.MechanicId == MechanicId ).ToList();
            return mechanic;
        }







    }
}

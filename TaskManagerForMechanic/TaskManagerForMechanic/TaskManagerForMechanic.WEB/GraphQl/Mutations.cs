using TaskManagerForMechanic.DAL;
using TaskManagerForMechanic.DAL.Entitys;
using TaskManagerForMechanic.WEB.Extensions;
using TaskManagerForMechanic.WEB.GraphQl.Inputs.MechanicTask;
using TaskManagerForMechanic.WEB.GraphQl.Payloads.MechanicTasks;

namespace TaskManagerForMechanic.WEB.GraphQl
{
    public class Mutations
    {
        [UseApplicationDbContext]
        public async Task<AddMechanicTaskPayload> AddMechanicTask(
            AddMechanicTaskIntut intut,
            [ScopedService] TaskManagerDbContext context)
        {
            var task = new MechanicsTasks
            {
                MechanicId = intut.MechanicId,
                JobId = intut.JobId,
                Status = intut.Status,
                Task = intut.Task,
            };
            context.MechanicsTasks.Add(task);
            await context.SaveChangesAsync();

            return new AddMechanicTaskPayload(task);

        }














    }
}

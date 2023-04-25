using MyEventsEntityFrameworkDb.DbContexts;
using MyEventsEntityFrameworkDb.EFRepositories.Contracts;
using MyEventsEntityFrameworkDb.Entities;

namespace MyEventsEntityFrameworkDb.EFRepositories;

public class EFMessageRepository : EFGenericRepository<Message>, IEFMessageRepository
{
    public EFMessageRepository(ServiceStationDbContext databaseContext)
        : base(databaseContext)
    {
    }

    public override Task<Message> GetCompleteEntityAsync(int id)
    {
        throw new NotImplementedException();
    }
}

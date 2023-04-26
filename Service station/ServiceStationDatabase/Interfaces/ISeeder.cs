using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ServiceStationDatabase.Interfaces
{
    public interface ISeeder<T> where T : class
    {
        void Seed(EntityTypeBuilder<T> builder);


    }
}

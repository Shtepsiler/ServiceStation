using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ServiceStationDatabase.Entities;

namespace ServiceStationDatabase.Data.Configurations
{
    public class OrderPartConfiguration : IEntityTypeConfiguration<OrderPart>
    {
        public void Configure(EntityTypeBuilder<OrderPart> builder)
        {
            builder.Property(p => p.OrderId);
            builder.Property(p => p.PartId);
            builder.Property(p => p.Quantity);

            builder.HasKey(p => new { p.OrderId, p.PartId });


            builder.HasOne(p => p.Order).WithMany(p => p.OrderParts);
            builder.HasOne(p => p.Part).WithMany(p => p.OrderedParts);

            //new UserSeeder().Seed(builder);
        }
    }
}

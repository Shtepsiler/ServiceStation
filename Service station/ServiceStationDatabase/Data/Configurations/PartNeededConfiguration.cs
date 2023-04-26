﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ServiceStationDatabase.Entities;

namespace ServiceStationDatabase.Data.Configurations
{
    public class PartNeededConfiguration : IEntityTypeConfiguration<PartNeeded>
    {
        public void Configure(EntityTypeBuilder<PartNeeded> builder)
        {
            builder.Property(p => p.JobId);
            builder.Property(p => p.PartId);
            builder.Property(p => p.Quantity);

            builder.HasKey(p => new { p.JobId, p.PartId });


            builder.HasOne(p => p.Job).WithMany(p => p.PartNeededs);
            builder.HasOne(p => p.Part).WithMany(p => p.PartNeededs);

            //new UserSeeder().Seed(builder);
        }
    }
}

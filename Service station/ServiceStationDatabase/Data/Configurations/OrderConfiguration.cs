﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ServiceStationDatabase.Entities;

namespace ServiceStationDatabase.Data.Configurations
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {

            builder.Property(p => p.Id).UseIdentityColumn();
            builder.Property(p => p.JobId);
            builder.Property(p=>p.IssueDate);
            builder.Property(p => p.Delivered).HasDefaultValue(false);


            builder.HasKey(p => p.Id);



            builder.HasOne(p => p.Job).WithMany(p => p.Orders);



            //  new PaymentMohtodSeeder().Seed(builder);
        }
    }
}

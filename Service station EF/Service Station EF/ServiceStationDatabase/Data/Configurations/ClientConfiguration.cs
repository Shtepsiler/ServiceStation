﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ServiceStationDatabase.Entities;
namespace ServiceStationDatabase.Data.Configurations
{
    public class ClientConfiguration : IEntityTypeConfiguration<Client>
    {
        public void Configure(EntityTypeBuilder<Client> builder)
        {
            builder.Property(p=>p.Id).UseIdentityColumn();
            builder.Property(p => p.FirstName).HasMaxLength(50);
            builder.Property(p => p.LastName).HasMaxLength(50);
            builder.Property(p => p.Phone).HasMaxLength(12);
            builder.Property(p => p.Email).HasMaxLength(50);

            builder.HasKey(p => p. Id);
        }
    }
}

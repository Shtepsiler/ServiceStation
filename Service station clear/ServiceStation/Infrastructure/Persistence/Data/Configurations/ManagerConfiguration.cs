﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Domain.Entities;
using Application.DTOs.Respponces;

namespace Infrastructure.Persistence.Data.Configurations
{
    public class ManagerConfiguration : IEntityTypeConfiguration<Manager>
    {
        public void Configure(EntityTypeBuilder<Manager> builder)
        {
            builder.Property(p => p.Id).UseIdentityColumn();
            builder.Property(p => p.FullName).HasMaxLength(100);
            builder.Property(p => p.Phone).HasMaxLength(12);
            builder.Property(p => p.Email).HasMaxLength(50);

            builder.HasKey(p => p.Id);
        }
    }
}

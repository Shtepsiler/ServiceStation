using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ServiceStation.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceStation.DAL.Data.Configurations
{
    public class RefrshTokenConfiguration : IEntityTypeConfiguration<RefreshToken>
    {
        public void Configure(EntityTypeBuilder<RefreshToken> builder)
        {
            // builder.Property<int>(p => p.Id).UseIdentityColumn();
            builder.Property(p => p.ClientSecret);
            //  builder.Property(p => p.Email).HasMaxLength(50);

            builder.HasKey(p => p.Id);

            builder.HasOne(p => p.Client).WithOne(p=>p.RefreshToken);
        }
    }
}

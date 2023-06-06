using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Domain.Entities;

namespace Persistence.Data.Configurations
{
    public class RefrshTokenConfiguration : IEntityTypeConfiguration<RefreshToken>
    {
        public void Configure(EntityTypeBuilder<RefreshToken> builder)
        {
            // builder.Property<int>(p => p.Id).UseIdentityColumn();
            builder.Property(p => p.ClientSecret);
            builder.Property(p => p.ClientName).HasMaxLength(256);
            //  builder.Property(p => p.Email).HasMaxLength(50);

            builder.HasKey(p => p.Id);

            builder.HasOne(p => p.Client).WithOne(p => p.RefreshToken).HasForeignKey<RefreshToken>(p=>p.ClientName).HasPrincipalKey<Client>(p=>p.UserName).HasConstraintName("FK_Client_Token");
        }
    }
}

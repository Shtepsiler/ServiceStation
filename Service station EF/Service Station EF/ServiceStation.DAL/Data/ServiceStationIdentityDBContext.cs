using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ServiceStation.DAL.Data.Configurations;
using ServiceStation.DAL.Entities;

using System.Numerics;

namespace ServiceStationDatabase.Data
{
    public class ServiceStationIdentityDBContext : IdentityDbContext<Client>
    {
        public ServiceStationIdentityDBContext()
        {
        }

        public ServiceStationIdentityDBContext(DbContextOptions contextOptions) : base(contextOptions)
        {
        }

          public DbSet<Client> Clients { get; set; }
        public DbSet<Job> Jobs { get; set; }
        public DbSet<Manager> Managers { get; set; }

        public DbSet<Model> Models { get; set; }




        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new JobConfiguration());
            modelBuilder.ApplyConfiguration(new ManagerConfiguration());
            modelBuilder.ApplyConfiguration(new ModelConfiguration());

        }

    }
}

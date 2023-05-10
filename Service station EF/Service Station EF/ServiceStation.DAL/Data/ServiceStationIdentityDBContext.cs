using Microsoft.EntityFrameworkCore;
using ServiceStation.DAL.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using ServiceStation.DAL.Data.Configurations;

namespace ServiceStationDatabase.Data
{
    public class ServiceStationIdentityDBContext : IdentityDbContext<Client>
    {
        public ServiceStationIdentityDBContext(DbContextOptions<ServiceStationIdentityDBContext> options)
              : base(options)
        {
        }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Job> Jobs { get; set; }
        public DbSet<Manager> Managers { get; set; }
     
        public DbSet<Model> Models { get; set; }
     


/*        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS;Database=ServiceStation;Trusted_Connection=SSPI;Encrypt=false;TrustServerCertificate=True;");

            }
        }*/
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ClientConfiguration());
            modelBuilder.ApplyConfiguration(new JobConfiguration());
            modelBuilder.ApplyConfiguration(new ManagerConfiguration());

            modelBuilder.ApplyConfiguration(new ModelConfiguration());

        }

    }
}

using Microsoft.EntityFrameworkCore;
using MyEventsEntityFrameworkDb.Entities;

namespace MyEventsEntityFrameworkDb.DbContexts
{
    public partial class ServiceStationDbContext : DbContext
    {
        public ServiceStationDbContext()
        {
        }

        public ServiceStationDbContext(DbContextOptions<ServiceStationDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<CategoriesEvent> CategoriesEvents { get; set; } = null!;
        public virtual DbSet<Category> Categories { get; set; } = null!;
        public virtual DbSet<City> Cities { get; set; } = null!;
        public virtual DbSet<Country> Countries { get; set; } = null!;
        public virtual DbSet<Event> Events { get; set; } = null!;
        public virtual DbSet<Gallery> Galleries { get; set; } = null!;
        public virtual DbSet<Image> Images { get; set; } = null!;
        public virtual DbSet<Message> Messages { get; set; } = null!;
        public virtual DbSet<Role> Roles { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=.;Initial Catalog=MyEventsDb;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }

    }
}

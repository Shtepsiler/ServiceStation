
using Microsoft.EntityFrameworkCore;

namespace GraphQl.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
         : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Attendee>()
                .HasIndex(a => a.UserName)
                .IsUnique();

        /*    modelBuilder.Entity<Speaker>().HasMany(p => p.sessions).WithMany(p => p.speakers);

            modelBuilder.Entity<Attendee>().HasMany(p => p.Sessions).WithMany(p => p.Attendees);*/



            // Many-to-many: Session <-> Attendee
            modelBuilder
                .Entity<SessionAttendee>()
                .HasKey(ca => new { ca.SessionId, ca.AttendeeId });

            // Many-to-many: Speaker <-> Session
            modelBuilder
                .Entity<SessionSpeaker>()
                .HasKey(ss => new { ss.SessionId, ss.SpeakerId });

        }
        public DbSet<Session> Sessions { get; set; } = default!;
        public DbSet<Track> Tracks { get; set; } = default!;

        public DbSet<Speaker> Speakers { get; set; } = default!;

        public DbSet<Attendee> Attendees { get; set; } = default!;

    }
}

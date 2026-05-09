using EventHub.Configurations;
using EventHub.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventHub.Data
{
    public class EventHubDbContext : DbContext
    {
        public DbSet<Organizer> Organizers { get; set; }
        public DbSet<Profile> Profiles { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Attendee> Attendees { get; set; }
        public DbSet<Badge> Badges { get; set; }
        public DbSet<Registration> Registrations { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer("Server=.;Database=EventHub;Trusted_Connection=True;TrustServerCertificate=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Fluent API For Profile
            modelBuilder.Entity<Profile>()
                .HasKey(p => p.Id);

            modelBuilder.Entity<Profile>()
                .Property(p => p.Biography)
                .IsRequired();

            modelBuilder.Entity<Profile>()
                .Property(p => p.WebsiteUrl)
                .IsRequired(false)
                .HasMaxLength(200);

            modelBuilder.Entity<Profile>()
                .Property(p => p.ProfilePictureUrl)
                .IsRequired(false)
                .HasMaxLength(500);

            // 1:1 Organizer - Profile
            modelBuilder.Entity<Organizer>()
                .HasOne(o => o.Profile)
                .WithOne(p => p.Organizer)
                .HasForeignKey<Profile>(p => p.OrganizerId);

            // Fluent API For Badge
            modelBuilder.Entity<Badge>()
                .HasKey(b => b.Id);

            modelBuilder.Entity<Badge>()
                .Property(b => b.BadgeNumber)
                .IsRequired();

            modelBuilder.Entity<Badge>()
                .HasIndex(b => b.BadgeNumber)
                .IsUnique();

            modelBuilder.Entity<Badge>()
                .Property(b => b.IssueDate)
                .HasDefaultValueSql("GETDATE()");

            // 1:1 Attendee - Badge
            modelBuilder.Entity<Attendee>()
                .HasOne(a => a.Badge)
                .WithOne(b => b.Attendee)
                .HasForeignKey<Badge>(b => b.AttendeeId);

            // Separate Configuration Classes
            modelBuilder.ApplyConfiguration(new EventConfiguration());
            modelBuilder.ApplyConfiguration(new RegistrationConfiguration());

            // Organizer - Event (1:M)
            modelBuilder.Entity<Organizer>()
                .HasMany(o => o.Events)
                .WithOne(e => e.Organizer)
                .HasForeignKey(e => e.OrganizerId);

            // Unique Email for Attendee
            modelBuilder.Entity<Attendee>()
                .HasIndex(a => a.Email)
                .IsUnique();
        }
    }
}

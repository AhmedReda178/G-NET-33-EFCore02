using EventHub.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventHub.Configurations
{
    public class EventConfiguration : IEntityTypeConfiguration<Event>
    {
        public void Configure(EntityTypeBuilder<Event> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Title)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(e => e.Description)
                .IsRequired();

            builder.Property(e => e.EndDate)
                .IsRequired(false);

            builder.HasOne(e => e.ParentEvent)
                .WithMany(e => e.Sessions)
                .HasForeignKey(e => e.ParentEventId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Property<DateTime>("CreatedAt")
                .HasDefaultValueSql("GETDATE()");

            builder.Property<DateTime>("LastModifiedAt")
                .HasDefaultValueSql("GETDATE()");
        }
    }
}

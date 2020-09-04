using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace BlindDating.Models
{
    public partial class BlindDatingContext : DbContext
    {
        public BlindDatingContext()
        {
        }

        public BlindDatingContext(DbContextOptions<BlindDatingContext> options)
            : base(options)
        {
        }

        public virtual DbSet<DatingProfile> DatingProfile { get; set; }
        public virtual DbSet<MailMessage> MailMessage { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=localhost\\sqlexpress;Database=BlindDating;Trusted_Connection=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DatingProfile>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Bio)
                    .HasMaxLength(2555)
                    .IsUnicode(false);

                entity.Property(e => e.DisplayName)
                    .HasColumnName("displayName")
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .HasColumnName("First_Name")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Gender)
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .HasColumnName("Last_Name")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.PhotoPath)
                    .HasColumnName("photoPath")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.UserAccountId)
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<MailMessage>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.FromProfileId).HasColumnName("fromProfileID");

                entity.Property(e => e.IsRead).HasColumnName("isRead");

                entity.Property(e => e.MessageText)
                    .IsRequired()
                    .HasColumnName("messageText")
                    .HasColumnType("text");

                entity.Property(e => e.MessageTitle)
                    .IsRequired()
                    .HasColumnName("messageTitle")
                    .IsUnicode(false);

                entity.Property(e => e.ToProfileId).HasColumnName("toProfileID");

                entity.HasOne(d => d.FromProfile)
                    .WithMany(p => p.MailMessageFromProfile)
                    .HasForeignKey(d => d.FromProfileId)
                    .HasConstraintName("FK__MailMessa__fromP__6A30C649");

                entity.HasOne(d => d.ToProfile)
                    .WithMany(p => p.MailMessageToProfile)
                    .HasForeignKey(d => d.ToProfileId)
                    .HasConstraintName("FK__MailMessa__toPro__6B24EA82");
            });
        }
    }
}

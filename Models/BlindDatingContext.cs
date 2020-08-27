using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using BlindDating.Models;

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

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=.\\sqlexpress;Database=BlindDating;Trusted_Connection=True");
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
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .HasColumnName("First_Name")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Gender)
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .HasColumnName("Last_Name")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.UserAccountId)
                    .HasMaxLength(1)
                    .IsUnicode(false);
            });
        }

        public DbSet<BlindDating.Models.Film> Film { get; set; }
    }
}

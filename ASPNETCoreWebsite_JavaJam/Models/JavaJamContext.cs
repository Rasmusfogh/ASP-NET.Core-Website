using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ASPNETCoreWebsite_JavaJam.Models
{
    public partial class JavaJamContext : DbContext
    {
        public JavaJamContext()
        {
        }

        public JavaJamContext(DbContextOptions<JavaJamContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Job> Job { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("DefaultConnection");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Job>(entity =>
            {
                entity.HasKey(e => e.Email)
                    .HasName("PK__Job__A9D10535D7A39EC9");

                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.Experience).IsRequired();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

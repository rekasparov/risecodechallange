using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace RISE.Entity.REPORTTESTDB
{
    public partial class REPORTTESTDBContext : DbContext
    {
        public REPORTTESTDBContext()
        {
        }

        public REPORTTESTDBContext(DbContextOptions<REPORTTESTDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Report> Reports { get; set; }
        public virtual DbSet<ReportDetail> ReportDetails { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=REPORTTESTDB;Username=postgres;Password=1");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Report>(entity =>
            {
                entity.HasKey(e => e.UUID);

                entity.ToTable("Report");

                entity.Property(e => e.UUID).ValueGeneratedNever();

                entity.Property(e => e.RequestDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<ReportDetail>(entity =>
            {
                entity.HasKey(e => new { e.UUID, e.ReportId });

                entity.ToTable("ReportDetail");

                entity.Property(e => e.UUID).ValueGeneratedNever();

                entity.Property(e => e.Location)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.Report)
                    .WithMany(p => p.ReportDetails)
                    .HasForeignKey(d => d.ReportId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

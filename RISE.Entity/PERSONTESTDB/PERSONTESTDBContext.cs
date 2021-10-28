using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace RISE.Entity.PERSONTESTDB
{
    public partial class PERSONTESTDBContext : DbContext
    {
        public PERSONTESTDBContext()
        {
        }

        public PERSONTESTDBContext(DbContextOptions<PERSONTESTDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Person> People { get; set; }
        public virtual DbSet<PersonContact> PersonContacts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=PERSONTESTDB;Username=postgres;Password=1");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>(entity =>
            {
                entity.HasKey(e => e.UUID);

                entity.ToTable("Person");

                entity.Property(e => e.UUID).ValueGeneratedNever();

                entity.Property(e => e.Company)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Surname)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<PersonContact>(entity =>
            {
                entity.HasKey(e => new { e.UUID, e.PersonId });

                entity.ToTable("PersonContact");

                entity.Property(e => e.UUID).ValueGeneratedNever();

                entity.Property(e => e.PhoneNumber)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.EmailAddress)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Location)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.Person)
                    .WithMany(p => p.PersonContacts)
                    .HasForeignKey(d => d.PersonId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

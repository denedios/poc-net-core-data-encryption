using Microsoft.EntityFrameworkCore;
using PocNetCoreDataEncryption.Domain;
using PocNetCoreDataEncryption.Domain.Entities;

namespace PocNetCoreDataEncryption.DAL
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {
        }

        public DbSet<Patient> Patients { get; set; }
        public DbSet<Address> Addresses { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder
                    .UseLazyLoadingProxies()
                    .UseSqlServer("PocNetCoreDataEncryption");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            BuildPatient(modelBuilder);

            BuildAddress(modelBuilder);
        }



        private static void BuildPatient(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Patient>().ToTable("Patient");

            modelBuilder.Entity<Patient>()
                .Property(p => p.FirstName)
                .HasMaxLength(100)
                .IsRequired();

            modelBuilder.Entity<Patient>()
                .Property(p => p.LastName)
                .HasMaxLength(100)
                .IsRequired();

            modelBuilder.Entity<Patient>()
                .Property(p => p.Email)
                .HasMaxLength(250)
                .IsRequired();

            modelBuilder.Entity<Patient>()
                .Property(p => p.PhoneNumber)
                .HasMaxLength(25)
                .IsRequired();
        }

        private static void BuildAddress(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Address>().ToTable("Address");

            modelBuilder.Entity<Address>()
                .Property(a => a.Address1)
                .HasMaxLength(100)
                .IsRequired();

            modelBuilder.Entity<Address>()
                .Property(a => a.Address2)
                .HasMaxLength(100)
                .IsRequired(false);

            modelBuilder.Entity<Address>()
                .Property(a => a.City)
                .HasMaxLength(100)
                .IsRequired();

            modelBuilder.Entity<Address>()
                .Property(a => a.State)
                .HasMaxLength(20)
                .IsRequired();

            modelBuilder.Entity<Address>()
                .Property(a => a.Zip)
                .HasMaxLength(10)
                .IsRequired();
        }
    }
}

using Microsoft.EntityFrameworkCore;
using PocNetCoreDataEncryption.Domain;

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
    }
}

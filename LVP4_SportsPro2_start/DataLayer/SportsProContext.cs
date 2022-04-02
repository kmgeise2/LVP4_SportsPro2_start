using Microsoft.EntityFrameworkCore;

namespace LVP4_SportsPro2_start.Models
{
    public class SportsProContext : DbContext
    {
        public SportsProContext(DbContextOptions<SportsProContext> options)
            : base(options)
        { }

        public DbSet<Product> Products { get; set; }
        public DbSet<Technician> Technicians { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Incident> Incidents { get; set; }
        public DbSet<Registration> Registrations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // configure many-to-many for Registrations table
            modelBuilder.ApplyConfiguration(new RegistrationConfig());

            // seed initial data
            // ** Update this section **
        }
    }
}
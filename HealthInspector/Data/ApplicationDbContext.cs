using HealthInspector.Models;
using Microsoft.EntityFrameworkCore;

namespace HealthInspector.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<Locality> Localities { get; set; }
        public DbSet<Clinic> Clinics { get; set; }
    }
}

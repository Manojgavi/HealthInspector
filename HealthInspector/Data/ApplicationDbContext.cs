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

        public DbSet<Bmi> Bmis { get; set; }

        public DbSet<Locality> Localities { get; set; }
        public DbSet<Clinic> Clinics { get; set; }
        public DbSet<DoctorAvailability> DoctorAvailabilities { get; set; }
        public DbSet<DoctorSpecality> DoctorSpecalities { get; set; }


        public DbSet<Feedback> Feedbacks { get; set; }
        public DbSet<Questionnaire> Questionnaires  { get; set; }

        public DbSet<Appointment> Appointments { get; set; }

        public DbSet<Treatment> Treatments { get; set; }

    }
}

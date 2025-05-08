using Microsoft.EntityFrameworkCore;

namespace DatabaseModels.Data
{
    public class HealthcareContext : DbContext
    {
        public HealthcareContext(DbContextOptions<HealthcareContext> options)
            : base(options)
        {
        }
        public DbSet<Models.User> Users { get; set; }
        public DbSet<Models.Patient> Patients { get; set; }
    }
}

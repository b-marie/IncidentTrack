using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;

namespace IncidentTrack.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Incident> Incidents { get; set; }
        public DbSet<NearMiss> NearMisses { get; set; }
        public DbSet<AffectedBodyPart> AffectedBodyParts { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<InjuryType> InjuryTypes { get; set; }


        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}
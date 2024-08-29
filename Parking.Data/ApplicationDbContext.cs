using Microsoft.EntityFrameworkCore;
using Parking.Models;

namespace Parking.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
        {

        }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public virtual DbSet<AppUser> Users { get; set; }
        public virtual DbSet<Policy> Policies { get; set; }
        public virtual DbSet<PolicyType> PolicyTypes { get; set; }
        public virtual DbSet<Vehicle> Vehicles { get; set; }
        public virtual DbSet<VehicleInspection> VehicleInspections { get; set; }
        public virtual DbSet<VehiclePhoto> VehiclePhotos { get; set; }
        public virtual DbSet<VehicleProcess> VehicleProcesses { get; set; }
        public virtual DbSet<VehicleProcessType> VehicleProcessTypes { get; set; }
        public virtual DbSet<VehicleType> VehicleTypes { get; set; }
    }
}

namespace VehicleTrader.Data
{
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    using VehicleTrader.Models;

    public class VehicleTraderDbContext : IdentityDbContext<VehicleTraderUser, IdentityRole, string>
    {


        public VehicleTraderDbContext(DbContextOptions<VehicleTraderDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DENCHOZZ-PC\\SQLEXPRESS;Database=VehicleTraderDb;Trusted_Connection=True;MultipleActiveResultSets=true", 
                b => b.MigrationsAssembly("VehicleTrader.App"));

            base.OnConfiguring(optionsBuilder);
        }
    }
}

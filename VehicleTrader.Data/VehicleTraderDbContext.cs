namespace VehicleTrader.Data
{
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    using VehicleTrader.Models;

    public class VehicleTraderDbContext : IdentityDbContext<VehicleTraderUser, IdentityRole, string>
    {


        private readonly IHttpContextAccessor _httpContextAccessor;

        public VehicleTraderDbContext(DbContextOptions<VehicleTraderDbContext> options, IHttpContextAccessor httpContextAccessor)
            : base(options)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DENCHOZZ-PC\\SQLEXPRESS;Database=VehicleTraderDb;Trusted_Connection=True;MultipleActiveResultSets=true", 
                b => b.MigrationsAssembly("VehicleTrader.App"));

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<VehicleTraderUser>()
                .HasKey(user => user.Id);

            base.OnModelCreating(modelBuilder);
        }
    }
}

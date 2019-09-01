namespace VehicleTrader.Data
{
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    using VehicleTrader.Models;

    public class VehicleTraderDbContext : IdentityDbContext<VehicleTraderUser, IdentityRole, string>
    {
        public DbSet<Offer> Offers { get; set; }

        public DbSet<Manufacturer> Manufacturers { get; set; }

        public DbSet<Model> Models { get; set; }

        public DbSet<Engine> Engines { get; set; }

        public DbSet<Gearbox> Gearboxes { get; set; }

        public DbSet<MaxPrice> MaxPrices { get; set; }

        public DbSet<Dealer> Dealers { get; set; }

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

            modelBuilder.Entity<Manufacturer>()
                .HasMany(m => m.Models)
                .WithOne(m => m.Manufacturer)
                .HasForeignKey(m => m.ManufacturerId);

            base.OnModelCreating(modelBuilder);
        }
    }
}

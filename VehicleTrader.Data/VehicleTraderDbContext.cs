namespace VehicleTrader.Data
{
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    using VehicleTrader.Models;

    public class VehicleTraderDbContext : IdentityDbContext<VehicleTraderUser, IdentityRole, string>
    {
        public DbSet<Manufacturer> Manufacturers { get; set; }

        public DbSet<Model> Models { get; set; }

        public DbSet<FuelType> FuelTypes { get; set; }

        public DbSet<Offer> Offers { get; set; }

        public DbSet<TechData> TechDatas { get; set; }

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
                .HasMany(make => make.Models)
                .WithOne(make => make.Manufacturer)
                .HasForeignKey(make => make.ManufacturerId);

            modelBuilder.Entity<Offer>()
                .HasMany(offer => offer.TechnicalData)
                .WithOne(offer => offer.Offer)
                .HasForeignKey(offer => offer.OfferId);

            base.OnModelCreating(modelBuilder);
        }
    }
}

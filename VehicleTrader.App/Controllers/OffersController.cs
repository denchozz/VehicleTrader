namespace VehicleTrader.App.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using System.Linq;
    using VehicleTrader.Data;

    public class OffersController : Controller
    {
        private readonly VehicleTraderDbContext context;

        public OffersController(VehicleTraderDbContext context)
        {
            this.context = context;
        }

        public IActionResult Create()
        {
            this.ViewData["Manufacturers"] = this.context.Manufacturers.ToList();
            this.ViewData["Models"] = this.context.Models.ToList();
            this.ViewData["RegistrationYears"] = this.context.RegistrationYears.ToList();
            this.ViewData["Gearboxes"] = this.context.Gearboxes.ToList();
            this.ViewData["Engines"] = this.context.Engines.ToList();
            this.ViewData["MaxPrices"] = this.context.MaxPrices.ToList();

            return View();
        }
    }
}
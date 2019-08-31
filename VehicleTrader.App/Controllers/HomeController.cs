namespace VehicleTrader.App.Controllers
{
    using System.Diagnostics;
    using System.Linq;
    using Microsoft.AspNetCore.Mvc;
    using VehicleTrader.App.Models;
    using VehicleTrader.Data;

    public class HomeController : Controller
    {
        private readonly VehicleTraderDbContext context;

        public HomeController(VehicleTraderDbContext context)
        {
            this.context = context;
        }

        public IActionResult Index()
        {
            this.ViewData["Manufacturers"] = this.context.Manufacturers.ToList();
            this.ViewData["Models"] = this.context.Models.ToList();
            this.ViewData["Gearboxes"] = this.context.Gearboxes.ToList();
            this.ViewData["Engines"] = this.context.Engines.ToList();
            this.ViewData["MaxPrices"] = this.context.MaxPrices.ToList();

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

namespace VehicleTrader.App.Controllers
{
    using System.Diagnostics;
    using System.Linq;
    using Microsoft.AspNetCore.Mvc;
    using VehicleTrader.App.Models;
    using VehicleTrader.App.ViewModels.Home;
    using VehicleTrader.App.ViewModels.Offers;
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

        [HttpPost]
        public IActionResult Index(OfferViewModel viewModel)
        {
            return this.Redirect("/Offers/OffersList");
        }

        //[HttpPost]
        //public IActionResult Index(FindOffersViewModel viewModel)
        //{
        //    return this.View(context.Offers
        //        .Where(offer => offer.Make == viewModel.Make)
        //        .ToList()
        //        .Select(offer =>
        //        {
        //            return new FindOffersViewModel
        //            {
        //                Make = offer.Make,
        //                Model = offer.Model,
        //                Year = offer.YearOfRegistration,
        //                Price = offer.Price,
        //                Engine = offer.Engine,
        //                Gearbox = offer.Gearbox
        //            };
        //        }).ToList());

        //    //return this.Redirect("/Offers/FindOffers");
        //}

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

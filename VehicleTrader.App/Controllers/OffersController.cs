namespace VehicleTrader.App.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using System.Linq;
    using VehicleTrader.App.ViewModels.Offers;
    using VehicleTrader.Data;
    using VehicleTrader.Services.Contracts;

    public class OffersController : Controller
    {
        private readonly VehicleTraderDbContext context;
        private readonly IOffersService offersService;

        public OffersController(VehicleTraderDbContext context, IOffersService offersService)
        {
            this.context = context;
            this.offersService = offersService;
        }

        public IActionResult Create()
        {
            this.ViewData["Manufacturers"] = this.context.Manufacturers.ToList();
            this.ViewData["Models"] = this.context.Models.ToList();
            this.ViewData["Gearboxes"] = this.context.Gearboxes.ToList();
            this.ViewData["Engines"] = this.context.Engines.ToList();
            this.ViewData["MaxPrices"] = this.context.MaxPrices.ToList();

            return View();
        }

        [HttpPost]
        public IActionResult Create(CreateOfferViewModel viewModel)
        {
            var offer = this.offersService.CreateOffer(viewModel.Make, viewModel.Model, viewModel.Year,
                viewModel.Price, viewModel.Engine, viewModel.Gearbox, viewModel.Description, viewModel.ImgUrl);

            this.context.Offers.Add(offer);
            this.context.SaveChanges();

            return this.Redirect("/Offers/OffersList");
        }

        [HttpGet]
        public IActionResult OffersList()
        {
            return View(context.Offers
                .ToList()
                .Select(offer => 
                {
                    return new OfferViewModel
                    {
                        Make = offer.Make,
                        Model = offer.Model,
                        Year = offer.YearOfRegistration,
                        Price = offer.Price,
                        Engine = offer.Engine,
                        Gearbox = offer.Gearbox,
                        Description = offer.Description,
                        ImgUrl = offer.ImgUrl
                    };
                }).ToList());
        }

        [HttpGet]
        public IActionResult FindOffers()
        {
            return this.View();
        }
    }
}
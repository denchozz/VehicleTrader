namespace VehicleTrader.App.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using System.Linq;
    using VehicleTrader.App.ViewModels.Dealers;
    using VehicleTrader.Data;
    using VehicleTrader.Services.Contracts;

    public class DealersController : Controller
    {
        private readonly VehicleTraderDbContext context;
        private readonly IDealersService dealersService;

        public DealersController(VehicleTraderDbContext context, IDealersService dealersService)
        {
            this.context = context;
            this.dealersService = dealersService;
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult Add(AddDealerViewModel viewModel)
        {
            var dealer = this.dealersService.Add(viewModel.DealerName, viewModel.Cars, viewModel.Location, viewModel.ImgUrl);

            this.context.Dealers.Add(dealer);
            this.context.SaveChanges();

            return this.Redirect("/Dealers/DealersList");
        }

        [HttpGet]
        [Authorize]
        public IActionResult DealersList()
        {
            return View(context.Dealers
                .ToList()
                .Select(dealer =>
                {
                    return new DealerViewModel
                    {
                        DealerName = dealer.Name,
                        Cars = dealer.Cars,
                        Location = dealer.Location,
                        ImgUrl = dealer.ImageUrl
                    };
                }).ToList());
        }
    }
}
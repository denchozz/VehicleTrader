namespace VehicleTrader.Services
{
    using VehicleTrader.Models;
    using VehicleTrader.Services.Contracts;

    public class DealersService : IDealersService
    {
        public Dealer Add(string name, int cars, string location, string imgUrl)
        {
            Dealer dealer = new Dealer
            {
                Name = name,
                Cars = cars,
                Location = location,
                ImageUrl = imgUrl
            };

            return dealer;
        }
    }
}

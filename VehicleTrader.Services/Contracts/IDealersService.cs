namespace VehicleTrader.Services.Contracts
{
    using VehicleTrader.Models;

    public interface IDealersService
    {
        Dealer Add(string name, int cars, string location, string imgUrl);
    }
}

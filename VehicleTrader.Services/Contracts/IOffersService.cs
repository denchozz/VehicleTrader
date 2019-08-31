namespace VehicleTrader.Services.Contracts
{
    using VehicleTrader.Models;

    public interface IOffersService
    {
        Offer CreateOffer(string make, string model, string regYear, decimal price, 
            string engine, string gearbox, string description, string imgUrl);
    }
}

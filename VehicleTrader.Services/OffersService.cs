namespace VehicleTrader.Services
{
    using VehicleTrader.Models;
    using VehicleTrader.Services.Contracts;

    public class OffersService : IOffersService
    {
        public Offer CreateOffer(string make, string model, string regYear, decimal price, 
            string engine, string gearbox, string description, string imgUrl)
        {
            Offer offer = new Offer
            {
                Make = make,
                Model = model,
                YearOfRegistration = regYear,
                Price = price,
                Engine = engine,
                Gearbox = gearbox,
                Description = description,
                ImgUrl = imgUrl
            };

            return offer;
        }
    }
}

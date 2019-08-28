namespace VehicleTrader.Models
{
    using System.Collections.Generic;

    public class Offer
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public ICollection<TechData> TechnicalData { get; set; }

        //public List<Feature> Features { get; set; }
    }
}

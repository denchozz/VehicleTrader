namespace VehicleTrader.Models
{
    using System;

    public class TechData
    {
        public string Id { get; set; }

        public DateTime RegistrationDate { get; set; }

        public string EngineType { get; set; }

        public int Power { get; set; }

        public string Transmission { get; set; }

        public string Category { get; set; }

        public string OfferId { get; set; }
        public Offer Offer { get; set; }
    }
}
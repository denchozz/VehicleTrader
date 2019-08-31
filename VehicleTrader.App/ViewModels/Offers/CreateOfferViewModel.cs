﻿namespace VehicleTrader.App.ViewModels.Offers
{

    public class CreateOfferViewModel
    {
        public string Make { get; set; }

        public string Model { get; set; }

        public int YearOfRegistration { get; set; }

        public decimal MaxPrice { get; set; }

        public string Engine { get; set; }

        public string Gearbox { get; set; }

        public string Description { get; set; }

        public string ImgUrl { get; set; }
    }
}
namespace VehicleTrader.Models
{
    using System;
    using System.Collections.Generic;

    public class Manufacturer
    {
        public Manufacturer()
        {
            this.Models = new HashSet<Model>();
        }

        public string Id { get; set; }

        public string Name { get; set; }

        public string Headquarters { get; set; }

        public DateTime Founded { get; set; }

        public string Website { get; set; }

        public int NumberOfEmployyes { get; set; }

        public ICollection<Model> Models { get; set; }
    }
}

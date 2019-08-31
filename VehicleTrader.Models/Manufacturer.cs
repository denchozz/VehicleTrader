namespace VehicleTrader.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Manufacturer
    {
        public Manufacturer()
        {
            this.Models = new HashSet<Model>();
        }

        [Key]
        public string Id { get; set; }

        public string Name { get; set; }

        public string Headquarters { get; set; }

        public int Founded { get; set; }

        public string Website { get; set; }

        public int NumberOfEmployyes { get; set; }

        public ICollection<Model> Models { get; set; }
    }
}

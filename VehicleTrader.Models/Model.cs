namespace VehicleTrader.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Model
    {
        [Key]
        public string Id { get; set; }

        public string Name { get; set; }

        public string ManufacturerId { get; set; }
        public Manufacturer Manufacturer { get; set; }
    }
}
namespace VehicleTrader.Models
{
    public class Model
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string ManufacturerId { get; set; }
        public Manufacturer Manufacturer { get; set; }
    }
}
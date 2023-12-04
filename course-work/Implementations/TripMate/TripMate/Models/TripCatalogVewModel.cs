namespace TripMate.Models
{
    public class TripCatalogViewModel
    {
        // Trip details
        public string? FromCity { get; set; }
        public string? ToCity { get; set; }
        public DateTime DepartureDateTime { get; set; }
        public int AvailableSeats { get; set; }
        public int Rating { get; set; }


        // Driver details
        public string? DriverFirstName { get; set; }
        public string? DriverLastName { get; set; }
        public string? DriverEmail { get; set; }
        public int DriverPhone { get; set; }
        public string? DriverCar { get; set; }

        // Weather details
        public string? WeatherDescription { get; set; }
    }
}

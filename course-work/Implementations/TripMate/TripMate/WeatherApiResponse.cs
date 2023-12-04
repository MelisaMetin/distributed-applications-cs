namespace TripMate
{
    public class WeatherApiResponse
    {
        public Location? Location { get; set; }
        public CurrentWeather? Current { get; set; }
    }

    public class Location
    {
        public string? Name { get; set; }
        public string? Region { get; set; }
        public string? Country { get; set; }
    }

    public class CurrentWeather
    {
        public int Temp_C { get; set; }
        public Condition? Condition { get; set; }
    }

    public class Condition
    {
        public string? Text { get; set; }
    }

}

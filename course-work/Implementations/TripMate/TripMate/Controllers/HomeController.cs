using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Net.Http;
using System.Text.Json;
using TripMate.Entities;
using TripMate.Models;


namespace TripMate.Controllers
{
    public class HomeController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly TripCatalogDbContext _dbContext;

        public HomeController(IHttpClientFactory httpClientFactory, TripCatalogDbContext dbContext)
        {
            _httpClientFactory = httpClientFactory;
            _dbContext = dbContext;
        }

        public async Task<IActionResult> Index()
        {
            var tripDetails = await FetchTripDetailsFromDatabase();
            var driverDetails = await FetchDriverDetailsFromDatabase();

            var weatherDescription = await FetchWeatherInformation( tripDetails?.ToCity);

            var tripCatalogViewModel = new TripCatalogViewModel
            {
                FromCity = tripDetails?.FromCity,
                ToCity = tripDetails?.ToCity,
                DepartureDateTime = tripDetails?.DepartureDateTime ?? DateTime.MinValue,
                AvailableSeats = tripDetails?.AvailableSeats ?? 0,
                DriverFirstName = driverDetails?.FirstName,
                DriverLastName = driverDetails?.LastName,
                DriverEmail = driverDetails?.Email,
                DriverPhone = driverDetails?.Phone ?? 0,
                DriverCar = driverDetails?.Car,
                WeatherDescription = weatherDescription
            };

            return View(tripCatalogViewModel);
        }

        private async Task<Trip?> FetchTripDetailsFromDatabase()
        {
            return await _dbContext.Trips.FirstOrDefaultAsync();
        }

        private async Task<Driver?> FetchDriverDetailsFromDatabase()
        {
            return await _dbContext.Drivers.FirstOrDefaultAsync();
        }

        private async Task<string> FetchWeatherInformation(string? city)
        {
            if (city != null)
            {
                string apiKey = "4296cdc720de4e8580b133112231411";
                string weatherApiUrl = $"https://api.weatherapi.com/v1/current.json?key={apiKey}&q={city}&aqi=no";

                using (var client = _httpClientFactory.CreateClient())
                {
                    var response = await client.GetAsync(weatherApiUrl);

                    if (response.IsSuccessStatusCode)
                    {
                        var jsonString = await response.Content.ReadAsStringAsync();
                        var weatherData = JsonSerializer.Deserialize<WeatherApiResponse>(jsonString);
                        return weatherData?.Current?.Condition?.Text ?? "Weather information not available";
                    }
                    else
                    {
                        return "Weather information not available";
                    }
                }
            }
            else
            {
                return "City information is null";
            }
        }




        public IActionResult Privacy()
      {
          return View();
      }

      [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
      public IActionResult Error()
      {
          return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
      }


        

      }
}

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TripMate.Entities;
using TripMate.Models;

namespace TripMate.Controllers
{
/*    [Authorize(Policy = "CanCreateTrip")] 
*/
    public class TripController : Controller
    {
        private readonly TripCatalogDbContext _dbContext;

        public TripController(TripCatalogDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult Create()
        {
            return View(new TripViewModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(TripViewModel tripViewModel)
        {
            if (ModelState.IsValid)
            {
                var trip = new Trip
                {
                    FromCity = tripViewModel.FromCity,
                    ToCity = tripViewModel.ToCity,
                    DepartureDateTime = tripViewModel.DepartureDateTime,
                    AvailableSeats = tripViewModel.AvailableSeats,
                };

                _dbContext.Trips.Add(trip);
                _dbContext.SaveChanges();

                return View("~/Views/Trips/Create.cshtml", new TripViewModel());
            }

            return View("Create", new TripViewModel());
        }
    }
}


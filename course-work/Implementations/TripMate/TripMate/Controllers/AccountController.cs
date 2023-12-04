using Microsoft.AspNetCore.Mvc;
using TripMate.Models; 

namespace TripMate.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult CreateTrip()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddTrip(TripViewModel trip)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("TripAdded");
            }

            return View(trip); 
        }





    }
}

using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using TripMate.Entities;
using TripMate.Models;

namespace TripMate.Controllers
{
    public class TripCatalogController : Controller
    {
        private readonly TripCatalogDbContext _dbContext;

        public TripCatalogController(TripCatalogDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // GET: /TripCatalog
        public IActionResult Index()
        {
            List<Trip> trips = _dbContext.Trips.ToList();

            return View(trips);
        }

        
    }
}


using Microsoft.AspNetCore.Mvc;

namespace TripMate.Controllers
{
    public class FeedbackController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

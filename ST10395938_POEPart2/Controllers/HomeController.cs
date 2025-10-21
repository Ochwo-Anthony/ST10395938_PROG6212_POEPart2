using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ST10395938_POEPart2.Data;
using ST10395938_POEPart2.Models;

namespace ST10395938_POEPart2.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly ILogger<HomeController> _logger;

        // Single constructor with both dependencies
        public HomeController(ILogger<HomeController> logger, ApplicationDbContext db)
        {
            _logger = logger;
            _db = db;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ClearClaims()
        {
#if DEBUG
            _db.LecturerClaims.RemoveRange(_db.LecturerClaims);
            _db.SaveChanges();
            TempData["Message"] = "All LecturerClaims rows have been deleted.";
#else
            TempData["Message"] = "Clearing claims is only allowed in development mode.";
#endif
            return RedirectToAction(nameof(Privacy));
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

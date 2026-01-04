using Microsoft.AspNetCore.Mvc;
using Pronia.Contexts;

namespace Pronia.Controllers
{
    public class HomeController : Controller
    {
        private AppDbContext _context;

        public HomeController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var serviceFeatures = _context.ServiceFeatures.ToList();
            return View(serviceFeatures);
        }
    }

    
}



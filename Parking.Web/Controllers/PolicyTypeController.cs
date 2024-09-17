using Microsoft.AspNetCore.Mvc;
using Parking.Data;

namespace Parking.Web.Controllers
{
    public class PolicyTypeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PolicyTypeController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}

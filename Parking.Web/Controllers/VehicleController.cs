using Microsoft.AspNetCore.Mvc;

namespace Parking.Web.Controllers
{
    public class VehicleController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

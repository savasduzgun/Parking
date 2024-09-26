using Microsoft.AspNetCore.Mvc;

namespace Parking.Web.Controllers
{
    public class VehicleTypeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

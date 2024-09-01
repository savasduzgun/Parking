using Microsoft.AspNetCore.Mvc;

namespace Parking.Web.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

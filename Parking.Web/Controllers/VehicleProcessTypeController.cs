using Microsoft.AspNetCore.Mvc;
using Parking.Data;
using Parking.Models;

namespace Parking.Web.Controllers
{
    public class VehicleProcessTypeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public VehicleProcessTypeController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GetAll()
        {
            return Json(new { Data = _context.VehicleProcessTypes.Where(vpt => !vpt.IsDeleted).ToList() });
        }

        [HttpPost]
        public IActionResult Add(VehicleProcessType vehicleProcessType)
        {
            _context.VehicleProcessTypes.Add(vehicleProcessType);
            _context.SaveChanges();
            return Ok(vehicleProcessType);
        }
    }
}

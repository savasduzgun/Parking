using Microsoft.AspNetCore.Mvc;
using Parking.Data;
using Parking.Models;

namespace Parking.Web.Controllers
{
    public class VehicleTypeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public VehicleTypeController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GetAll() 
        { 
            return Json(new {Data = _context.VehicleProcessTypes.Where(vt=>!vt.IsDeleted)});
        }

        [HttpPost]
        public IActionResult Add(VehicleType vehicleType) 
        {
            _context.VehicleTypes.Add(vehicleType);
            _context.SaveChanges();
            return Ok(vehicleType);
        }
    }
}

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

        [HttpPost]
        public IActionResult Update(VehicleProcessType vehicleProcessType)
        {
            _context.VehicleProcessTypes.Update(vehicleProcessType);
            _context.SaveChanges();
            return Ok(vehicleProcessType);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            var vehicleProcessType = _context.VehicleProcessTypes.Find(id);
            vehicleProcessType.IsDeleted = true;
            vehicleProcessType.DateDeleted = DateTime.Now;
            _context.VehicleProcessTypes.Update(vehicleProcessType);
            _context.SaveChanges();
            return Ok();
        }

        [HttpPost]
        public IActionResult HardDelete(VehicleProcessType vehicleProcessType)
        {
            _context.VehicleProcessTypes.Remove(vehicleProcessType);
            _context.SaveChanges();
            return Ok();
        }
    }
}

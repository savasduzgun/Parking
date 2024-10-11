using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Parking.Data;
using Parking.Models;
using Parking.Repository.Shared.Abstract;

namespace Parking.Web.Controllers
{
    public class VehicleProcessTypeController : Controller
    {
        //private readonly ApplicationDbContext _context;

        //public VehicleProcessTypeController(ApplicationDbContext context)
        //{
        //    _context = context;
        //}
        private readonly IRepository<VehicleProcessType> _vehicleProcessTypeRepo;

        public VehicleProcessTypeController(IRepository<VehicleProcessType> vehicleProcessTypeRepo)
        {
            _vehicleProcessTypeRepo = vehicleProcessTypeRepo;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GetAll()
        {
            //return Json(new { data = _context.VehicleProcessTypes.Where(vpt => !vpt.IsDeleted).ToList() });
            return Json(new { data = _vehicleProcessTypeRepo.GetAll() });
        }

        [HttpPost]
        public IActionResult Add(VehicleProcessType vehicleProcessType)
        {
            //_context.VehicleProcessTypes.Add(vehicleProcessType);
            //_context.SaveChanges();
            _vehicleProcessTypeRepo.Add(vehicleProcessType);
            return Ok(vehicleProcessType);
        }

        [HttpPost]
        public IActionResult Update(VehicleProcessType vehicleProcessType)
        {
            //_context.VehicleProcessTypes.Update(vehicleProcessType);
            //_context.SaveChanges();
            _vehicleProcessTypeRepo.Update(vehicleProcessType);
            return Ok(vehicleProcessType);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            //var vehicleProcessType = _context.VehicleProcessTypes.Find(id);
            //vehicleProcessType.IsDeleted = true;
            //vehicleProcessType.DateDeleted = DateTime.Now;
            //_context.VehicleProcessTypes.Update(vehicleProcessType);
            //_context.SaveChanges();
            _vehicleProcessTypeRepo.DeleteById(id);
            return Ok();
        }

        [HttpPost]
        public IActionResult HardDelete(VehicleProcessType vehicleProcessType)
        {
            //_context.VehicleProcessTypes.Remove(vehicleProcessType);
            //_context.SaveChanges();
            _vehicleProcessTypeRepo.Delete(vehicleProcessType);
            return Ok();
        }

        [HttpPost]
        public IActionResult GetById(int id)
        {
            //return Ok(_context.VehicleProcessTypes.Find(id));
            return Ok(_vehicleProcessTypeRepo.GetById(id));
        }
    }
}

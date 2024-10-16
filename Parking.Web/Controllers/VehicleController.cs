using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Parking.Data;
using Parking.Models;
using Parking.Repository.Abstract;
using Parking.Repository.Shared.Abstract;
using System.Numerics;
using System.Security.Claims;

namespace Parking.Web.Controllers
{
    [Authorize] //Bu controller ı sadece authorize olanlar çağırabilir. //Hem admin hem users görüntüleyeceği için login olanlar görebilsin diye
    public class VehicleController : Controller
    {

        //private readonly ApplicationDbContext _context;

        //public VehicleController(ApplicationDbContext context)
        //{
        //    _context = context;
        //}



        private readonly IVehicleRepository _vehicleRepository;

        public VehicleController(IVehicleRepository vehicleRepository)
        {
            _vehicleRepository = vehicleRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GetAll() 
        {
            bool isAdmin = User.IsInRole("Admin");
            int userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);

            return Json(new {data =_vehicleRepository.GetAll(isAdmin,userId)});
            
        }


        [HttpPost]
        public IActionResult Add(Vehicle vehicle) 
        {
            //_context.Vehicles.Add(vehicle);
            //_context.SaveChanges();
            //return Ok(vehicle);
            return Ok(_vehicleRepository.Add(vehicle));

        }

        [HttpPost]
        public IActionResult Update(Vehicle vehicle) 
        {
            //_context.Vehicles.Update(vehicle);
            //_context.SaveChanges();
            //return Ok(vehicle);
            return Ok(_vehicleRepository.Update(vehicle));

        }

        [HttpPost]
        public IActionResult Delete(int id) 
        {
            //Vehicle vehicle = _context.Vehicles.Find(id);
            //vehicle.IsDeleted = true;
            //_context.Vehicles.Update(vehicle);
            //_context.SaveChanges();
            //return Ok();
            _vehicleRepository.DeleteById(id);
            return Ok();

        }

        [HttpPost]
        public IActionResult HardDelete(Vehicle vehicle)
        {
            //_context.Vehicles.Remove(vehicle);
            //_context.SaveChanges();
            _vehicleRepository.Delete(vehicle);
            return Ok();
        }

        [HttpPost]
        public IActionResult GetById(int id) 
        {
            //return Ok(_context.Vehicles.Find(id));
            return Ok(_vehicleRepository.GetById(id));
        }
    }
}

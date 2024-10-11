using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Parking.Data;
using Parking.Models;
using Parking.Repository.Shared.Abstract;
using System.Numerics;
using System.Security.Claims;

namespace Parking.Web.Controllers
{
    [Authorize] //Bu controller ı sadece authorize olanlar çağırabilir. //Hem admin hem users görüntüleyeceği için login olanlar görebilsin diye
    public class VehicleController : Controller
    {
       /*
        private readonly ApplicationDbContext _context;

        public VehicleController(ApplicationDbContext context)
        {
            _context = context;
        }
       */

        private readonly IRepository<Vehicle> _vehicleRepository;

        public VehicleController(IRepository<Vehicle> vehicleRepository)
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

            return Json(new {data =_vehicleRepository.GetAll(), userId = userId});
         
            /*

            //Bu satırda, kullanıcı rolü kontrol ediliyor. Eğer giriş yapan kullanıcı Admin rolüne sahipse, aşağıdaki işlemler yapılacak. Aksi durumda, normal bir kullanıcı olarak kabul edilecek ve farklı bir sorgu çalıştırılacak.
            if (User.IsInRole("Admin"))
            {
                //Eğer kullanıcı Admin ise, Vehicles (Araçlar) tablosundaki silinmemiş (IsDeleted = false) tüm araçlar sorgulanır.Select metodu ile her bir araçtan belli başlı bilgiler(adı, kilometre sayacı, plaka numarası, vb.) alınır ve result adında bir değişkene atanır.Admin kullanıcı tüm araçları görebilir, herhangi bir kullanıcıya bağlı olmasa bile.
                var result = _context.Vehicles.Where(v => !v.IsDeleted).Select(v => new Vehicle
                {
                    Name = v.Name,
                    Odometer = v.Odometer,
                    Id = v.Id,
                    LicensePlate = v.LicensePlate,
                    VehicleType = v.VehicleType,
                    AppUser = v.AppUser
                });
                return Json(new { data = result });
            }
            else 
            {
                //Eğer kullanıcı Admin değilse, kullanıcının kimliği belirlenir. User.FindFirst(ClaimTypes.NameIdentifier) kullanılarak, giriş yapan kullanıcının ID’si elde edilir ve integer (tam sayı) formatına çevrilir. Bu kullanıcı ID’si appUserId değişkenine atanır. Sorgu, sadece bu kullanıcıya (AppUserId) ait ve silinmemiş (IsDeleted = false) araçları döndürmek üzere yapılır.
                int appUserId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
                var result = _context.Vehicles.Where(v => !v.IsDeleted && v.AppUserId == appUserId);
                return Json(new { data = result });
            }

            */
        }


        [HttpPost]
        public IActionResult Add(Vehicle vehicle) 
        {
            //_context.Vehicles.Add(vehicle);
            //_context.SaveChanges();
            _vehicleRepository.Add(vehicle);
            return Ok(vehicle);
        }

        [HttpPost]
        public IActionResult Update(Vehicle vehicle) 
        {
            //_context.Vehicles.Update(vehicle);
            //_context.SaveChanges();
            _vehicleRepository.Update(vehicle);
            return Ok(vehicle);
        }

        [HttpPost]
        public IActionResult Delete(int id) 
        {
            //Vehicle vehicle = _context.Vehicles.Find(id);
            //vehicle.IsDeleted= true;
            //_context.Vehicles.Update(vehicle);
            //_context.SaveChanges();
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

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Parking.Data;
using Parking.Models;
using System.Numerics;
using System.Security.Claims;

namespace Parking.Web.Controllers
{
    [Authorize]
    public class VehicleController : Controller
    {
        private readonly ApplicationDbContext _context;

        public VehicleController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GettAll() 
        {
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
        }

        [HttpPost]
        public IActionResult Add(Vehicle vehicle) 
        {
            _context.Vehicles.Add(vehicle);
            _context.SaveChanges();
            return Ok(vehicle);
        }

        [HttpPost]
        public IActionResult Update(Vehicle vehicle) 
        {
            _context.Vehicles.Update(vehicle);
            _context.SaveChanges();
            return Ok(vehicle);
        }

        [HttpPost]
        public IActionResult Delete(int id) 
        {
            Vehicle vehicle = _context.Vehicles.Find(id);
            vehicle.IsDeleted= true;
            _context.Vehicles.Update(vehicle);
            _context.SaveChanges();
            return Ok(vehicle);
        }
    }
}

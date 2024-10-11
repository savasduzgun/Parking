using Parking.Data;
using Parking.Models;
using Parking.Repository.Abstract;
using Parking.Repository.Shared.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Parking.Repository.Concrete
{
    public class VehicleRepository : Repository<Vehicle>, IVehicleRepository
    {
        private readonly ApplicationDbContext _context;

        public VehicleRepository(ApplicationDbContext context) : base(context) 
        {
            _context = context;
        }

        public IEnumerable<Vehicle> GetAll(bool isAdmin, int userId)
        {
            //Bu satırda, kullanıcı rolü kontrol ediliyor. Eğer giriş yapan kullanıcı Admin rolüne sahipse, aşağıdaki işlemler yapılacak. Aksi durumda, normal bir kullanıcı olarak kabul edilecek ve farklı bir sorgu çalıştırılacak.
            if (isAdmin)
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
                return result;
            }
            else
            {
                //Eğer kullanıcı Admin değilse, kullanıcının kimliği belirlenir. User.FindFirst(ClaimTypes.NameIdentifier) kullanılarak, giriş yapan kullanıcının ID’si elde edilir ve integer (tam sayı) formatına çevrilir. Bu kullanıcı ID’si appUserId değişkenine atanır. Sorgu, sadece bu kullanıcıya (AppUserId) ait ve silinmemiş (IsDeleted = false) araçları döndürmek üzere yapılır.
                
                var result = _context.Vehicles.Where(v => !v.IsDeleted && v.AppUserId == userId);
                return result;
            }
        }
    }
}

using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Parking.Data;
using Parking.Models;
using Parking.Repository.Abstract;
using System.Security.Claims;

namespace Parking.Web.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserRepository _appUserRepository;

        public UserController(IUserRepository appUserRepository)
        {
            _appUserRepository = appUserRepository;
        }

        //private readonly ApplicationDbContext _context;
        //public UserController(ApplicationDbContext context)
        //{
        //    _context = context; 
        //}

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GetAll() //Bütün kullanıcıları verecek method
        {
            /* return Json(new {data=_context.Users.Where(u=>!u.IsDeleted).ToList()});*/ //Isdeleted false olanları verecek

            return Json(new { data = _appUserRepository.GetAll() });
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(AppUser appUser)
        {
            AppUser user = _appUserRepository.GetFirstOrDefault(u => u.UserName == appUser.UserName && u.Password == appUser.Password);
            if (user != null)
            {
                List<Claim> claims = new List<Claim>();
                claims.Add(new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()));
                claims.Add(new Claim(ClaimTypes.Name, user.UserName));
                claims.Add(new Claim(ClaimTypes.GivenName, user.FullName));
                claims.Add(new Claim(ClaimTypes.Role, user.IsAdmin ? "Admin" : "User"));

                ClaimsIdentity identity = new ClaimsIdentity(claims,CookieAuthenticationDefaults.AuthenticationScheme);

                await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
                await HttpContext.SignInAsync(new ClaimsPrincipal(identity));

                return RedirectToAction("Index", "Vehicle");
            }

            return View(); //Login sayfasına geri döner.
        }

        public async Task<IActionResult> Logout() 
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            return RedirectToAction("Login");
        }

        [HttpPost]
        public IActionResult Add(AppUser appUser)
        {
            //_context.Users.Add(appUser);
            //_context.SaveChanges();
            //return Ok(appUser); //Aynı nesneyi dönsün sayfa yenilenmeden datatable işlemleri yapılabilsin.
            return Ok(_appUserRepository.Add(appUser));
        }

        [HttpPost]
        public IActionResult Delete(int id) 
        {
            //AppUser appUser = _context.Users.Find(id);
            //appUser.IsDeleted = true;
            //_context.Users.Update(appUser);
            //_context.SaveChanges();
            //return Ok();
            return Ok(_appUserRepository.DeleteById(id));
        }

        [HttpPost]
        public IActionResult Update(AppUser appUser) 
        {
            //_context.Users.Update(appUser);
            //_context.SaveChanges();
            //return Ok(appUser);
            return Ok(_appUserRepository.Update(appUser));
        }

        [HttpPost]
        public IActionResult GetById(int id) 
        {
            //return Ok(_context.Users.Find(id));
            return Ok(_appUserRepository.GetById(id));
        }
    }
}

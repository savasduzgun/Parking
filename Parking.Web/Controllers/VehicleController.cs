﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Parking.Data;
using Parking.Models;
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
            if (User.IsInRole("Admin"))
            {
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
    }
}

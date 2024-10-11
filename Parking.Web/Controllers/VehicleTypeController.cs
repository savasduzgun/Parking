﻿using Microsoft.AspNetCore.Mvc;
using Parking.Data;
using Parking.Models;
using Parking.Repository.Shared.Abstract;

namespace Parking.Web.Controllers
{
    public class VehicleTypeController : Controller
    {
        private readonly IRepository<VehicleType> _vehicleTypeRepo;

        public VehicleTypeController(IRepository<VehicleType> vehicleTypeRepo)
        {
            _vehicleTypeRepo = vehicleTypeRepo;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GetAll() 
        { 
            return Json(new {Data = _context.VehicleTypes.Where(vt=>!vt.IsDeleted)});
        }

        [HttpPost]
        public IActionResult Add(VehicleType vehicleType) 
        {
            _context.VehicleTypes.Add(vehicleType);
            _context.SaveChanges();
            return Ok(vehicleType);
        }

        [HttpPost]
        public IActionResult HardDelete(VehicleType vehicleType)
        {
            _context.VehicleTypes.Remove(vehicleType);
            _context.SaveChanges();
            return Ok();
        }

        [HttpPost]
        public IActionResult Delete(int id) 
        {
            var vehicleType = _context.VehicleTypes.Find(id);
            vehicleType.IsDeleted = true;
            vehicleType.DateDeleted = DateTime.Now;
            _context.VehicleTypes.Update(vehicleType);
            _context.SaveChanges();
            return Ok();
        }

        [HttpPost]
        public IActionResult Update(VehicleType vehicleType) 
        {
            _context.VehicleTypes.Update(vehicleType);
            _context.SaveChanges();
            return Ok(vehicleType);
        }

        [HttpPost]
        public IActionResult GetById(int id) 
        {
            return Ok(_context.VehicleTypes.Find(id));
        }
    }
}

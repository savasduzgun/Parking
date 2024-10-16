using Microsoft.AspNetCore.Mvc;
using Parking.Models;
using Parking.Repository.Abstract;

namespace Parking.Web.Controllers
{
    public class VehiclePhotoController : Controller
    {
        private readonly IVehiclePhotoRepository _vehiclePhotoRepository;

        public VehiclePhotoController(IVehiclePhotoRepository vehiclePhotoRepository)
        {
            _vehiclePhotoRepository = vehiclePhotoRepository;
        }

        public IActionResult Index(Guid id)
        {
            return View(_vehiclePhotoRepository.GetAll(id));
        }

        //[HttpPost]
        //public IActionResult Add(List<VehiclePhoto> vehiclePhotos)
        //{
        //}

        [HttpPost]
        public IActionResult Delete(VehiclePhoto vehiclePhoto)
        { 
            return Ok(_vehiclePhotoRepository.Delete(vehiclePhoto));
        }

        [HttpPost]
        public IActionResult Update(VehiclePhoto vehiclePhoto)
        {
            return Ok(_vehiclePhotoRepository.Update(vehiclePhoto));
        }
    }
}

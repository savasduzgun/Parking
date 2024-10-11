using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Parking.Data;
using Parking.Models;
using Parking.Repository.Shared.Abstract;

namespace Parking.Web.Controllers
{
    [Authorize(Roles ="Admin")] //Bu sayfaya sadece admin tipi kullanıcılar girebilir.
    public class PolicyTypeController : Controller
    {
        private readonly IRepository<PolicyType> _policyTypeRepo;

        public PolicyTypeController(IRepository<PolicyType> policyTypeRepo)
        {
            _policyTypeRepo = policyTypeRepo;
        }

        public IActionResult Index()
        {
            return View();
        }

        //Listeleme
        [HttpGet]
        public IActionResult GetAll()
        {
            //return Json(new { data = _context.PolicyTypes.Where(pt => !pt.IsDeleted) });
            return Json(new { data = _policyTypeRepo.GetAll()});
        }

        //Ekleme
        [HttpPost]
        public IActionResult Add(PolicyType policyType)
        {
            //_context.PolicyTypes.Add(policyType);
            //_context.SaveChanges();
            _policyTypeRepo.Add(policyType);
            return Ok(policyType);
        }

        //SoftDelete
        [HttpPost]
        public IActionResult Delete(int id)
        {
            //var policyType = _context.PolicyTypes.Find(id);
            //if (policyType != null)
            //{
            //    policyType.IsDeleted = true;
            //    _context.PolicyTypes.Update(policyType);
            //    _context.SaveChanges();
            //    return Ok(policyType);
            //}
            //else
            //{
            //    return BadRequest("Gönderilen ID geçersizdir.");
            //}
            var result = _policyTypeRepo.DeleteById(id);
            if (result != null)
            {
                return Ok(result);
            }
            else 
            {
                return BadRequest("Gödeilen ID geçersizdir.");
            }
            
        }

        //Silme
        [HttpPost]
        public IActionResult HardDelete(PolicyType policyType)
        {
            //_context.PolicyTypes.Remove(policyType);
            //_context.SaveChanges();
            _policyTypeRepo.Delete(policyType);
            return Ok();
        }

        //Update
        [HttpPost]
        public IActionResult Update(PolicyType policyType) 
        {
            _context.PolicyTypes.Update(policyType);
            _context.SaveChanges();
            return Ok();
        }

        [HttpPost]
        public IActionResult GetById(int id) 
        {
            return Ok(_context.PolicyTypes.Find(id));
        }
    }
}

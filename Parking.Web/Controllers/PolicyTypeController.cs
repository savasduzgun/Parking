using Microsoft.AspNetCore.Mvc;
using Parking.Data;
using Parking.Models;

namespace Parking.Web.Controllers
{
    public class PolicyTypeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PolicyTypeController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        //Listeleme
        public IActionResult GetAll() 
        {
            return Json(new {data=_context.PolicyTypes.Where(pt=>!pt.IsDeleted)});
        }

        //Ekleme
        [HttpPost]
        public IActionResult Add(PolicyType policyType)
        {
            _context.PolicyTypes.Add(policyType);
            _context.SaveChanges();
            return Ok(policyType);
        }
    }
}

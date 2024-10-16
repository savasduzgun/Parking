using Microsoft.AspNetCore.Mvc;
using Parking.Models;
using Parking.Repository.Shared.Abstract;

namespace Parking.Web.Controllers
{
    public class PolicyController : Controller
    {
        private readonly IRepository<Policy> _policyRepository;

        public PolicyController(IRepository<Policy> policyRepository)
        {
            _policyRepository = policyRepository;
        }

        public IActionResult Index()
        {
            return View();
        }
        //public IActionResult GetAll(Guid id)
        //{


        //}
    }
}

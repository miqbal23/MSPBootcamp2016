using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using NorthwindRepository.Repositories;

namespace BootcampMvc.Controllers
{
    public class CustomerRouteController : Controller
    {
        private CustomerRepository custRepo = new CustomerRepository();

        // GET: CustomerAJAX
        public ActionResult Index()
        {
            return View(custRepo.GetAllData().Take(5)); // return first 5 results, equal to SQL's TOP
        }

        public ActionResult Search(string id)
        {
            return View(custRepo.Search(id))           
        }
    }
}
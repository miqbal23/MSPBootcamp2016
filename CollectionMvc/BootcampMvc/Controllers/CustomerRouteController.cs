using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using NorthwindRepository.Repositories;

namespace BootcampMvc.Controllers
{
    // route attributte for class
    [RoutePrefix("CustomerData")]
    public class CustomerRouteController : Controller
    {
        private CustomerRepository custRepo = new CustomerRepository();

        // route attribute for attribute routing
        //[Route("CustomerData/AllCustomer")]
        // if using RoutePrefix
        [Route("AllCustomer")]
        // GET: CustomerAJAX
        public ActionResult Index()
        {
            return View(custRepo.GetAllData().Take(5)); // return first 5 results, equal to SQL's TOP
        }

        // attribute routing with query
        [Route("CustomerData/{id}")]
        [Route("{id}")]
        public ActionResult Search(string id)
        {
            return View(custRepo.Search(id));           
        }
    }
}
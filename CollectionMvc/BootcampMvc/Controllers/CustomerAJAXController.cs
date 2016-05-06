using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using NorthwindRepository.Repositories;

namespace BootcampMvc.Controllers
{
    // this class will be used for partial postback
    public class CustomerAJAXController : Controller
    {
        private CustomerRepository custRepo = new CustomerRepository();
        
        // GET: CustomerAJAX
        public ActionResult Index()
        {
            return View(custRepo.GetAllData().Take(10)); // return first 10 results, equal to SQL's TOP
        }

        public ActionResult Search(string name)
        {
            // because no search method by CompanyName field, use Where method and lambda expression
            var cust = custRepo.GetAllData().Where(c => c.CompanyName.Contains(name));
            if (Request.IsAjaxRequest())
            {
                // if request by AJAX, do partial postback using partial view
                return PartialView("_Search", cust);
            }
            else
            {
                // if not, return full postback with a view
                return View(cust);
            }
        }
    }
}
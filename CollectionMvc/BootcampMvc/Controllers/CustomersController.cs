using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

using DataAccessLayer;
using NorthwindRepository.Interfaces;
using NorthwindRepository.Repositories;

namespace BootcampMvc.Controllers
{
    // this attribute signifies controllers that require user authorization
    [Authorize]
    public class CustomersController : Controller
    {
        // for connecting to DataAccessLayer, change db connection with this
        //private NorthwindEntities db = new NorthwindEntities();
        private IEntityRepository<Customer, string> custRepo;

        public CustomersController()
        {
            // instantiating connection, refer to repository
            custRepo = new CustomerRepository();
            // all connection with db changed with custRepo
        }

        // allow unauthorized users to access view
        [AllowAnonymous]
        // GET: Customers
        public ActionResult Index()
        {
            //return View(db.Customers.ToList());
            return View(custRepo.GetAllData());
        }

        [AllowAnonymous]
        // GET: Customers/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Customer customer =
                //db.Customers.Find(id);
                custRepo.Search(id);

            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // GET: Customers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Customers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        // [Bind(Include)] is used to whitelist field available for data input. Other than whitelisted will be ignored. Good example to avoid overposting attack
        public ActionResult Create([Bind(Include = "CustomerID,CompanyName,ContactName,ContactTitle,Address,City,Region,PostalCode,Country,Phone,Fax")] Customer customer)
        {
            // sample error to throw exception
            bool isError = true;
            if (isError)
            {
                throw new Exception();
            }
            
            try
            {
                if (ModelState.IsValid)
                {
                    // because Add and SaveChange already implemented, we just need Insert
                    //db.Customers.Add(customer);
                    //db.SaveChanges();
                    custRepo.Insert(customer);
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                // debugging purpose
                // add error reporting feature here

                ViewBag.ErrorMsg = ex.ToString();
            }
                       
            return View(customer);
        }

        // GET: Customers/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Customer customer =
                //db.Customers.Find(id);
                custRepo.Search(id);

            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // POST: Customers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CustomerID,CompanyName,ContactName,ContactTitle,Address,City,Region,PostalCode,Country,Phone,Fax")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                // because we already implemented State.Modified and SaveChange, we just need Update
                //db.Entry(customer).State = EntityState.Modified;
                //db.SaveChanges();
                custRepo.Update(customer);
                return RedirectToAction("Index");
            }
            return View(customer);
        }

        // authorize attribute to allow only certain users
        [Authorize(Users = "admin, user1")]
        // authorize attribute to allow only users with certain roles
        [Authorize(Roles = "Administrator, Members")]        
        // GET: Customers/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Customer customer =
                //db.Customers.Find(id);
                custRepo.Search(id);

            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // authorize attribute with combined parameters
        [Authorize(Roles = "Administrators", Users = " admin")]
        // POST: Customers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            // because we already implemented Remove and SaveChange, we just need the Delete
            //Customer customer = db.Customers.Find(id);
            //db.Customers.Remove(customer);
            //db.SaveChanges();
            custRepo.Delete(id);

            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                // because we don't need database connection, you can safely comment this code
                //db.Dispose();
            }
            base.Dispose(disposing);
        }

        public JsonResult CheckCustomerID(string CustomerID)
        {
            var cust = custRepo.Search(CustomerID);
            bool isValid;

            if (cust != null) isValid = false;
            else isValid = true;

            return Json(isValid, JsonRequestBehavior.AllowGet);
        }
    }
}

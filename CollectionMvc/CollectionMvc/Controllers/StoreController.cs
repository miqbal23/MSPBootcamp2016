using CollectionMvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CollectionMvc.Controllers
{
    public class StoreController : Controller
    {
        // GET: Store
        public string Index()
        {
            // simple Controller return value to View
            return "Hello from Store.Index";
        }

        public string SampleQuery(string category)
        {
            // simple Web with query
            return HttpUtility.HtmlEncode("Hello from SampleQuery with category: " + category);
        }

        public ActionResult Home()
        {
            // param empty = View equal method name
            // return View(); 

            // if filled, will called that View (only if inside same Controller)
            //return View("About");

            //if you want to refer to Views from different Controller
            return View("~/Views/Home/About.cshtml");
        }

        public ActionResult DataSample()
        {
            // using ViewData (array-type)
            ViewData["event"] = "MSP Bootcamp";
            ViewData["place"] = "Hotel Neo";

            // using ViewBag (property-type)
            ViewBag.Event = "MSP Bootcamp";
            ViewBag.Place = "Hotel Neo";

            // using simple array of data
            var books = new List<string>() { "ASP.NET", "SQL Server", "Windows 10" };
            ViewBag.booklist = books;
            
            // using collection of datas        
            List<Participant> participants = new List<Participant>()
            {
                new Participant() {PersonId=1, Name="Muhamad Iqbal", Region="Bodeta" },
                new Participant() {PersonId=2, Name="Ade Haryanto", Region="Sumatera" }
            };

            // change content of bracket with data you want show at View
            return View();
        }


    }
}
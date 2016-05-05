using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CollectionMvc.Models;

namespace CollectionMvc.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            List<Participant> participants = new List<Participant>()
            {
                new Participant() {PersonId=1, Name="Muhamad Iqbal", Region="Bodeta" },
                new Participant() {PersonId=2, Name="Ade Haryanto", Region="Sumatera" }
            };

            return View(participants);
        }
    }
}
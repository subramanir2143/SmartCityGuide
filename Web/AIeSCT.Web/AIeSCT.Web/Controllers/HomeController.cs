using AIeSCT.Web.Hubs;
using AIeSCT.Web.Models;
using AIeSCT.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AIeSCT.Web.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult Search(string searchText)
        {
            return View();
        }

        public ActionResult Admin()
        {
            List<IdealResultClass> parking = new List<IdealResultClass>();
            IdealResultClass parking1 = new IdealResultClass
            {
                Availability = true,
                Id = new Guid("7D7D4003-5F61-42C8-99D7-208900B92860"),
                Name = "Kesavadasapuram"
            };
            IdealResultClass parking2 = new IdealResultClass
            {
                Availability = true,
                Id = new Guid("B9F4A39A-724C-412E-9FF3-C11AEED95541"),
                Name = "Thampanoor"
            };
            IdealResultClass parking3 = new IdealResultClass
            {
                Availability = true,
                Id = new Guid("E1C67A94-1621-49BB-81C0-CD925021C93B"),
                Name = "Vazhuthacaud"
            };
            IdealResultClass parking4 = new IdealResultClass
            {
                Availability = true,
                Id = new Guid("A783B165-84C8-47B8-9EB2-EF3C1F923F1B"),
                Name = "Kazhakoottam"
            };
            parking.Add(parking1); parking.Add(parking2); parking.Add(parking3);parking.Add(parking4);
            return View(parking);
        }

        public ActionResult ToggleState()
        {
            List<ParkingPlaceViewModel> parking = new List<ParkingPlaceViewModel>();
            ParkingPlaceViewModel parking1 = new ParkingPlaceViewModel
            {
                Availability = true,
                Id = new Guid("5a5a1239-9a3c-43dc-b4b1-a702274993c1"),
                Name = "Statue"
            };
            ParkingPlaceViewModel parking2 = new ParkingPlaceViewModel
            {
                Availability = false,
                Id = new Guid("5c033074-e26e-457b-b2d3-730aaf88fe38"),
                Name = "Pattom"
            };
            ParkingPlaceViewModel parking3 = new ParkingPlaceViewModel
            {
                Availability = true,
                Id = new Guid("71a3f70c-a478-4a66-a058-2b69ea7b4425"),
                Name = "EastFort"
            };
            parking.Add(parking1); parking.Add(parking2); parking.Add(parking3);
            return View(parking);            
        }

        public ActionResult ClientCall(Guid id, bool availability)
        {

            ToggleState toggle = new ToggleState();
            toggle.Send(id, availability);
            return Json(new { redirectToUrl = Url.Action("ButtonPage", "Home") }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult PostAction(ParkingPlaceViewModel parkingItem)
        {
            return null;
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
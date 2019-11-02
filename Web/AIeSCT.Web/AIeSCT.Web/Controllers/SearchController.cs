using AIeSCT.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Mvc;

namespace AIeSCT.Web.Controllers
{
    [AllowAnonymous]
    public class SearchController : Controller
    {
        // GET: Search
        public ActionResult Results(string searchText)
        {
            IdealIntentResult Result =GetDataFromLuisApi(searchText);
            if (Result==null||Result.IdealResult.Count()==0)
            {
                return RedirectToAction("Index", "Home");
            }

            foreach(IdealResultClass item in Result.IdealResult)
            {
                item.Description = "Place is near your location";
                item.PredictionPerc = Math.Round(Math.Abs(item.PredictionPerc),2);
            }

            return View(Result);
        }

        private IdealIntentResult GetDataFromLuisApi(string searchText)
        {

            IdealIntentResult result = null;
            
            if (!String.IsNullOrEmpty(searchText))
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri("http://aiesctapi20170113083032.azurewebsites.net/");
                HttpResponseMessage resp = client.GetAsync("api/Luis/" + searchText).Result;
                resp.EnsureSuccessStatusCode();
                result = resp.Content.ReadAsAsync<IdealIntentResult>().Result;
            }

            return result;
        }
    }
}
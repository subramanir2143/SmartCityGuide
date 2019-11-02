using AIeSCT.Api.Providers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AIeSCT.Api.Controllers
{
    public class ParkingController : ApiController
    {
        ParkingProvider parkingprovider;
        public ParkingController()
        {
            parkingprovider = new ParkingProvider();
        }
        // GET api/<controller>
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        public void Post([FromUri]string id)
        {
            this.parkingprovider.ToggleStatus(new Guid(id));
        }

      

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}
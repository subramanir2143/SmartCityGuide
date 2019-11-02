using AIeSCT.Api.Data;
using AIeSCT.Api.Providers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AIeSCT.Api.Controllers
{
    public class LuisController : ApiController
    {
        QueryResultProvider queryResultprovider;
        public LuisController()
        {
            queryResultprovider = new QueryResultProvider();
        }
        // GET api/<controller>
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        public IdealIntentResult Get(string id)
        {
            return this.queryResultprovider.getResult(id);
        }

        // POST api/<controller>
        public void Post([FromBody]string value)
        {
            Search luissearchprovider = new Search();
            luissearchprovider.GetIntent(value);
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
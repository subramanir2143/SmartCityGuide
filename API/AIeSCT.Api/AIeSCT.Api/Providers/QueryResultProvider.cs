using AIeSCT.Api.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace AIeSCT.Api.Providers
{
    public class StringTable
    {
        public string[] ColumnNames { get; set; }
        public string[,] Values { get; set; }
    }

    public class QueryResultProvider
    {
        Search luissearchprovider;
        AISCT context;

        public QueryResultProvider()
        {
            luissearchprovider = new Search();
          
        }

        //public IEnumerable<IdealResultClass> getResult(string query)
        //{
        //    Rootobject result = luissearchprovider.GetIntent(query);
        //    IEnumerable<IdealResultClass> Idealresults;
        //    if (result.topScoringIntent.intent == "Parking")
        //    {
        //        IEnumerable<ParkingPlace> places = this.context.ParkingPlaces;
        //        Idealresults = places.Select(this.populateIdealClass);
        //    }
        //    else
        //    {
        //        Idealresults = Enumerable.Empty<IdealResultClass>();
        //    }

        //    return Idealresults;
        //}

        public IdealIntentResult getResult(string query)
        {
            IdealIntentResult idealIntentResults = new IdealIntentResult();
            Rootobject result = luissearchprovider.GetIntent(query);
            IEnumerable<IdealResultClass> Idealresults;
            if (result.topScoringIntent.intent == "Parking")
            {
                using (context = new AISCT())
                {
                    IEnumerable<ParkingPlace> places = this.context.ParkingPlaces;
                    Idealresults = places.Select(this.populateIdealClass).ToList();
                }
            }
            else
            {
                Idealresults = Enumerable.Empty<IdealResultClass>();
            }

            idealIntentResults.IdealResult = Idealresults;
            idealIntentResults.Intent = result.topScoringIntent.intent;

            foreach (var item in idealIntentResults.IdealResult)
            {

                using (var client = new HttpClient())
                {
                    var scoreRequest = new
                    {

                        Inputs = new Dictionary<string, StringTable>() {
                        {
                            "input1",
                            new StringTable()
                            {
                                ColumnNames = new string[] {"Id", "Name", "Time"},
                                Values = new string[,] {  { item.Id.ToString(), item.Name, "2" }  }
                            }
                        },
                    },
                        GlobalParameters = new Dictionary<string, string>()
                        {
                        }
                    };

                    const string apiKey = "Alu4X4UkwsdnPYzFm7SlV7aNU+JWu/ccaOpkE3id8nE2Y5s9bcZXSZ4v2KeCnPb5V29qTKYs9JiIMB586EOYfw=="; // Replace this with the API key for the web service
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", apiKey);

                    client.BaseAddress = new Uri("https://ussouthcentral.services.azureml.net/workspaces/5b72fd27c4344fd2bb1e8e475b5dcd4c/services/92d784fe2890403c960091cca99913c0/execute?api-version=2.0&details=true");

                    // WARNING: The 'await' statement below can result in a deadlock if you are calling this code from the UI thread of an ASP.Net application.
                    // One way to address this would be to call ConfigureAwait(false) so that the execution does not attempt to resume on the original context.
                    // For instance, replace code such as:
                    //      result = await DoSomeTask()
                    // with the following:
                    //      result = await DoSomeTask().ConfigureAwait(false)


                    var response = client.PostAsJsonAsync("", scoreRequest);

                    if (response.Result.IsSuccessStatusCode)
                    {
                        var rst = response.Result.Content.ReadAsStringAsync();

                        var obj = JsonConvert.DeserializeObject<Rootobject2>(rst.Result);

                        string pridctVal = obj.Results.output1.value.Values.FirstOrDefault().FirstOrDefault();
                        item.PredictionPerc= double.Parse(pridctVal) * 100;
                    }

                }
            }

            return idealIntentResults;
        }

        private IdealResultClass populateIdealClass(ParkingPlace x)
        {
            return new IdealResultClass
            {
                Id = x.Id,
                Availability = x.Availability,
                Name = x.Name
            };

        }

    }
}
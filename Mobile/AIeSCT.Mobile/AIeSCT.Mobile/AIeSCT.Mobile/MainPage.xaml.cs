using AIeSCT.Mobile.Data;
using AIeSCT.Mobile.ViewModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AIeSCT.Mobile
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }
        private const string RequestUrl =
           "http://aiesctapi20170113083032.azurewebsites.net/";
        protected  override void OnAppearing()
        {
            MessagingCenter.Subscribe<MainViewModel, string>(this, "Search", (sender, arg) => {

                HttpClient client = new HttpClient();
             
                client.BaseAddress = new Uri("http://aiesctapi20170113083032.azurewebsites.net/");
                HttpResponseMessage resp = client.GetAsync("api/Luis/" + arg).Result;
                resp.EnsureSuccessStatusCode();
                var rest = resp.Content.ReadAsStringAsync().Result;
                var result = JsonConvert.DeserializeObject<ResultContent>(rest);
                var page = new ListingPage();
             //   var myObservableCollection = new ObservableCollection<ResultContent>(result);
                foreach (var item in result.Results)
                {
                    item.AvialableText = item.Availability ? "Bingo! This is avialable" : "";
                }
                page.BindingContext = new ListingViewModel { Coll = result.Results,Intent=result.Intent };

                this.Navigation.PushModalAsync(page);


                // this.Navigation.PushModalAsync(page);

            });
        }
    }
}

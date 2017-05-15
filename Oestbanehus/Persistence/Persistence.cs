using Newtonsoft.Json.Linq;
using Oestbanehus.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Oestbanehus.Models;
using System.Collections.ObjectModel;
using Newtonsoft.Json;

namespace Oestbanehus.Persistence
{
    class Persistence
    {
        public static async Task<ObservableCollection<Building>> getBuildingsAsync()
        {
            ObservableCollection<Building> allBuildings = new ObservableCollection<Building>();
            const string ServerUrl = "http://localhost:8005";
            HttpClientHandler handler = new HttpClientHandler();
            handler.UseDefaultCredentials = true;

            using (var client = new HttpClient(handler))
            {
                client.BaseAddress = new Uri(ServerUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                try
                {
                    var response = client.GetAsync("api/Buildings").Result;
                    if (response.IsSuccessStatusCode)
                    {
                        string BuildingsData = response.Content.ReadAsStringAsync().Result;

                        allBuildings = (ObservableCollection<Building>)JsonConvert.DeserializeObject(BuildingsData, typeof(ObservableCollection<Building>));

                        var a = allBuildings;

                        //JArray json = JArray.Parse(BuildingsData);
                        //foreach(JObject building in json.Children<JObject>())
                        //{
                        //    var a = JObject.Parse(building);
                        //    //output.Add(building);
                        //}

                        
                    }
                    return allBuildings;
                }
                catch (Exception ex)
                {
                    return null;
                }

            }
        }
    }
}

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
        //ALL BUILDINGS
        public static async Task<ObservableCollection<Building>> getBuildingsAsync()
        {
            ObservableCollection<Building> allBuildings = new ObservableCollection<Building>();
            const string ServerUrl = "http://localhost:8416";
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
                    }
                    return allBuildings;
                }
                catch (Exception ex)
                {
                    return null;
                }
            }
        }


        //ALL APARTMENTS
        public static async Task<ObservableCollection<Apartment>> getApartmentsAsync()
        {
            ObservableCollection<Apartment> allApartments = new ObservableCollection<Apartment>();
            const string ServerUrl = "http://localhost:8416";
            HttpClientHandler handler = new HttpClientHandler();
            handler.UseDefaultCredentials = true;

            using (var client = new HttpClient(handler))
            {
                client.BaseAddress = new Uri(ServerUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                try
                {
                    var response = client.GetAsync("api/Apartments").Result;
                    if (response.IsSuccessStatusCode)
                    {
                        string BuildingsData = response.Content.ReadAsStringAsync().Result;

                        allApartments = (ObservableCollection<Apartment>)JsonConvert.DeserializeObject(BuildingsData, typeof(ObservableCollection<Apartment>));
                    }
                    return allApartments;
                }
                catch (Exception ex)
                {
                    return null;
                }
            }
        }



        //ALL APARTMENTS IN ONE BUILDING
        public static async Task<ObservableCollection<Apartment>> getApartmentsInBuilding(int buildingId)
        {
            ObservableCollection<Apartment> allApartments = new ObservableCollection<Apartment>();
            const string ServerUrl = "http://localhost:8416";
            HttpClientHandler handler = new HttpClientHandler();
            handler.UseDefaultCredentials = true;

            using (var client = new HttpClient(handler))
            {
                client.BaseAddress = new Uri(ServerUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                try
                {
                    var response = client.GetAsync($"api/Apartments/{buildingId}/buildingAps").Result;
                    if (response.IsSuccessStatusCode)
                    {
                        string BuildingsData = response.Content.ReadAsStringAsync().Result;

                        allApartments = (ObservableCollection<Apartment>)JsonConvert.DeserializeObject(BuildingsData, typeof(ObservableCollection<Apartment>));
                    }
                    return allApartments;
                }
                catch (Exception ex)
                {
                    return null;
                }
            }
        }


        //APTS WITH ALL DATA
        public static async Task<ApartmentDetails> getApartmentDetails(int aptId)
        {
            ObservableCollection<ApartmentDetails> allApartments = new ObservableCollection<ApartmentDetails>();
            const string ServerUrl = "http://localhost:8416";
            HttpClientHandler handler = new HttpClientHandler();
            handler.UseDefaultCredentials = true;

            using (var client = new HttpClient(handler))
            {
                client.BaseAddress = new Uri(ServerUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                try
                {
                    var response = client.GetAsync($"api/Apartments/{aptId}").Result;
                    if (response.IsSuccessStatusCode)
                    {
                        string BuildingsData = response.Content.ReadAsStringAsync().Result;

                        allApartments = (ObservableCollection<ApartmentDetails>)JsonConvert.DeserializeObject(BuildingsData, typeof(ObservableCollection<ApartmentDetails>));
                    }
                    return allApartments[0];
                }
                catch (Exception ex)
                {
                    return null;
                }
            }
        }





        //GET CITY BY ZIP CODE
        public static async Task<City> GetCityByZip(int zipcode)
        {
            City cityObject = new City();
            const string ServerUrl = "http://localhost:8416";
            HttpClientHandler handler = new HttpClientHandler();
            handler.UseDefaultCredentials = true;

            using (var client = new HttpClient(handler))
            {
                client.BaseAddress = new Uri(ServerUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                try
                {
                    var response = client.GetAsync($"api/Cities/{zipcode}").Result;
                    if (response.IsSuccessStatusCode)
                    {
                        string BuildingsData = response.Content.ReadAsStringAsync().Result;

                        cityObject = JsonConvert.DeserializeObject(BuildingsData, typeof(City)) as City;
                    }
                    return cityObject;
                }
                catch (Exception ex)
                {
                    return null;
                }
            }
        }
    }
}

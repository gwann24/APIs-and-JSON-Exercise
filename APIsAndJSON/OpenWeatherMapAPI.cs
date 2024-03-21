using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace APIsAndJSON
{
    public static class OpenWeatherMapAPI
    {
        public static void GetCurrentTemp()
        {
            var client = new HttpClient();
            var appsettingsFile = File.ReadAllText("appsettings.json");
            var apiKey = JObject.Parse(appsettingsFile).GetValue("apiKey").ToString();
            var zipKey = JObject.Parse(appsettingsFile).GetValue("zipKey").ToString();
            var uZipCode = "";
            string openWeatherUrl;
            string openWeatherGeoUrl;
            string openWeatherResponse;
            string openWeatherGeoResponse;
            //string zipCodeURL;
            //string zipCodeReponse;
            //string stateCode;
            string cityName;
            string cityTemp;
            string cityFeelsLike;
            string geoLon = "";
            string geoLat = "";
            JArray geoDetails;
            do
            {
                Console.Clear();
                Console.WriteLine("Welcome!\nEnter the US Zip Code you wish to check current temperature for (END to quit):");
                uZipCode = Console.ReadLine();
                if (uZipCode.ToLower() != "end")
                {
                    openWeatherUrl = $"https://api.openweathermap.org/data/2.5/weather?zip={uZipCode},us&appid={apiKey}&units=imperial";
                    //zipCodeURL = $"https://www.zipcodeapi.com/rest/{zipKey}/info.json/{uZipCode}/degrees";
                    try
                    {
                        openWeatherResponse = client.GetStringAsync(openWeatherUrl).Result;
                        //zipCodeReponse = client.GetStringAsync(zipCodeURL).Result;
                        //Console.WriteLine(openWeatherResponse.ToString());
                        cityTemp = JObject.Parse(openWeatherResponse)["main"]["temp"].ToString();
                        cityName = JObject.Parse(openWeatherResponse)["name"].ToString();
                        cityFeelsLike = JObject.Parse(openWeatherResponse)["main"]["feels_like"].ToString();
                        //stateCode = JObject.Parse(zipCodeReponse)["state"].ToString();
                        geoLon = JObject.Parse(openWeatherResponse)["coord"]["lon"].ToString();
                        geoLat = JObject.Parse(openWeatherResponse)["coord"]["lat"].ToString();
                        openWeatherGeoUrl = $"https://api.openweathermap.org/geo/1.0/reverse?lat={geoLat}&lon={geoLon}&appid={apiKey}";
                        openWeatherGeoResponse = client.GetStringAsync(openWeatherGeoUrl).Result;
                        geoDetails = JArray.Parse(openWeatherGeoResponse);
                        //Console.WriteLine($"The current temperature in {geoDetails[0]["name"]}, {geoDetails[0]["state"]}, {geoDetails[0]["country"]} is {cityTemp}\u00B0F and feels like {cityFeelsLike}\u00B0F.");
                        Console.WriteLine($"The current temperature in {cityName}, {geoDetails[0]["state"]}, {geoDetails[0]["country"]} is {cityTemp}\u00B0F and feels like {cityFeelsLike}\u00B0F.");
                    }
                    catch
                    {
                        Console.WriteLine("API Error, likely an invalid Zip Code, please try again");
                    };
                    //openWeatherResponse = client.GetStringAsync(openWeatherUrl).Result;
                    //Console.WriteLine(openWeatherResponse.ToString());
                    Console.WriteLine("Press any key to continue");
                    Console.ReadKey();
                };
            } while (uZipCode.ToLower() != "end");
        }
    }
}

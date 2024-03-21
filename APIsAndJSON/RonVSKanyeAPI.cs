using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace APIsAndJSON
{
    public static class RonVSKanyeAPI
    {
        public static void KayneSays()
        {
            var client = new HttpClient();
            var kanyeURL = "https://api.kanye.rest";
            var kayneResponse = client.GetStringAsync(kanyeURL).Result;
            var kayneQuote = JObject.Parse(kayneResponse).GetValue("quote").ToString();
            Console.WriteLine($"Kayne: {kayneQuote}");
        }
        public static void RonSays()
        {
            var client = new HttpClient();
            var ronURL = "https://ron-swanson-quotes.herokuapp.com/v2/quotes";
            var ronResponse = client.GetStringAsync(ronURL).Result;
            var ronQuote = JArray.Parse(ronResponse);
            Console.WriteLine($"Ron: {ronQuote[0]}");
        }
    }
}

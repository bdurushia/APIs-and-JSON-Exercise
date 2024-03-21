﻿using Newtonsoft.Json.Linq;

namespace APIsAndJSON
{
    public class Program
    {
        static void Main(string[] args)
        {
            var client = new HttpClient();

            var kanyeURL = "https://api.kanye.rest/";
            var ronURL = "https://ron-swanson-quotes.herokuapp.com/v2/quotes";

            int timer = 10;

            do
            {
                var kanyeResponse = client.GetStringAsync(kanyeURL).Result;
                var kanyeQuote = JObject.Parse(kanyeResponse)["quote"].ToString();

                var ronResponse = client.GetStringAsync(ronURL).Result;
                var ronQuote = JArray.Parse(ronResponse).ToString().Replace('[', ' ').Replace(']', ' ').Replace('"', ' ').Trim();

                Thread.Sleep(1500);
                Console.WriteLine($"Kanye:\n{kanyeQuote}\n");
                
                Thread.Sleep(2000);
                Console.WriteLine($"Ron:\n{ronQuote}\n");

                timer++; 
            
            } while (timer > 0);

        }
    }
}

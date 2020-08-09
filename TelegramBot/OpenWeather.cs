using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace TelegramBot
{
    public static class OpenWeather
    {
        static HttpClient client = new HttpClient();
        private const string API_KEY = "04b131cf413fc3c95dc41cb0d44326d0";
        
        public static async Task<System.Net.Http.HttpResponseMessage> GiveTheWeather(string city_name)
        {
            var c = client.GetAsync(
                $"https://samples.openweathermap.org/data/2.5/weather?q={city_name}&appid={API_KEY}");
            Console.WriteLine(c.Result);
            return c.Result;
        }
        
        
    }
}
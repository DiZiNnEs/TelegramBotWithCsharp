using System;
using System.Net.Http;

namespace TelegramBot
{
    public class OpenWeather
    {
        HttpClient client = new HttpClient();

        public async void test()
        {
            var c = client.GetAsync(
                "https://samples.openweathermap.org/data/2.5/weather?q=London,uk&appid=439d4b804bc8187953eb36d2a8c26a02");
            Console.WriteLine(c.Result);
        }
    }
}
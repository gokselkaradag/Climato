using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WeatherAPI.Models;

namespace WeatherAPI.Controllers
{
    public class WeathersController : Controller
    {
        public async Task<IActionResult> Index()
        {
            WeatherModel model = new WeatherModel();
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://weatherapi-com.p.rapidapi.com/history.json?q=%C4%B0stanbul&lang=en&dt=2024-09-24&end_dt=2024-10-24"),
                Headers =
    {
        { "x-rapidapi-key", "423e0b03e1mshf1e648621fe968ap14c847jsndbb209c3460f" },
        { "x-rapidapi-host", "weatherapi-com.p.rapidapi.com" },
    },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                model = JsonConvert.DeserializeObject<WeatherModel>(body);
                return View(model);
            }
        }
    }
}

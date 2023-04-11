using Fallah_App.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System.Diagnostics;

namespace Fallah_App.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;


        public async Task<IActionResult> IndexAsync()
        {
            using (var client = new HttpClient())
            {
                var response = await client.GetAsync("https://api.open-meteo.com/v1/forecast?latitude=34.68&longitude=-1.91&hourly=temperature_2m,relativehumidity_2m,precipitation,rain,weathercode&daily=weathercode,temperature_2m_max,temperature_2m_min&timezone=auto");
                if (response.IsSuccessStatusCode)
                {
                    var data = await response.Content.ReadAsStringAsync();
                    var parsedData = JObject.Parse(data);

                    // Get the temperature and humidity values from the parsed data
                    var temperature = parsedData["hourly"]["temperature_2m"].First.Value<float>();
                    var humidity = parsedData["hourly"]["relativehumidity_2m"].First.Value<float>();

                    // Store the temperature and humidity values in ViewBag for use in the view
                    ViewBag.Temperature = parsedData;
                    ViewBag.Humidity = humidity;
                    return View();
                }
                else
                {
                    return RedirectToAction("index", "ERROR404");
                }
            }
            return View();
        }

    }
}
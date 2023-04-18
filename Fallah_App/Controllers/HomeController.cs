using Fallah_App.Service;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;


namespace Fallah_App.Controllers
{
    public class HomeController : Controller
    {

        public async Task<IActionResult> IndexAsync() 
        {
            using (var client = new HttpClient())
            {
                var response = await client.GetAsync("https://api.open-meteo.com/v1/forecast?latitude=34.68&longitude=-1.91&hourly=temperature_2m,relativehumidity_2m,precipitation,rain,weathercode&daily=weathercode,temperature_2m_max,temperature_2m_min&timezone=auto");
                if (response.IsSuccessStatusCode)
                {
                    var data = await response.Content.ReadAsStringAsync();

                    Meteo weatherData = JsonConvert.DeserializeObject<Meteo>(data);
                    ViewBag.hour =weatherData.hourly.time.Take(12);
                    ViewBag.temp = weatherData.hourly.temperature_2m.Take(12);
                    return View(weatherData);
                }
                else
                {
                    return RedirectToAction("index", "ERROR404");
                }
            }
        }

    }
}
using Fallah_App.Models;
using Fallah_App.Service;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Diagnostics;

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

                    //var parsedData = JObject.Parse(data);

                    //  var parsedData = JsonConvert.DeserializeObject;

                    // Get the temperature and humidity values from the parsed data
                    /* Meteo meteo = new Meteo();
                      meteo.timezone = (string)parsedData["timezone"];
                      meteo.time_Houre = parsedData["houre"]["time"].ToString();
                  // meteo.time_Houre = JsonConvert.DeserializeObject<List<string>>((string)parsedData["time"]);
                     ViewData["api"]= meteo.time_Houre;*/
                    Meteo weatherData = JsonConvert.DeserializeObject<Meteo>(data);
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
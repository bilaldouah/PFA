using Fallah_App.Context;
using Fallah_App.Controllers.Client;
using Fallah_App.Models;
using Fallah_App.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;
using System.Globalization;

namespace Fallah_App.Controllers
{
    public class HomeController : Controller
    {
        IMemoryCache memoryCache;

        public HomeController( IMemoryCache memoryCache)
      {
            this.memoryCache = memoryCache;

 }
        public async Task<IActionResult> IndexAsync() 
        {
           // int id = (int)HttpContext.Session.GetInt32("id");
            //float lat = db.users.OfType<Agriculteur>().Include(a=>a.Terres)


            Meteo meteo = await Meteo.getMeteo(34.68, -1.91);
            CultureInfo culture = new CultureInfo("fr-FR");
            ViewBag.Culture = culture;

            Dictionary<int, string> icon = new Dictionary<int, string>();

            icon.Add(0, "clear-sky.png");

            icon.Add(45, "fog.png");
            icon.Add(48, "fog.png");

            icon.Add(51, "drizzle.png");
            icon.Add(53, "drizzle.png");
            icon.Add(55, "drizzle.png");

            icon.Add(61, "rain.png");
            icon.Add(63, "rain.png");
            icon.Add(65, "rain.png");

            icon.Add(71, "snowy.png");
            icon.Add(73, "snowy.png");
            icon.Add(75, "snowy.png");

            icon.Add(77, "Snow grains.png");

            icon.Add(85, "Snow showers.png");
            icon.Add(86, "Snow showers.png");

            icon.Add(95, "Thunderstorm.png");
            icon.Add(96, "heavy hail.png");
            icon.Add(99, "heavy hail.png");

            // Add key-value pairs to the hash map
            for (int i = 1; i <= 3; i++)
            {
                icon.Add(i, "partly_cloudy.png");
            }

            for (int i = 56; i <= 57; i++)
            {
                icon.Add(i, "Freezing.png");
            }

            for (int i = 66; i <= 67; i++)
            {
                icon.Add(i, "Freezing.png");
            }

            for (int i = 80; i <= 82; i++)
            {
                icon.Add(i, "Rain showers.png");
            }

            ViewBag.icon = icon;
            return View(meteo);

        }

       

    }
}
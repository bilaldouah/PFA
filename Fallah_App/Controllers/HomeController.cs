using Fallah_App.Context;
using Fallah_App.Models;
using Fallah_App.Service;
using Microsoft.AspNetCore.Mvc;
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
            Meteo meteo = await Meteo.getMeteo();
            /*if (!this.memoryCache.TryGetValue("weather", out meteo))
            {
                this.memoryCache.Set("weather", Meteo.getMeteo() , TimeSpan.FromHours(2));
            }*/
            ViewBag.hour = meteo.hourly.time.Take(12);
            ViewBag.temp = meteo.hourly.temperature_2m.Take(12);
    //        ViewBag.dayName = DateTime.ParseExact("meteo.daily.time[1]", "MM/dd/yyyy", CultureInfo.InvariantCulture);
            return View(meteo);

        }

       

    }
}
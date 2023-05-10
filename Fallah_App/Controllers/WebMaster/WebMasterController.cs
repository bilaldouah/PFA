using Fallah_App.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace Fallah_App.Controllers.WebMaster
{
    public class WebMasterController : Controller
    {
        IMemoryCache memoryCache;
        MyContext db;
        public WebMasterController(MyContext db, IMemoryCache memoryCache)
        {
            this.db = db;
            this.memoryCache = memoryCache;

        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Ajouter()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Ajouter(Models.WebMaster webMaster)
        {
            db.users.Add(webMaster);
            db.SaveChanges();
            return View();
        }
    }
}

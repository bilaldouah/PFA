using Fallah_App.Context;
using Microsoft.AspNetCore.Mvc;

namespace Fallah_App.Controllers.WebMaster
{
    public class ConseilTerreController : Controller
    {
        MyContext db;

        public ConseilTerreController(MyContext db)
        {
            this.db = db;
        }

        public IActionResult Ajouter()
        {
            //ViewBag.Category=db.categoryTerres.ToList();
            return View();
        }
        [HttpPost]
        public IActionResult Ajouter(String test)
        {
           // ViewBag.Category = db.categoryTerres.ToList();
            return View();
        }
    }
}

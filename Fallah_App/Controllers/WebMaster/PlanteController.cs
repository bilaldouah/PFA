using Fallah_App.Context;
using Fallah_App.Models;
using Microsoft.AspNetCore.Mvc;

namespace Fallah_App.Controllers.WebMaster
{
    public class PlanteController : Controller
    {
        MyContext db;
        public PlanteController(MyContext db)
        {
            this.db = db;
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
        public IActionResult Ajouter(Plante p)
        {
            db.plantes.Add(p);
            db.SaveChanges();
            return View();
        }
    }
}

using Falla7_App.Context;
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
        public IActionResult List()
        {

            return View(db.plantes.ToList());
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
            return RedirectToAction("List");
        }
        public IActionResult Supprimer(int id)
        {
            Plante plante = db.plantes.Find(id);
            db.plantes.Remove(plante);
            db.SaveChanges();
            return RedirectToAction("List");
        }
        public IActionResult Modifier(int id)
        {
            Plante plante= db.plantes.Find(id);
            return View(plante);
        }
        [HttpPost]
        public IActionResult Modifier(Plante p)
        {
            db.plantes.Update(p);
            db.SaveChanges();
            return RedirectToAction("List");
        }
    }
}

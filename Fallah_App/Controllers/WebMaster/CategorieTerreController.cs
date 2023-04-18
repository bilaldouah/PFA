using Fallah_App.Models;
using Microsoft.AspNetCore.Mvc;
using Fallah_App.Context;
using System.Numerics;
using Microsoft.Extensions.Caching.Memory;

namespace Fallah_App.Controllers.WebMaster
{
    public class CategorieTerreController : Controller
    {

        MyContext db;
        public CategorieTerreController(MyContext db)
        {
            
            this.db = db;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult List()
        {
            return View(db.categoryTerres.ToList());
            
        }
        public IActionResult Ajouter()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Ajouter(CategoryTerre c)
        {
            if (ModelState.IsValid)
            {
                db.categoryTerres.Add(c);
                db.SaveChanges();
                return RedirectToAction("List");
            }
            return View(c);
        }
        public IActionResult Supprimer(int id)
        {
            CategoryTerre ct = db.categoryTerres.Find(id);
            db.categoryTerres.Remove(ct);
            db.SaveChanges();
            return RedirectToAction("List");
        }
        public IActionResult Modifier(int id)
        {
            CategoryTerre ct = db.categoryTerres.Find(id);
            return View(ct);
        }
        [HttpPost]
        public IActionResult Modifier(CategoryTerre ct)
        {
            db.categoryTerres.Update(ct);
            db.SaveChanges();
            return RedirectToAction("List");
        }
    }
}

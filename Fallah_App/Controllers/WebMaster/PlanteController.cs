using Fallah_App.Context;
using Fallah_App.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
namespace Fallah_App.Controllers.WebMaster
{
    public class PlanteController : Controller
    {
        IMemoryCache memoryCache;
        MyContext db;
        
        public PlanteController(MyContext db, IMemoryCache memoryCache)
        {
            this.memoryCache = memoryCache;
            this.db = db;
        }
        public void RemplireCache()
        {
            if (this.memoryCache.Get<List<Plante>>("plantes") == null)
            {
                this.memoryCache.Set("plantes", db.plantes.ToList(), TimeSpan.FromHours(2));
            }
        }
        public IActionResult List()
        {
            RemplireCache();
            return View(db.plantes.ToList());
        }
        public IActionResult Ajouter()
        {

            return View();
        }
        [HttpPost]
        public IActionResult Ajouter(Plante p)
        {
            if(ModelState.IsValid)
            {
                Plante plante = db.plantes.Where(P => P.Nom == p.Nom).FirstOrDefault();
                if (plante!=null)
                {
                    ViewBag.errorNomPlante = "ce plante est déja existé";
                    return View(p);
                    
                }
                db.plantes.Add(p);
                db.SaveChanges();
                return RedirectToAction("List");
            }
            return View(p);
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

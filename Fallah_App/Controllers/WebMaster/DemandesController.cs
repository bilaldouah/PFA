using Fallah_App.Context;
using Fallah_App.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace Fallah_App.Controllers.WebMaster
{
    public class DemandesController : Controller
    {
        MyContext db;
        IMemoryCache memoryCache;
        public DemandesController(MyContext db,IMemoryCache memoryCache)
        {
            this.db = db;
            this.memoryCache = memoryCache;

        }

        public IActionResult List()
        {
            RemplireCache();
            // return View(this.memoryCache.Get<List<Demande>>("Demandes"));
            return View(db.demandes.ToList());
        }
        public IActionResult Information(int id)
        {
            RemplireCache();
            Demande demande = this.memoryCache.Get<List<Demande>>("Demandes").Where(demande => demande.Id == id).FirstOrDefault();
            return View(demande);
        }

        public IActionResult Accepter(int id)
        {
            Demande demande = db.demandes.Find(id);
            db.demandes.Remove(demande);
            db.SaveChanges();
            return RedirectToAction("List");
        }

        public IActionResult Refuser(int id)
        {
            Demande demande = db.demandes.Find(id);
            demande.Statut = true;
            db.demandes.Update(demande);
            db.SaveChanges();
            return RedirectToAction("List");
        }

        public void RemplireCache()
        {
            if (this.memoryCache.Get<List<Demande>>("Demandes") == null)
            {
                this.memoryCache.Set("Demandes", db.demandes.ToList(), TimeSpan.FromHours(2));
            }
        }
    }
}

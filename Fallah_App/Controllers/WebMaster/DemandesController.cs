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
            if(demande.forme==true)
            {
                AgriculteurForme agriculteurForme = new AgriculteurForme();
                agriculteurForme.Nom = demande.Nom;
                agriculteurForme.Prenom = demande.Prenom;
                agriculteurForme.Date_De_Naissance = demande.Date_De_Naissance;
                agriculteurForme.Login = demande.Login;
                agriculteurForme.Password = demande.Password;
                agriculteurForme.Email = demande.Email;
                agriculteurForme.Image = demande.Image;
                agriculteurForme.Date_Creation_Compte=DateTime.Now;
                db.users.Add(agriculteurForme);
            }
            else
            {
                Agriculteur agriculteur = new Agriculteur();
                agriculteur.Nom = demande.Nom;
                agriculteur.Prenom = demande.Prenom;
                agriculteur.Date_De_Naissance = demande.Date_De_Naissance;
                agriculteur.Login = demande.Login;
                agriculteur.Password = demande.Password;
                agriculteur.Email = demande.Email;
                agriculteur.Image = demande.Image;
                agriculteur.Date_Creation_Compte = DateTime.Now;

                db.users.Add(agriculteur);
            }

            db.demandes.Remove(demande);
            db.SaveChanges();
            return RedirectToAction("List");
        }

        public IActionResult Refuser(int id)
        {
            Demande demande = db.demandes.Find(id);
            demande.Statut = true;
            //demande.Id_WebMaster = (int)HttpContext.Session.GetInt32("webMasterID");
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

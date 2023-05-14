﻿using Fallah_App.Context;
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
            Dictionary<int, string> mois = new Dictionary<int, string>();

            mois.Add(1, "Janvier");
            mois.Add(2, "Février");
            mois.Add(3, "Mars");
            mois.Add(4, "Avril");
            mois.Add(5, "Mai");
            mois.Add(6, "Juin");
            mois.Add(7, "Juillet");
            mois.Add(8, "Août");
            mois.Add(9, "Septembre");
            mois.Add(10, "Octobre");
            mois.Add(11, "Novembre");
            mois.Add(12, "Décembre");
            ViewBag.mois = mois;
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
                    ViewBag.errorNomPlante = "cette plante existe déja ";
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
            if (id == 0 || !(id is int))
            {
                return RedirectToAction("Index", "ERROR404");
            }
            Plante plante = db.plantes.Find(id);
            if (plante == null)
            {
                return RedirectToAction("Index", "ERROR404");


            }
            db.plantes.Remove(plante);
            db.SaveChanges();
            return RedirectToAction("List");
        }
        public IActionResult Modifier(int id)
        {
            if (id == 0 || !(id is int))
            {
                return RedirectToAction("Index", "ERROR404");
            }
            Plante plante= db.plantes.Find(id);
            if (plante == null)
            {
                return RedirectToAction("Index", "ERROR404");


            }
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

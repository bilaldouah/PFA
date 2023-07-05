using Fallah_App.Context;
using Fallah_App.Migrations;
using Fallah_App.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;

namespace Fallah_App.Controllers.Client
{
    public class ResultatController : Controller
    {
        MyContext db;
        public ResultatController(MyContext db)
        {
            this.db = db;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult listConseilPlant()
        {
            int id = (int)HttpContext.Session.GetInt32("id");
            ViewBag.conseilPlantes = db.conseilPlantes
                .Include(t => t.plantes)
                    .ThenInclude(e => e.terres)
                        .ThenInclude(a => a.Agriculteur)
                .Where(a => a.plantes.Any(t => t.terres.Any(e => e.Agriculteur.Id == id)))
                .ToList();
            return View();
        }
        public IActionResult resultat(int id)
        {
            if(id==null)
            {
                return RedirectToAction("listConseilPlant");
            }
            var p = db.conseilPlantes.Find(id);
            if (p != null)
            {
                TempData["id"] = p.Id;
            }
            return RedirectToAction("listConseilPlant");
        }
        [HttpPost]
        //khas filtre...
        public IActionResult resultatConseilPlante(Resultat r)
        {  
            r.Date_De_Saisie= DateTime.Now;
            r.Id_agriculteurForme = (int)HttpContext.Session.GetInt32("id");
            r.Id_ConseilPlante = (int)TempData["id"];
            db.Add(r);
            db.SaveChanges();
            return RedirectToAction("listConseilPlant");
        }
        public IActionResult listResultat(Resultat r)
        {
            return View();
        }

        public IActionResult MesResultat()
        {
            //dirli hna resltat dial agriculteur where m session 
            return View();
        }



    }
}

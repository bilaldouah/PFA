using Fallah_App.Context;
using Fallah_App.Models;
using Microsoft.AspNetCore.Mvc;

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
            ViewBag.conseilPlantes = db.conseilPlantes.ToList();
            return View();
        }
        public IActionResult listConseilTerre()
        {
            ViewBag.conseilTerre=db.conseilTerres.ToList();
            return View();
        }
        public IActionResult resultat(int id)
        {
            ConseilPlante p = db.conseilPlantes.Find(id);
            return View(p);
        }
        [HttpPost]
        //khas filtre...
        public IActionResult resultatConseilPlante(Resultat r)
        {  
            r.Date_De_Saisie= DateTime.Now;
            r.Id_agriculteurForme = (int)HttpContext.Session.GetInt32("id");
            return View();
        }
        public IActionResult resultatConseilTerre(int id)
        {
            ConseilTerre t = db.conseilTerres.Find(id);
            return View(t);
        }
        [HttpPost]
        public IActionResult resultatConseilTerre(Resultat r)
        {
            r.Date_De_Saisie = DateTime.Now;
            r.Id_agriculteurForme = (int)HttpContext.Session.GetInt32("id");
            return View();
        }
    }
}

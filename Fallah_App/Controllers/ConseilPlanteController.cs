using Fallah_App.Context;
using Fallah_App.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using NUnit.Framework;

namespace Fallah_App.Controllers
{
    public class ConseilPlante : Controller
    {
        MyContext db;
        public ConseilPlante(MyContext db)
        {

            this.db = db;
        }
       
       
        public IActionResult List()
        {
            return View(db.conseilPlantes.ToList());

        }
        public IActionResult Ajouter()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Ajouter(Models.ConseilPlante csp)
        {
            int id = (int)HttpContext.Session.GetInt32("id");
            csp.Id_WebMaster = id;
            db.conseilPlantes.Add(csp);
            db.SaveChanges();

            return RedirectToAction("List");
        }
   
    }
}

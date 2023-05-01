﻿using Fallah_App.Context;
using Fallah_App.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using System.Numerics;

namespace Fallah_App.Controllers.WebMaster
{
    public class SolController : Controller
    {
        MyContext db;
        public SolController(MyContext db)
        {
            
            this.db = db;
        }
        public IActionResult List()
        {
            
            return View(db.sols.ToList());
        }
        public IActionResult Ajouter()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Ajouter(Sol s)
        {
            Sol sol = db.sols.Where(So => So.Type == s.Type).FirstOrDefault();
            if (sol != null)
            {
                ViewBag.error = "ce type existe déja ";
                return View(s);

            }
            db.sols.Add(s);
            db.SaveChanges();
            return RedirectToAction("List");
        }
        public IActionResult Supprimer(int id)
        {
            Sol sol = db.sols.Find(id);
            db.sols.Remove(sol);
            db.SaveChanges();
            return RedirectToAction("List");
        }
        public IActionResult Modifier(int id)
        {
           Sol sol = db.sols.Find(id);
            return View(sol);
        }
        [HttpPost]
        public IActionResult Modifier(Sol s)
        {
            db.sols.Update(s);
            db.SaveChanges();
            return RedirectToAction("List");
        }
    }
}

﻿using Fallah_App.Context;
using Fallah_App.les_filtres;
using Fallah_App.Migrations;
using Fallah_App.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;

namespace Fallah_App.Controllers.Client
{
    public class TerreController : Controller
    {
        MyContext db;
        public TerreController(MyContext db)
        {
            this.db = db;
        }

        public IActionResult List()
        {
            int id = (int)HttpContext.Session.GetInt32("id");
            return View(db.terres.Include(t=>t.Agriculteur).Where(t=>t.Agriculteur.Id==id).ToList());
        }
       
        public IActionResult Ajouter()
        {
            ViewBag.list = db.categoryTerres.ToList();
            ViewBag.plante=db.plantes.ToList();
            ViewBag.sol=db.sols.ToList();
            return View();
        }
        [HttpPost]
        public IActionResult Ajouter(Terre t, int[] plantes,int[] sol)
        {
            t.Id_Agriculteur = (int)HttpContext.Session.GetInt32("id");

            List<Plante> plante = new List<Plante>();
            List<Sol> sols = new List<Sol>();
            for (int i = 0; i < plantes.Count(); i++)
            {
                Models.Plante plante1 = db.plantes.Where(c => c.Id == plantes[i]).Include(c => c.terres).FirstOrDefault();
                plante.Add(plante1);
            }
            for (int i = 0; i < sol.Count(); i++)
            {
                Models.Sol ss = db.sols.Where(c => c.Id == sol[i]).Include(c => c.terres).FirstOrDefault();
                sols.Add(ss);
            }
            t.plantes = plante;
            t.sols=sols;
                String[] ext = { ".jpg", ".png", ".jpeg" };
                String file_ext = Path.GetExtension(t.file.FileName).ToLower();
                if (!ext.Contains(file_ext))
                {
                    ViewData["erorImage"] = "Le choix de fichier doit être une image.";
                    ViewBag.list = db.categoryTerres.ToList();
                    ViewBag.plante = db.plantes.ToList();
                    ViewBag.sol = db.sols.ToList();
                    return View(t);
                }
                if (ext.Contains(file_ext))
                {
                    String newName = Guid.NewGuid() + t.file.FileName;
                    String path_file = Path.Combine("wwwroot/ImageTerre", newName);
                   t.image = newName;
                    db.terres.Add(t);
                    db.SaveChanges();
                    using (FileStream stream = System.IO.File.Create(path_file))
                    {
                        t.file.CopyTo(stream);
                    }
                }

            return RedirectToAction("list");
        }
        public IActionResult supprimer(int id)
        {
            Models.Terre t= db.terres.Include(a => a.plantes).Include(a => a.sols).Where(f => f.Id == id).FirstOrDefault();
            foreach (Plante p in t.plantes.ToList())
            {
                t.plantes.Remove(p);
            }
            foreach (Sol p in t.sols.ToList())
            {
                t.sols.Remove(p);
            }
            db.terres.Remove(t);
            db.SaveChanges();
            return RedirectToAction("list");
        }
        public IActionResult Modifier(int id)
        {
            ViewBag.list = db.categoryTerres.ToList();
            if (id == 0 || !(id is int))
            {
                return RedirectToAction("Index", "ERROR404");
            }
            Terre t = db.terres.Find(id);
            if (t == null)
            {
                return RedirectToAction("Index", "ERROR404");
            }
            return View(t);
        }
        [HttpPost]
        public IActionResult Modifier(Terre t)
        {
            t.Id_Agriculteur = (int)HttpContext.Session.GetInt32("id");
            db.terres.Update(t);
            db.SaveChanges();
            return RedirectToAction("list");
        }

    }
}

﻿using Fallah_App.Context;
using Fallah_App.Models;
using Microsoft.AspNetCore.Mvc;
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
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult List()
        {
            return View();
        }
        public IActionResult Ajouter()
        {
            ViewBag.list = db.categoryTerres.ToList();
            return View();
        }
        [HttpPost]
        public IActionResult Ajouter(Terre t)
        {

            String[] ext = { ".jpg", ".png", ".jpeg" };
            String file_ext = Path.GetExtension(t.file.FileName).ToLower();
            if (!ext.Contains(file_ext))
            {
                ViewData["erorImage"] = "Le choix de fichier doit être une image.";
                return View(t);
            }
            if (ext.Contains(file_ext))
            {
                String newName = Guid.NewGuid() + t.file.FileName;
                String path_file = Path.Combine("wwwroot/ImageClient", newName);
                t.image = newName;
                db.terres.Add(t);
                db.SaveChanges();
                using (FileStream stream = System.IO.File.Create(path_file))
                {
                    t.file.CopyTo(stream);
                }
                ViewData["message"] = "Bien Ajouter";
            }
            return View();
        }
        public IActionResult supprimer(int id)
        {
            Terre t = db.terres.Find(id);
            db.terres.Remove(t);
            db.SaveChanges();
            return View();
        }
        public IActionResult Modifier(int id)
        {
            Terre t = db.terres.Find(id);
            return View(t);
        }
        [HttpPost]
        public IActionResult Modifier(Terre t)
        {
            db.terres.Update(t);
            db.SaveChanges();
            return View();
        }

    }
}

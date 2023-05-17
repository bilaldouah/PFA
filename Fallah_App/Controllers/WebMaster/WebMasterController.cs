﻿using Fallah_App.Context;
using Fallah_App.Controllers.Client;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace Fallah_App.Controllers.WebMaster
{
    public class WebMasterController : Controller
    {
        IMemoryCache memoryCache;
        MyContext db;
        public WebMasterController(MyContext db, IMemoryCache memoryCache)
        {
            this.db = db;
            this.memoryCache = memoryCache;

        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Ajouter()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Ajouter(Models.WebMaster webMaster)
        {           
                webMaster.Password= InscriptionController.HashPasswordWithSalt(webMaster.Password);           
                String[] ext = { ".jpg", ".png", ".jpeg" };
                String file_ext = Path.GetExtension(webMaster.file.FileName).ToLower();
                if (!ext.Contains(file_ext))
                {
                    ViewBag.erorImage = "Le choix de fichier doit être une image.";
                    return View(webMaster);
                }
                if (ext.Contains(file_ext))
                {
                    String newName = Guid.NewGuid() + webMaster.file.FileName;
                    String path_file = Path.Combine("wwwroot/imageAdmin", newName);
                    webMaster.Image = newName;
                    db.users.Add(webMaster);
                    db.SaveChanges();
                    using (FileStream stream = System.IO.File.Create(path_file))
                    {
                        webMaster.file.CopyTo(stream);
                    }
                    return RedirectToAction("List");
                }
            
           
            return View(webMaster);
           
        }
    }
}

using Fallah_App.Context;
using Fallah_App.Controllers.Client;
using Fallah_App.Models;
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
        public IActionResult List()
        {
           ViewBag.listWebMaster= db.users.OfType<Models.WebMaster>().ToList();
            return View();
        }

        public IActionResult Ajouter()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Ajouter(Models.WebMaster webMaster)
        {
        //    if(ModelState.IsValid)
          //  {       
                //recuperer le login dans la table  user
                Models.WebMaster login  = db.users.OfType<Models.WebMaster>().Where(D => D.Login == webMaster.Login).FirstOrDefault();
                Models.WebMaster Email = db.users.OfType<Models.WebMaster>().Where(D => D.Email == webMaster.Email).FirstOrDefault();

            //comparer le login inserer avec le login deja dans la  base

            if (webMaster.PasswordConfirmation != webMaster.Password)
            {
                ViewData["samePasswordError"] = "le mot de passe est confirmation de mot de passe pas le meme.";
                return View(webMaster);
            }
            if (login != null )
                {
                    ViewData["erorLogin"] = "Ce login   est déjà inscrit.";
                    return View(webMaster);
                }
                if (Email !=  null)
                {
                    ViewData["errorEmail"] = "Ce  Email est déjà inscrit .";
                    return View(webMaster);
                }
               
            
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
                   
           //     }
                return RedirectToAction("List");
            }

            return View(webMaster);
           
        }
    }
}

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
       
       
    
        public IActionResult Ajouter()
        {
            if (TempData["erorImage"] != null)
            {
                ViewBag.eror = true;
            }

           
            return View();
            
        }
        [HttpPost]
        public IActionResult Ajouter(Models.ConseilPlante csp)
        {
            if (csp.File != null)
            {
                String[] ext = { ".mp3", ".wav", ".aac", ".flac", ".ogg", ".m4a", ".wma", ".aiff" };
                String file_ext = Path.GetExtension(csp.File.FileName).ToLower();
                if (!ext.Contains(file_ext))
                {
                    TempData["erorImageM"] = true;
                    return RedirectToAction("Modifier");
                }
                if (ext.Contains(file_ext))
                {
                    String newName = Guid.NewGuid() + csp.File.FileName;
                    String path_file = Path.Combine("wwwroot/Audio", newName);
                    csp.audio = newName;
                    using (FileStream stream = System.IO.File.Create(path_file))
                    {
                        csp.File.CopyTo(stream);
                    }

                }

            }
           
            csp.Id_WebMaster = 4;
           
            db.conseilPlantes.Add(csp);
            db.SaveChanges();

            return RedirectToAction("List");
        }
        public IActionResult List()
        {

            ViewBag.conseilplantes = db.conseilPlantes.Include(c => c.plantes).Include(c => c.webMaster).ToList()   ;
            return View();
        }

    }
}

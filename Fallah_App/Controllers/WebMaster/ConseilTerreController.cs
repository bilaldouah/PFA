using Fallah_App.Context;
using Fallah_App.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Fallah_App.Controllers.WebMaster
{
    public class ConseilTerreController : Controller
    {
        MyContext db;

        public ConseilTerreController(MyContext db)
        {
            this.db = db;
        }

        public IActionResult Ajouter()
        {
            ViewBag.Category=db.categoryTerres.ToList();
            return View();
        }
        [HttpPost]
        public IActionResult Ajouter(Models.ConseilTerre conseil, int[] categories)
        {
            List<CategoryTerre> categoryTerres = new List<CategoryTerre>();
           for(int i=0;i<categories.Count();i++)
            {
                Models.CategoryTerre categoryTerre = db.categoryTerres.Where(c=>c.Id==categories[i]).Include(c=>c.terres).Include(c=>c.conseilTerres).FirstOrDefault();
                categoryTerres.Add(categoryTerre);
            }
           conseil.CategoryTerres= categoryTerres;
            String[] ext = { ".mp3", ".wav", ".aac", ".flac", ".ogg", ".m4a", ".wma", ".aiff" };
            String file_ext = Path.GetExtension(conseil.File.FileName).ToLower();
            if (!ext.Contains(file_ext))
            {
                TempData["erorImage"] = true;
                return RedirectToAction("ajouter");
            }
            if (ext.Contains(file_ext))
            {
                String newName = Guid.NewGuid() + conseil.File.FileName;
                String path_file = Path.Combine("wwwroot/Audio", newName);
                conseil.Audio = newName;
                using (FileStream stream = System.IO.File.Create(path_file))
                {
                    conseil.File.CopyTo(stream);
                }
                conseil.Id_WebMaster =1;

                db.conseilTerres.Add(conseil);
                db.SaveChanges();
            }
           
            return View();
        }
    }
}

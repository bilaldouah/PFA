using Fallah_App.Context;
using Fallah_App.Models;
using Microsoft.AspNetCore.Mvc;

namespace Fallah_App.Controllers.WebMaster
{
    public class NotificationController : Controller
    {
        MyContext db;
        public NotificationController(MyContext db)
        {
            this.db = db;
        }
        public IActionResult Ajouter()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Ajouter(Notification notification)
        {
            if(ModelState.IsValid)
            {
                db.notifications.Add(notification);
                db.SaveChanges();
                return RedirectToAction("List");
            }
            return View(notification);

        }
        public IActionResult Index()
        {
            return View();
        }
    }
}

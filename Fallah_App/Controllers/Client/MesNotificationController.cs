using Fallah_App.Context;
using Fallah_App.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Fallah_App.Controllers.Client
{
    public class MesNotificationController : Controller
    {
        MyContext db;
        public MesNotificationController(MyContext db)
        {
            this.db = db;
        }
 
        public IActionResult Index()
        {
             int idLog = (int)HttpContext.Session.GetInt32("id");
             ViewBag.notifications= db.notifications.Include(N=>N.AgriculteurNotifications).ToList();
             ViewBag.countNotifWhereFalse = db.agriculteurNotifications.Where(u => u.Agriculteur.Id == idLog && u.IsSeen == false).Count();
             return RedirectToAction("ajouter", "Notification");
        }
        
    }
}

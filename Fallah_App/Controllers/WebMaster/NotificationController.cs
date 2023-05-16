using Fallah_App.Context;
using Fallah_App.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;

namespace Fallah_App.Controllers.WebMaster
{
    public class NotificationController : Controller
    {
        IMemoryCache memoryCache;
        MyContext db;
        public NotificationController(MyContext db,IMemoryCache memoryCache)
        {
            this.db = db;
            this.memoryCache = memoryCache;
        }
        public void RemplireCache()
        {
            if (this.memoryCache.Get<List<Notification>>("notifications") == null)
            {
                this.memoryCache.Set("notifications", db.notifications.ToList(), TimeSpan.FromHours(2));
            }
        }
        public IActionResult List()
        {
            RemplireCache();
            return View(db.notifications.ToList());
        }
        public IActionResult Ajouter()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Ajouter(Notification notification)
        {
            notification.Id_WebMaster = 2;
                db.notifications.Add(notification);
                db.SaveChanges();
                return RedirectToAction("List");
           

        }
        public IActionResult Supprimer(int id)
        {
            Notification notification = db.notifications.Find(id);
            db.notifications.Remove(notification);
            db.SaveChanges();
            return RedirectToAction("List");
            
        }
        public IActionResult Modifier(int id)
        {
            Notification notification = db.notifications.Find(id);
            return View(notification);
        }
        [HttpPost]
        public IActionResult Modifier(Notification N)
        {
            N.Id_WebMaster = 2;
            db.notifications.Update(N);
            db.SaveChanges();
            return RedirectToAction("List");
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Broadcast(Notification notification)
        {
            Notification no= db.notifications.Find(notification.Id);
            List < User > users = db.users.Where(u => u is Agriculteur || u is AgriculteurForme).ToList();
            // db.notifications.Include(n => n.AgriculteurNotifications).ThenInclude(an => an.Agriculteur).Where(n => n.Id == id);
            AgriculteurNotification agriculteurNotification = new AgriculteurNotification();
            Agriculteur agriculteur = new Agriculteur();            
            foreach (User user in users) 
            {
                agriculteurNotification.Id = notification.Id;
                agriculteurNotification.Agriculteur.Id = user.Id;
            }
     
            db.agriculteurNotifications.Add(agriculteurNotification);
            return RedirectToAction("List");
        }


    }
}

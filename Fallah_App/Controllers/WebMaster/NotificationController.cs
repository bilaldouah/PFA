using Fallah_App.Context;
using Fallah_App.Controllers.Client;
using Fallah_App.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;

namespace Fallah_App.Controllers.WebMaster
{

 
    public class NotificationController : FilterNotifController
    {
        IMemoryCache memoryCache;
        MyContext db;
        public NotificationController(MyContext db, IMemoryCache memoryCache):base(db)
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
        public IActionResult Broadcast(Notification notif)
        {
            Notification notification = db.notifications.Find(notif.Id);
            List < Agriculteur > agriculteurs= db.users.OfType<Agriculteur>().ToList();

        
            foreach (Agriculteur u in agriculteurs)
            {
                AgriculteurNotification agriculteurNotification = new AgriculteurNotification();
                agriculteurNotification.Notification = notification;
                agriculteurNotification.Agriculteur = u;
                agriculteurNotification.IsSeen= false;
                db.agriculteurNotifications.Add(agriculteurNotification);
            }                      
            db.SaveChanges();         
            return RedirectToAction("List");
        }

    }
}

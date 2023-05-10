using Fallah_App.Context;
using Fallah_App.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace Fallah_App.Controllers
{
    public class AuthentificationController : Controller
    {
        MyContext db;
        public AuthentificationController(MyContext db)
        {
            
            this.db = db;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login(User u) 
        {
            if (ModelState.IsValid)
            {
                User user = db.users.Where(u => u.Login.Equals(u.Login) && u.Password.Equals(u.Password)).FirstOrDefault() ;
                if(user!= null) 
                {
                    string id = user.Id.ToString();
                    HttpContext.Session.SetString("id", id);
                    return RedirectToAction("userdashboard");
                                 
                }
            }
            return View(u);
        }
        public IActionResult userdashboard()
        {//filtre if session != null ===> return view()
            // else return page login;
            return View();
        }
    }
}

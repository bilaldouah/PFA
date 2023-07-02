using Fallah_App.Context;
using Fallah_App.Models;
using Microsoft.AspNetCore.Mvc;

namespace Fallah_App.Controllers.Client
{
    public class CompteController : Controller
    {
        MyContext db;
        public CompteController(MyContext db)
        {

            this.db = db;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult changerpassword()
        {
            if (HttpContext.Session.GetInt32("id") == null) 
            {
                RedirectToAction("login","Authentification");
            }
            return View();
        }
        [HttpPost]
        public IActionResult changerpassword(string NvPassword,User user)
        {
            if (ModelState.IsValid)
            {
                int id = (int)HttpContext.Session.GetInt32("id");
                User u = (User)db.users.Where(us => us.Id == id).FirstOrDefault();
                string Password = InscriptionController.HashPasswordWithSalt(user.Password);
                u = (User)db.users.Where(us => us.Password == Password).FirstOrDefault();
                if (u == null)
                {
                    ViewData["message1"] = "le mot de passe actuel et incorect";
                    return View();
                }
                if (NvPassword == user.PasswordConfirmation)
                {
                    string Password_ = InscriptionController.HashPasswordWithSalt(NvPassword);
                    u.Password = Password_;
                    db.users.Update(u);
                    db.SaveChanges();
                    return RedirectToAction("login", "Authentification");
                }
                else
                {
                    ViewData["message"] = "le mot de pass ou confirmation de mot de pass et incorect";
                }
            }
            return View();
        }
        public IActionResult MotDePasseOublier()
        {
            
            return View();
        }
    }
}

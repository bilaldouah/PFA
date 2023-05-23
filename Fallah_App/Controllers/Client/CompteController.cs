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
                RedirectToAction("Authentification/login");
            }
            return View();
        }
        [HttpPost]
        public IActionResult changerpassword(string NvPassword)
        {
            int id = (int)HttpContext.Session.GetInt32("id"); 
            User user=db.users.Where(us =>us.Id==id).FirstOrDefault();
            string Password= InscriptionController.HashPasswordWithSalt(user.Password);
            if (user.Password== NvPassword)
            {
                if (user.Password == user.PasswordConfirmation) 
                {
                    user.Password = InscriptionController.HashPasswordWithSalt(user.Password);
                    db.users.Update(user);
                    db.SaveChanges();
                    RedirectToAction("Authentification/login");
                }
            }
            return View();
        }
    }
}

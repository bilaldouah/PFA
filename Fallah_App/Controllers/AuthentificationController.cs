using Fallah_App.Context;
using Fallah_App.Controllers.Client;
using Fallah_App.Models;
using Microsoft.AspNetCore.Mvc;


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
        [HttpPost]
        public IActionResult Index(User u)
        {
            //String password = InscriptionController.HashPasswordWithSalt(u.Password);
            Models.User user =db.users.Where(us => us.Login.Equals(u.Login) && us.Password.Equals(u.Password)).FirstOrDefault();
            
            if (user != null)
            {
                

                if (user is Models.WebMaster)
                {
                }
                if (user is Models.Agriculteur)
                {
                    if (user is Models.AgriculteurForme)
                    {

                    }
                    else
                    {

                    }
                }
               

            }


                    return View();
        }
    }
}

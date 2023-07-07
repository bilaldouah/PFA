using Fallah_App.Context;
using Fallah_App.Controllers.Client;
using Fallah_App.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net.Mail;

namespace Fallah_App.Controllers
{
    public class AuthentificationController : Controller
    {
        MyContext db;
        public AuthentificationController(MyContext db)
        {
            
            this.db = db;
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(User u)
        {
            if(u.Password == null || u.Login == null)
            {
                ViewBag.Null = true;
                return View();
            }
            String password = InscriptionController.HashPasswordWithSalt(u.Password);
            Models.User user =db.users.Where(us => us.Login.Equals(u.Login) && us.Password.Equals(password)).FirstOrDefault();
            
            if (user != null)
            {

                HttpContext.Session.SetInt32("id", (int)user.Id);

                if (user is Models.WebMaster)
                {
                    HttpContext.Session.SetString("role", "WebMaster");
                    return RedirectToAction("Index", "Home");

                }
                if (user is Models.Agriculteur)
                {
                    if (user is Models.AgriculteurForme)
                    {
                        HttpContext.Session.SetString("role", "AgriculteurForme");
                    }
                    else
                    {
                        HttpContext.Session.SetString("role", "Agriculteur");
                    }
                    return RedirectToAction("Index", "Home");

                }


            }
            ViewBag.eror = true;
             return View();
        }

        public IActionResult MotDePasseOublier(string email)
        {
            if (email == null)
            {
                ViewBag.EmNull = true;
                return View("Login");
            }

            User user = db.users.Where(u => u.Email == email).FirstOrDefault();
            if(user != null)
            {
                TempData["id"]=user.Id;
                TempData["nbr"]= EnvoyerNombre(user.Email);
                return View("NombreDeRecuperation");
            }
            ViewBag.Emaileror = true;
            return View("Login");
        }

        public IActionResult NombreDeRecuperation(int nbr)
        {
            if(nbr == 0)
            {
                ViewBag.Null = true;
                return View();
            }
            int random = (int)TempData["nbr"];
            if(nbr == random)
            {
                return View("MotDePasseOublier");

            }
            else
            {
                ViewBag.eror = true;
                return View();
            }
        }

        public IActionResult ChangerPassword(string password, string confirmer)
        {
            if (password == null || confirmer == null)
            {
                ViewBag.Null = true;
                return View("MotDePasseOublier");
            }
            if(TempData["id"] == null)
            {
                return RedirectToAction("MotDePasseOublier");
            }
            if (password.Equals(confirmer))
            {
                int id = (int)TempData["id"];
                User user=db.users.Where(u => u.Id == id).FirstOrDefault();
                user.Password= InscriptionController.HashPasswordWithSalt(password);
                db.users.Update(user);
                db.SaveChanges();
                return RedirectToAction("Login");
            }
            ViewBag.Passworderor = true;
            return View("MotDePasseOublier");
        }
        public IActionResult LogOut()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }
        public int EnvoyerNombre(string mail)
        {
            Random random = new Random();

            int randomNumber = random.Next(1000, 10000);

            string from = "falla7app@gmail.com";
            string subject = "Modifier mot de passe ";
            string body = "Nous avons bien reçu votre demande de récupération de mot de passe. Pour procéder à la récupération, veuillez utiliser le code de vérification suivant :\r\n\r\n"+randomNumber+"\r\n\r\nVeuillez noter que ce code de vérification est valable pendant une durée limitée. Une fois que vous avez reçu cet e-mail, veuillez saisir le code dans le champ prévu à cet effet sur notre site Web.\r\n\r\nSi vous n'avez pas initié cette demande de récupération de mot de passe, veuillez ignorer cet e-mail et prendre les mesures appropriées pour sécuriser votre compte.\r\n\r\n| |\r\n| [ CODE :"+randomNumber+" ] |\r\n| |\r\nCordialement,\r\nL'équipe du FALLH_APP";

            MailMessage message = new MailMessage(from, mail, subject, body);
            SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587);
            smtpClient.Credentials = new System.Net.NetworkCredential("falla7app@gmail.com", "ifkbjdfapakuqixv");
            smtpClient.EnableSsl = true;
            smtpClient.Send(message);
            return randomNumber;
        }
        public IActionResult CompteAgriculteur()
        {
            int id = (int)HttpContext.Session.GetInt32("id");
            return View(db.users.OfType<Agriculteur>().Where(a => a.Id == id).FirstOrDefault());
        }
        public IActionResult CompteWebMaster()
        {
            int id = (int)HttpContext.Session.GetInt32("id");
            db.users.OfType<Models.WebMaster>().Where(a=>a.Id== id).FirstOrDefault();
            return View();
        }
        public IActionResult ModifierCompte(int id)
        {
            return View(db.users.OfType<Agriculteur>().Where(a => a.Id == id).FirstOrDefault());
        }
        [HttpPost]
        public IActionResult ModifierCompte(Agriculteur a)
        {   
            db.users.Update(a);
            db.SaveChanges();
            return RedirectToAction("CompteAgriculteur");
        }
    }
}

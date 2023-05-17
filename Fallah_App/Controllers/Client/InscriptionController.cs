﻿using Fallah_App.Context;
using Fallah_App.Models;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Cryptography;
using System.Text;


namespace Fallah_App.Controllers.Client
{
 
    public class InscriptionController : Controller
    {
        MyContext db;
        public InscriptionController(MyContext db)
        {
            this.db = db;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(Demande d)
        {


            if (d.conf_Password != d.Password)
            {
                ViewData["erorconfpass"] = "le mot de passe est confirmation de mot de passe pas le meme.";
                return View(d);
            }
            else
            {
                //recuperer le login dans table demande et user
                Demande demande = db.demandes.Where(D => D.Login == d.Login).FirstOrDefault();
                Demande demande_Email = db.demandes.Where(D => D.Email == d.Email).FirstOrDefault();
                User user = db.users.Where(l => l.Login == d.Login).FirstOrDefault();
                User user_Email = db.users.Where(l => l.Email == d.Email).FirstOrDefault();
                //comparer le login inserer avec le login deja dans la  base
                if (demande != null || user != null)
                {
                    ViewData["erorLogin"] = "Ce login   est déjà inscrit ou une demande d'inscription est en cours.";
                    return View(d);
                }
                if (user_Email != null || demande_Email != null)
                {
                    ViewData["errorEmail"] = "Ce  Email est déjà inscrit ou une demande d'inscription est en cours.";
                    return View(d);
                }
                if (d.Password != d.conf_Password)
                {
                    ViewData["message1"] = "Le password et confiramation du password et diferent";
                    return View(d);
                }
                //hashPassword
                d.Password = HashPasswordWithSalt(d.Password);
                d.Date_Demande = DateTime.Now;
                //importer image
                String[] ext = { ".jpg", ".png", ".jpeg" };
                String file_ext = Path.GetExtension(d.file.FileName).ToLower();
                if (!ext.Contains(file_ext))
                {
                    ViewData["erorImage"] = "Le choix de fichier doit être une image.";
                    return View(d);
                }
                if (ext.Contains(file_ext))
                {
                    String newName = Guid.NewGuid() + d.file.FileName;
                    String path_file = Path.Combine("wwwroot/ImageClient", newName);
                    d.Image = newName;
                    db.demandes.Add(d);
                    db.SaveChanges();
                    using (FileStream stream = System.IO.File.Create(path_file))
                    {
                        d.file.CopyTo(stream);
                    }

                    ViewData["message"] = "La demande a été enregistrée avec succès.";
                }

            }
            ViewData["message"] = "La demande a été enregistrée avec succès.";
            return View();
        }
        public static string HashPasswordWithSalt(string password)
        {
            using (var hashAlgorithm = new SHA256Managed())
            {
                byte[] passwordBytes = Encoding.UTF8.GetBytes(password);
                SHA256 sha256 = SHA256.Create();
                byte[] hashBytes = sha256.ComputeHash(passwordBytes);
                return Convert.ToBase64String(hashBytes);
            }
        }
    }
}
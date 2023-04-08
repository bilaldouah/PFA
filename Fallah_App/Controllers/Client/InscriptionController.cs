﻿
using Fallah_App.Context;
using Fallah_App.Models;
using Microsoft.AspNetCore.Mvc;
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
        public IActionResult Index(Demande d,IFormFile file
            )
        {
            Demande demande = (Demande)db.demandes.ToList().Where(D => D.Login == d.Login);
            User user = (User)db.users.ToList().Where(l=>l.Login==d.Login);
            //comparer le login inserer avec le login deja dans la  base
            if ( demande!=null || user!=null) 
            {
                ViewData["erorPrix"] = "ce login et deja inscrit ou demander l'inscription";
            }
            //hashPassword
            hashPassword(d.Password);
            //importer image
            String[] ext = { ".jpg", ".png", ".jpeg" };
            String file_ext = Path.GetExtension(file.FileName).ToLower();
            if (ext.Contains(file_ext))
            {
                String newName = Guid.NewGuid() +file.FileName;
                String path_file = Path.Combine("wwwroot/ClientTemplate/img/imgClient", newName);
                d.Image = newName;
                db.demandes.Add(d);
                db.SaveChanges();
                using (FileStream stream = System.IO.File.Create(path_file))
                {
                    file.CopyTo(stream);
                }
                ViewData["erorPrix"] = "la demande a etait bien enregistrer";
            }
            else
            {
                ViewData["erorPrix"] = "le chois de fichier doit etre une Image";
                return View();
            }
            return View();
        }
        public string hashPassword(string password)
        {
            byte[] passwordBytes = Encoding.UTF8.GetBytes(password);
            SHA256 sha256 = SHA256.Create();
            byte[] hashBytes = sha256.ComputeHash(passwordBytes);
            return Convert.ToBase64String(hashBytes);
        }

    }
}
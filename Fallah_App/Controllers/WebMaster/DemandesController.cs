﻿using Falla7_App.Context;
using Fallah_App.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace Fallah_App.Controllers.WebMaster
{
    public class DemandesController : Controller
    {
        MyContext db;
        IMemoryCache memoryCache;
        public DemandesController(MyContext db,IMemoryCache memoryCache)
        {
            this.db = db;
            this.memoryCache = memoryCache;

        }

        public IActionResult List()
        {
            if(this.memoryCache.Get<List<Demande>>("Demandes") == null)
            {
                RemplireCache();
            }
            // return View(this.memoryCache.Get<List<Demande>>("Demandes"));
            return View(db.demandes.ToList());
        }
        public IActionResult Detail(int id)
        {
            if (this.memoryCache.Get<List<Demande>>("Demandes") == null)
            {
                RemplireCache();
            }
            Demande demande = this.memoryCache.Get<List<Demande>>("Demandes").Where(demande => demande.Id == id).FirstOrDefault();
            return View(demande);
        }

        public void RemplireCache()
        {
            this.memoryCache.Set("Demandes", db.demandes.ToList(),TimeSpan.FromHours(2));
        }
    }
}

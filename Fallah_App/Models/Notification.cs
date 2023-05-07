﻿using System.ComponentModel.DataAnnotations.Schema;

namespace Fallah_App.Models
{
    public class Notification
    {
        public int Id { get; set; }
        public Boolean IsSeen { get; set; }
        public string TextArabe { get; set; }
        public string TextFrancais { get; set; }
        public WebMaster webMaster { get; set; }
        [ForeignKey(nameof(webMaster))]
        public int Id_WebMaster { get; set; }
        public List<Agriculteur> Agriculteurs { get; set; }
        public List<Plante> Plantes { get; set; }
        public List<Terre> terres { get; set; }

    }
}

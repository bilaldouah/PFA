﻿using System.ComponentModel.DataAnnotations.Schema;

namespace Fallah_App.Models
{
    public class Terre
    {
        public int Id { get; set; }
        public string Localisation { get; set; }
        public string Type { get; set; }
        public string image { get; set; }
        public double Humidite { get; set; }
        public double Hauteur { get; set; }
        public double Surface { get; set; }
        public List<Sol> sols { get; set; }
        public Agriculteur Agriculteur { get; set; }
        [ForeignKey(nameof(Agriculteur))]
        public int Id_Agriculteur { get; set; }
        public List<Notification> notifications { get; set; }
        public List<Plante> plantes { get; set; }
        public CategoryTerre categoryTerre { get; set; }

        [ForeignKey(nameof(categoryTerre))]
        public int Id_categoryTerre { get; set; }


    }
}

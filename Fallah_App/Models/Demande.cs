using System.ComponentModel.DataAnnotations.Schema;

namespace Fallah_App.Models
{
    public class Demande
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public DateTime Date_De_Naissance { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public DateTime Date_Demande{ get; set; }
        public string Image { get; set; }
        public Boolean Discriminator { get; set; }
        public WebMaster webMaster { get; set; }

        [ForeignKey(nameof(webMaster))]
        public int Id_WebMaster { get; set; }
    }
}

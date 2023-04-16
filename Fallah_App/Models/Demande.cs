using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;

namespace Fallah_App.Models
{
    public class Demande
    {    
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string Nom { get; set; }
        [Required]
        [StringLength(100)]
        public string Prenom { get; set; }
        [Required]
        [RegularExpression(@"^(\+212|0)[5-7]\d{8}$", ErrorMessage = "Invalid phone number format.")]
        public string Telephone { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime Date_De_Naissance { get; set; }
        [Required]
        [StringLength(100)]
        public string Login { get; set; }
        [Required]
        [StringLength(100)]
        public string Password { get; set; }
        [Required]
        [EmailAddress( ErrorMessage = "Invalid Email format.")]
        public string Email { get; set; }
        [Required]
        public DateTime Date_Demande{ get; set; }
        [Required]
        public string Image { get; set; }
        [Required]
        public Boolean Statut { get; set; }
        public Boolean forme { get; set; }
        public WebMaster? webMaster { get; set; }
        [ForeignKey(nameof(webMaster))]
        public int? Id_WebMaster { get; set; }
        [NotMapped]
        public IFormFile file { get; set; }
    }
}

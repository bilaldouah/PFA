namespace Fallah_App.Models
{
    public class User
    {
        public int Id { get; set; }

        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public DateTime Date_Dernier_Auth { get; set; }
        public string Image { get; set; }


    }
}

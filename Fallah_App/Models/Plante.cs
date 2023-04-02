namespace Fallah_App.Models
{
    public class Plante
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public string type { get; set; }
        public DateTime Debut_Period { get; set; }
        public DateTime Fin_Date { get; set; }
        public List<Notification> notifications { get; set; }
        public List<Terre> terres { get; set; }
        public List<ConseilPlante> conseilPlantes { get; set; }
    }
}

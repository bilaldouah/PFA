namespace Fallah_App.Models
{
    public class CategoryTerre
    {
        public int Id { get; set; }
        public string Attribut_De_Categorisation { get; set; }
        public double Valeur_Max { get; set; }
        public double Valeur_Min { get; set; }
        public List<ConseilTerre> conseilTerres {get; set; }
        public List<Terre> terres {get; set; }

    }
}

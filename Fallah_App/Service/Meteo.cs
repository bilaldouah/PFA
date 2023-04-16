namespace Fallah_App.Service
{
    public class Meteo
    {
        public double latitude { get; set; }

        public double longitude { get; set; }

       public double generationtime_ms { get; set; }
        public int utc_offset_seconds { get; set; }
        public string timezone_abbreviation { get; set; }
        public double elevation { get; set; }

        public hourly_units hourly_units { get; set; }
        /*public List<string> time_Houre { get; set; }
        public List<float> temperature_2m_houre { get; set; }
        public List<string> time { get; set; }
        public List<string> temperature_2m_max { get; set; }
        public List<string> temperature_2m_min { get; set; }*/
    }
}

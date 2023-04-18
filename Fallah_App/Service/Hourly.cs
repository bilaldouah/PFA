namespace Fallah_App.Service
{
    public class Hourly
    {
        public List<DateTime>time { get; set; }
        public List<float> temperature_2m { get; set; }
        public List<int> relativehumidity_2m { get; set;}
        public List<float> precipitation { get; set; }
        public List<float> rain { get; set; }
        public List<int> weathercode { get; set; }
    }
}

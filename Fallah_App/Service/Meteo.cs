using Fallah_App.Models;
using Newtonsoft.Json;
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
        public Hourly hourly { get; set; }
        public daily daily { get; set; }
        public daily_units daily_units { get; set; }

        public static async Task<Meteo> getMeteo()
        {
            Meteo weatherData = null;
            int i = 0;
            while (i < 3 && weatherData == null)
            {
                using (var client = new HttpClient())
                {
                    var response = await client.GetAsync("https://api.open-meteo.com/v1/forecast?latitude=34.68&longitude=-1.91&hourly=temperature_2m,relativehumidity_2m,precipitation,rain,weathercode&daily=weathercode,temperature_2m_max,temperature_2m_min&timezone=auto");
                    if (response.IsSuccessStatusCode)
                    {
                        var data = await response.Content.ReadAsStringAsync();

                        weatherData = JsonConvert.DeserializeObject<Meteo>(data);


                    }
                    else
                    {
                        i++;
                    }
                }
            }
            return weatherData;

        }

    }
}

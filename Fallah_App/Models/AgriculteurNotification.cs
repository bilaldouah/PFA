namespace Fallah_App.Models
{
    public class AgriculteurNotification
    {
        public int Id { get; set; }
        public Agriculteur Agriculteur { get; set; }
        public Notification Notification { get; set; }
        public Boolean IsSeen { get; set; }
    }
}

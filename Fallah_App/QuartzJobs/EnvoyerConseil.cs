using Fallah_App.Context;
using Fallah_App.Models;
using Fallah_App.Service;
using Microsoft.EntityFrameworkCore;
using Quartz;

namespace Fallah_App.QuartzJobs
{
    public class EnvoyerConseil : IJob
    {

        public  Task Execute(IJobExecutionContext context)
        {
           Notification notification = new Notification();
                notification.TextFrancais = "Conseil d'Aujourd'hui";
                notification.TextArabe = "نصيحة اليوم";
                notification.type = "conseil";
            
            return Task.FromResult(true);
        }
    }
}

using Fallah_App.Context;
using Fallah_App.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;

namespace Fallah_App.Controllers.Client
{
    public class FilterNotifController : Controller
    {
        MyContext data;
 
        public FilterNotifController(MyContext data)
        {
            this.data = data;
           
        }

        public override void OnActionExecuted(ActionExecutedContext context)
        { 
            
            HttpContext httpContext = context.HttpContext;
            int idLog = (int)httpContext.Session.GetInt32("id");
            context.HttpContext.Items["listNotif"] = data.agriculteurNotifications.Include(u=>u.Notification).Include(a=>a.webMaster).Where(a => a.Agriculteur.Id == idLog && a.IsSeen == false).ToList();
            context.HttpContext.Items["count"] = data.agriculteurNotifications.Where(u => u.Agriculteur.Id == idLog && u.IsSeen == false).Count();

        }



        public override void OnActionExecuting(ActionExecutingContext context)
        {
        
        }
    }
}

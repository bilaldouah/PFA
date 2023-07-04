using Microsoft.AspNetCore.Mvc.Filters;

namespace Fallah_App.les_filtres
{
    public class FiltreAgriculteur: ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext context)
        {
            if (context.HttpContext.Session.GetInt32("id")!=null) 
            {
                if (context.HttpContext.Session.GetString("role") != "Agriculteur")
                {
                    context.HttpContext.Response.Redirect("/Authentification/login");
                }
            }
            else
            {
                context.HttpContext.Response.Redirect("/Authentification/login");
            }
        }
    }
}

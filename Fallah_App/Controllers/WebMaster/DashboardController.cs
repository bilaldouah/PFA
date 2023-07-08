using Fallah_App.Context;
using Fallah_App.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Fallah_App.Controllers.WebMaster
{
    public class DashboardController : Controller
    {
        MyContext db;
        public DashboardController(MyContext db)
        {
            this.db = db;
        }
        public IActionResult Index()
        {
            /*   bar chart 1   */
            ViewBag.CountAgriculteures = db.users.ToList().Where(item => item.GetType() == typeof(Agriculteur)).Count();
            ViewBag.CountAgriculteureFormes = db.users.ToList().Where(item => item.GetType() == typeof(AgriculteurForme)).Count();
            ViewBag.CountAdmins = db.users.ToList().Where(item => item.GetType() == typeof(Models.WebMaster)).Count();
            ViewBag.CountDemandes = db.demandes.Count();
            /*-----------------------------------------------------------------------------------------------------------*/

            for (int i = 1; i <= 12; i++)
            {
                ViewBag.countHowManyUsersAuthentifyEachMonth = db.users.Where(u=>u.Date_Dernier_Auth.Value.Month==i).Count();

            }


            return View();
        }
       
    }
}

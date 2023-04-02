using Falla7_App.Context;
using Microsoft.AspNetCore.Mvc;

namespace Fallah_App.Controllers.WebMaster
{
    public class DemandesController : Controller
    {
        MyContext db;

        public DemandesController(MyContext db)
        {
            this.db = db;
        }

        public IActionResult List()
        {
            return View();
        }
    }
}

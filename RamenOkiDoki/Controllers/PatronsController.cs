using Microsoft.AspNetCore.Mvc;

namespace RamenOkiDoki.Controllers
{
    public class PatronsController : Microsoft.AspNetCore.Mvc.Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

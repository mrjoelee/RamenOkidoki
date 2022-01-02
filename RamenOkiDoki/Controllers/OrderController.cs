using Microsoft.AspNetCore.Mvc;

namespace RamenOkiDoki.Controllers
{
    public class OrderController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

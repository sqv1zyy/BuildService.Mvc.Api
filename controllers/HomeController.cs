using Microsoft.AspNetCore.Mvc;

namespace BuildService.Mvc.Api.controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

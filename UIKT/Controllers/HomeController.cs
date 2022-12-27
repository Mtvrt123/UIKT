using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Reflection;
using UIKT.Models;

namespace UIKT.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult OddajaVloge()
        {
            return View(new Vloga());
        }

        [HttpPost]
        public IActionResult OddajaVloge(Vloga vloga)
        {
            if (ModelState.IsValid)
            {
                Logic.WriteFile(vloga);
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }

        [HttpGet]
        public IActionResult PregledVlog()
        {
            List<Vloga> vloge = Logic.ReadFileForUser(int.Parse(HttpContext.Session.GetString("id")));

            return View(vloge);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
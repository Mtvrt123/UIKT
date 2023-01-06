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
                Logic.AddVloga(vloga);
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
            if (HttpContext.Session.GetString("role") == "admin")
            {
                return View(Logic.GetAll());
            }
            else
            {
                List<Vloga> vloge = Logic.GetVlogeByUserId(int.Parse(HttpContext.Session.GetString("id")));

                return View(vloge);
            }
        }

        [HttpGet]
        public IActionResult PregledVloge(string id)
        {
            TempData["skupna_pov"] = Logic.GetSkupnaPovrsina();
            TempData["skupna_pov_max"] = 15000;

            Vloga vloge = Logic.GetVlogaById(id);

            return View(vloge);
        }

        [HttpPost]
        public IActionResult Potrdi(string id)
        {
            Logic.UpdateVloga(id, true);

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Zavrni(string id)
        {
            Logic.UpdateVloga(id, false);

            return RedirectToAction("Index");
        }

        //[HttpPost]
        public IActionResult SpremembaLokacije(string id)
        {

            Vloga vloge = Logic.GetVlogaById(id);

            return View(vloge);
        }
        
        
        [HttpPost]
        public IActionResult SpremembaLokacije(Vloga vloga)
        {

            Logic.SpremembaLokacije(vloga);

            return RedirectToAction("Index");

        }


        //[HttpPost]
        public IActionResult KoncnaOddaja(string id)
        {
            Logic.KoncnaOddaja(id);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
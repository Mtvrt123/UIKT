using Microsoft.AspNetCore.Mvc;
using UIKT.Models;

namespace UIKT.Controllers
{
    public class LoginController : Controller
    {
        List<UserModel> logins = new List<UserModel>()
        {
            new UserModel() {  Id=1 , Email = "admin@gmail.com", Password = "admin", Role = "admin" },
            new UserModel() {  Id=2 , Email = "user@gmail.com", Password = "user", Role = "user" }

        };

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(string email, string password)
        {
            UserModel loginModel = logins.FirstOrDefault(x => x.Email == email && x.Password == password);

            if (loginModel != null)
            {
                HttpContext.Session.SetString("email", loginModel.Email);
                HttpContext.Session.SetString("role", loginModel.Role);
                HttpContext.Session.SetString("id", loginModel.Id.ToString());

                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View();
            }
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");
        }
    }
}

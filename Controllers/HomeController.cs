using Microsoft.AspNetCore.Mvc;
using WebApplication5_2.Models;
using WebApplication5_2.Services;


namespace WebApplication5_2.Controllers
{
    public class HomeController : Controller
    {
        private readonly CookieService _cookieService;

        public HomeController(CookieService cookieService)
        {
            _cookieService = cookieService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SetCookie(CookieModel model)
        {
            if (ModelState.IsValid)
            {
                _cookieService.SetCookie(model.Value, model.ExpirationDate);
                return RedirectToAction("Check", "Cookie");
            }
            return View("Index", model);
        }

        public IActionResult ThrowError()
        {
            throw new Exception("This is a test exception for logging.");
        }
    }
}
using Microsoft.AspNetCore.Mvc;
using WebApplication5_2.Services;

namespace WebApplication5_2.Controllers
{
    public class CookieController : Controller
    {
        private readonly CookieService _cookieService;

        public CookieController(CookieService cookieService)
        {
            _cookieService = cookieService;
        }

        public IActionResult Check()
        {
            var cookieValue = _cookieService.GetCookieValue();
            return View(model: cookieValue);
        }
    }
}
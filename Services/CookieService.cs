using Microsoft.AspNetCore.Http;
using System;

namespace WebApplication5_2.Services
{
    public class CookieService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CookieService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public void SetCookie(string value, DateTime expirationDate)
        {
            _httpContextAccessor.HttpContext.Response.Cookies.Append("CustomCookie", value, new CookieOptions
            {
                Expires = expirationDate
            });
        }

        public string GetCookieValue()
        {
            return _httpContextAccessor.HttpContext.Request.Cookies["CustomCookie"];
        }
    }
}
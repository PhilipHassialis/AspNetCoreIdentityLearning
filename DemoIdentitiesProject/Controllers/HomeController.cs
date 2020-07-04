using System.Collections.Generic;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DemoIdentitiesProject.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [Authorize]
        public IActionResult Secret()
        {
            return View();
        }

        public IActionResult Authenticate()
        {
            var userClaim = new List<Claim>() {
                new Claim(ClaimTypes.Name,"Philip"),
                new Claim(ClaimTypes.Role,"Administrator")
            };

            var identity = new ClaimsIdentity(userClaim, "ApplicationClaims");
            var userPrincipal = new ClaimsPrincipal(identity);

            HttpContext.SignInAsync(userPrincipal);


            return RedirectToAction("Index");
        }
    }
}
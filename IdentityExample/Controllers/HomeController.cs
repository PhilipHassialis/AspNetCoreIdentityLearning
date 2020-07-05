using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace IdentityExample.Controllers
{
    public class HomeController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;

        public HomeController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Secret()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        public async Task<IActionResult> Login(string username, string password)
        {
            // login functionality
            var user = await _userManager.FindByNameAsync(username);
            if (user != null)
            {
                // sign in
            }
            return RedirectToAction("Index");
        }

        public IActionResult Register()
        {
            return View();
        }

        public async Task<IActionResult> Register(string username, string password)
        {
            // register functionality
            IdentityUser user = new IdentityUser()
            {
                UserName = username,
                Email = ""
            };

            var result = await _userManager.CreateAsync(user, password);
            if (result.Succeeded)
            {
                // sign user here
            }

            return RedirectToAction("Index");
        }



    }
}
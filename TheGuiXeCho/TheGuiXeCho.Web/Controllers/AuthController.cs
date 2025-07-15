using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TheGuiXeCho.Web.Entity;
using TheGuiXeCho.Web.Interface;
using TheGuiXeCho.Web.Services;

namespace TheGuiXeCho.Web.Controllers
{
    public class AuthController : Controller
    {
        private readonly IUserService userService;
        public AuthController(IUserService userService)
        {
            this.userService = userService;
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(string userName, string password)
        {
            if (await userService.Login(userName, password))
            {
                return RedirectToAction("Index", "Home");
            }
            ModelState.AddModelError("", "Invalid username or password.");
            return RedirectToAction("Login");
        }
    }
}

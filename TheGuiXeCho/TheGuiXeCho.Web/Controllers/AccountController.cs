using Microsoft.AspNetCore.Mvc;
using TheGuiXeCho.Web.Interface;

namespace TheGuiXeCho.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserService userService;
        public AccountController(IUserService userService)
        {
            this.userService = userService;
        }
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost()]
        public async Task<IActionResult> Register(string userName, string password, string fullName, CancellationToken cancellation = default)
        {
            if (await userService.Register(userName, password, fullName, cancellation))
            {
                return RedirectToAction("Login", "Auth");
            }
            ModelState.AddModelError("", "Registration failed. Please try again.");
            return View();
        }
    }
}

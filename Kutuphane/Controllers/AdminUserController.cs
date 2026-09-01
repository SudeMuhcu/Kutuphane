using Kutuphane.Models;
using Kutuphane.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Kutuphane.Controllers
{

    public class AdminUserController : Controller
    {
        private readonly IUserService _userService;

        public AdminUserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public IActionResult AddAdmin()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddAdmin(string UserName, string Password)
        {
            var admin = new AppUser
            {
                UserName = UserName,
                PasswordHash = Password,
                Role = UserRole.Admin,
                MustChangePassword = true
            };

            _userService.AddUser(admin);

            return RedirectToAction("AddAdmin");
        }
    }
}
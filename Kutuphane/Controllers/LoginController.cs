using Kutuphane.Models;
using Kutuphane.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
namespace Kutuphane.Controllers
{
    public class LoginController : Controller
    {
        private readonly IUserService _userService;
        
        public LoginController(
         IUserService userservice)
        {
            _userService = userservice;
           
        }




        [HttpPost]
        public async Task<IActionResult> Login(
            UserRole role,
            string loginValue,
            string password)
        {
            var user = _userService.Login(role, loginValue, password);
            if(user ==null)
            {
                TempData["LoginError"] = "Kullanıcı bilgileri hatağlı";
                return RedirectToAction("Index");
            }
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(ClaimTypes.Role, user.Role.ToString()),
                new Claim("AppUserId", user.AppUserId.ToString())
            };

           

          


            var identity = new ClaimsIdentity(claims, "CookieAuth" );
               
           

            var principal = new ClaimsPrincipal(identity);

            var authProperties = new AuthenticationProperties
            {
                IsPersistent = false
            };
            await HttpContext.SignInAsync("CookieAuth", principal, authProperties);
            // bu kod bloğu siteden çıkıldığında oturumu otomatık olarak kapatıcak

            if (user.Role== UserRole.Admin)
            {
                return RedirectToAction("Index", "Admin");
            }    
             return RedirectToAction("Index", "Student");
        }


      

        [HttpGet]
        public IActionResult Index()
        {
            if (Request.Query.ContainsKey("ReturnUrl"))
            {
                ViewBag.SessionMessage = "Oturumunuz sona erdi veya bu sayfaya erişmek için giriş yapmanız gerekiyor.";
            }
            return View();
        }

        [HttpGet]
        public IActionResult AccessDenied()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync("CookieAuth");
            return RedirectToAction("Index");
        }







        }
}

using Business.Abstract;
using Entities.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc; 

namespace TourCompany.Web.Controllers
{
    [AllowAnonymous]
    public class AccountController : Controller
    {
        private IAuthService _authService; 
        public AccountController(IAuthService authService)
        {
            _authService = authService; 
        }
        public ActionResult Login()
        {
            return View(new UserForLoginDto());
        }

        [HttpPost]
        public async Task<ActionResult> Login(UserForLoginDto userForLoginDto)
        {
            var userToLogin = _authService.Login(userForLoginDto);
            if (!userToLogin.Success)
            {
                return View(userForLoginDto);
            }
            var tokenResult = _authService.CreateAccessToken(userToLogin.Data);
            if (tokenResult.Success)
            {
                HttpContext.Session.SetString("JWToken", tokenResult.Data.Token);
                HttpContext.Session.SetString("Name", $"{userToLogin.Data.FirstName} {userToLogin.Data.LastName}");
                HttpContext.Session.SetString("UserId", userToLogin.Data.Id.ToString());
                return RedirectToAction("Index", "Home");
            }
            return View(userForLoginDto);
        }
         

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login", "Account");
        }
    }
} 

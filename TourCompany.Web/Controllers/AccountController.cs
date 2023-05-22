using AspNetCoreHero.ToastNotification.Abstractions;
using Business.Abstract;
using Entities.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TourCompany.Web.Models.ViewModels;

namespace TourCompany.Web.Controllers
{
    [AllowAnonymous]
    public class AccountController : Controller
    {
        private IAuthService _authService;
        private IUserService _userService;
        private readonly INotyfService _notyf;

        public AccountController(IAuthService authService, IUserService userService, INotyfService notyf)
        {
            _authService = authService;
            _userService = userService;
            _notyf = notyf;
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginViewModel userForLoginDto)
        {
            var userToLogin = _authService.LoginUser(new UserForLoginDto
            {
                Password = userForLoginDto.Password,
                Email = userForLoginDto.Email
            });

            if (!userToLogin.Success)
            {
                if (userToLogin.StatusCode == 400)
                {
                    foreach (var message in userToLogin.MessageList)
                    {
                        ModelState.AddModelError(message.Key, message.Value);
                    }
                    return View(userForLoginDto);
                }
                _notyf.Error(userToLogin.Message);
                return View(userForLoginDto);
            }

            var tokenResult = _authService.CreateAccessToken(userToLogin.Data);
            if (tokenResult.Success)
            {
                var claims = _userService.GetClaimsByUserId(userToLogin.Data.Id).Data;
                HttpContext.Session.SetString("JWToken", tokenResult.Data.Token);
                HttpContext.Session.SetString("Name", $"{userToLogin.Data.FirstName} {userToLogin.Data.LastName}");
                HttpContext.Session.SetString("UserId", userToLogin.Data.Id.ToString());
                HttpContext.Session.SetString("UserClaim", (claims != null && claims.Count > 0) ? string.Join(",", claims.Select(x => x.Name).ToArray()) : "");

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

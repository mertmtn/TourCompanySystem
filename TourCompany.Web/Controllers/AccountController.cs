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
        private IHttpContextAccessor _httpContext;
        public AccountController(IAuthService authService, IHttpContextAccessor httpContext)
        {
            _authService = authService;
            _httpContext = httpContext;
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

        public ActionResult Register()
        {
            return View(new UserForRegisterDto());
        }

        [HttpPost]
        public ActionResult Register(UserForRegisterDto userForRegisterDto)
        {
            var userExists = _authService.UserExists(userForRegisterDto.Email);
            if (!userExists.Success)
            {
                return BadRequest(userExists.Message);
            }

            var registerResult = _authService.Register(userForRegisterDto, userForRegisterDto.Password);
            var result = _authService.CreateAccessToken(registerResult.Data);
            if (result.Success)
            {
                return Ok(result.Data);
            }

            return BadRequest(result.Message);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login", "Account");
        }
    }
} 

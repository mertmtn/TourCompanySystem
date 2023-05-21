using AspNetCoreHero.ToastNotification.Abstractions;
using Business.Abstract;
using Entities.DTO;
using Microsoft.AspNetCore.Mvc;

namespace TourCompany.Web.Controllers
{
    public class UserController : Controller
    {
        private IAuthService _authService;
        private readonly IUserService _userService;
        private readonly INotyfService _notyf;
        private IHttpContextAccessor httpContext;

        public UserController(IAuthService authService, IUserService userService, INotyfService notyf, IHttpContextAccessor httpContext)
        {
            _authService = authService;
            _userService = userService;
            _notyf = notyf;
            this.httpContext = httpContext;
        }

        public IActionResult Index()
        {
            return View(_userService.GetAll().Data);
        }

        public ActionResult Register()
        {
            return PartialView("~/Views/User/Partials/Register.cshtml");
        }

        [HttpPost]
        public ActionResult Register(UserForRegisterDto userForRegisterDto)
        {
            var userExists = _userService.UserExists(userForRegisterDto.Email);
            if (!userExists.Success)
            {
                return BadRequest(userExists.Message);
            }

            var registerResult = _userService.Register(userForRegisterDto, userForRegisterDto.Password);
             

            if (registerResult.StatusCode == 400)
            {
                foreach (var message in registerResult.MessageList)
                {
                    ModelState.AddModelError(message.Key, message.Value);
                }

                return PartialView("~/Views/Country/Partials/Create.cshtml", userForRegisterDto);
            }

            return Json(registerResult);
        }


        public IActionResult Edit(int? id)
        {
            var user = _userService.GetById(id.Value);

            return (user.Data != null) ? PartialView("~/Views/User/Partials/Edit.cshtml", new UserForRegisterDto()
            {
                FirstName = user.Data.FirstName,
                LastName = user.Data.LastName,
                Email= user.Data.EMail,
                MaidenName=user.Data.MaidenName,
                Id = user.Data.Id,
                IsActive = user.Data.IsActive
            }) : NotFound();
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public JsonResult Edit(UserForRegisterDto userForRegisterDto)
        {
            var result = _userService.UpdateUserInfo(new ()
            {
                FirstName = userForRegisterDto.FirstName,
                Id = userForRegisterDto.Id,
                IsActive = userForRegisterDto.IsActive,
                LastName = userForRegisterDto.LastName,
                EMail = userForRegisterDto.Email,
                MaidenName = userForRegisterDto.MaidenName,
            });

            return Json(result);
        }

        [HttpGet]
        public IActionResult Detail(int? id)
        { 
            var user = _userService.GetById(id.Value);
            return (user != null) ? PartialView("~/Views/User/Partials/Detail.cshtml", new UserForRegisterDto()
            {
                FirstName = user.Data.FirstName,
                LastName = user.Data.LastName,
                Email = user.Data.EMail,
                MaidenName = user.Data.MaidenName,
                Id = user.Data.Id,
                IsActive = user.Data.IsActive
            }) : NotFound();
        }
    }
}

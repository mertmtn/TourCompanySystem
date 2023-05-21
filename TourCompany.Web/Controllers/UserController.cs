using AspNetCoreHero.ToastNotification.Abstractions;
using Business.Abstract;
using Entities.DTO;
using Microsoft.AspNetCore.Mvc;

namespace TourCompany.Web.Controllers
{
    public class UserController : Controller
    { 
        private readonly IUserService _userService;
        private readonly INotyfService _notyf;

        public UserController(IUserService userService, INotyfService notyf)
        {
            _userService = userService;
            _notyf = notyf;
        }

        public IActionResult Index()
        {
            return View(_userService.GetAll().Data);
        }

        public ActionResult Create()
        {
            return PartialView("~/Views/User/Partials/Create.cshtml");
        }

        [HttpPost]
        public ActionResult Create(UserCreateOrEditViewModel registerViewModel)
        {
            var userExists = _userService.UserExists(registerViewModel.Email);
            if (!userExists.Success)
            {
                _notyf.Warning(userExists.Message);
                return PartialView("~/Views/User/Partials/Create.cshtml", registerViewModel);
            }

            var registerResult = _userService.Register(new UserForRegisterDto()
            {
                FirstName = registerViewModel.FirstName,
                Id = registerViewModel.Id,
                IsActive = registerViewModel.IsActive,
                LastName = registerViewModel.LastName,
                Email = registerViewModel.Email,
                MaidenName = registerViewModel.MaidenName,
                Password=registerViewModel.Password
            });

            if (registerResult.StatusCode == 400)
            {
                foreach (var message in registerResult.MessageList)
                {
                    ModelState.AddModelError(message.Key, message.Value);
                }

                return PartialView("~/Views/User/Partials/Create.cshtml", registerViewModel);
            }

            return Json(registerResult);
        }

        public IActionResult Edit(int? id)
        {
            var user = _userService.GetById(id.Value);

            return (user.Data != null) ? PartialView("~/Views/User/Partials/Edit.cshtml", new UserCreateOrEditViewModel()
            {
                FirstName = user.Data.FirstName,
                LastName = user.Data.LastName,
                Email = user.Data.EMail,
                MaidenName = user.Data.MaidenName,
                Id = user.Data.Id,
                IsActive = user.Data.IsActive
            }) : NotFound();
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public JsonResult Edit(UserCreateOrEditViewModel registerViewModel)
        {
            var result = _userService.UpdateUserInfo(new()
            {
                FirstName = registerViewModel.FirstName,
                Id = registerViewModel.Id,
                IsActive = registerViewModel.IsActive,
                LastName = registerViewModel.LastName,
                EMail = registerViewModel.Email,
                MaidenName = registerViewModel.MaidenName,
            });

            return Json(result);
        }

        [HttpGet]
        public IActionResult Detail(int? id)
        {
            var user = _userService.GetById(id.Value);
            return (user != null) ? PartialView("~/Views/User/Partials/Detail.cshtml", new UserCreateOrEditViewModel()
            {
                FirstName = user.Data.FirstName,
                LastName = user.Data.LastName,
                Email = user.Data.EMail,
                MaidenName = user.Data.MaidenName,
                Id = user.Data.Id,
                IsActive = user.Data.IsActive
            }) : NotFound();
        }

        [HttpGet]
        public IActionResult GetUserClaimsByUserId(int? id)
        {
            var userOperationClaims = _userService.GetClaimsByUserId(id.Value).Data;
            return (userOperationClaims != null) ? PartialView("~/Views/Claim/Partials/UserClaimList.cshtml", userOperationClaims) : NotFound();
        }
    }
}

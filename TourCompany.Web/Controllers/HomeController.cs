using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace TourCompany.Web.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class HomeController : Controller
    {
        private readonly INotyfService _notyf;


        public HomeController(INotyfService notyf)
        {
            _notyf = notyf;
        } 

        public IActionResult Index()
        {
             _notyf.Success("Hoşgeldiniz "+ HttpContext.Session.GetString("Name"));
            return View();
        } 
    }
}
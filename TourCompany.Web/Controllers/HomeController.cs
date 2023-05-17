using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace TourCompany.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly INotyfService _notyf;
        public HomeController(INotyfService notyf)
        {
            _notyf = notyf;
        }
        public IActionResult Index()
        {
            _notyf.Success("Success Notification");
            return View();
        } 
    }
}
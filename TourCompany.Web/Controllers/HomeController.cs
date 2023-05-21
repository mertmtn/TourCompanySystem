using AspNetCoreHero.ToastNotification.Abstractions;
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
            //TODO: Kullanıcı karşılama eklenecek.
           // _notyf.Success("Success Notification");
            return View();
        } 
    }
}
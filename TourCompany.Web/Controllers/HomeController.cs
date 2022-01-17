using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TourCompany.Web.Models;

namespace TourCompany.Web.Controllers
{
    public class HomeController : Controller
    { 
        public IActionResult Index()
        {
            return View();
        } 
    }
}
﻿using Microsoft.AspNetCore.Mvc;

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
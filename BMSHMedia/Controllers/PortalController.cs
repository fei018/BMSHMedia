﻿using Microsoft.AspNetCore.Mvc;

namespace BMSHMedia.Controllers
{
    public class PortalController : Controller
    {
        public IActionResult Index()
        {
            //return RedirectToAction("Index", "Media", new {Area="Portal"});
            return View();
        }

        public IActionResult ManSangOrigin()
        {
            return View();
        }

        public IActionResult Master()
        {
            return View();
        }

        public IActionResult ManSangContact()
        {
            return View();
        }

        public IActionResult Calendar()
        {
            return View();
        }
    }
}

﻿using BMSHMedia.ViewModel.ActivityPostVMs;
using Microsoft.AspNetCore.Mvc;
using WalkingTec.Mvvm.Core;

namespace BMSHMedia.Controllers
{
    public class PortalController : Controller
    {


        public IActionResult Index()
        {
            //return RedirectToAction("PostList", "ActivityPost");
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

        public IActionResult LHMOrigin()
        {
            return View();
        }

        public IActionResult LHMContact()
        {
            return View();
        }
    }
}

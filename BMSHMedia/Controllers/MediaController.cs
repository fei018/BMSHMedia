﻿using BMSHMedia.ViewModel.MediaVMs;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;


namespace BMSHMedia.Controllers
{
    public class MediaController : Controller
    {
        public IActionResult Index()
        {
            var vm = new MediaScanVM();
            vm.UpLevelFolderPath = MediaBaseVM.EncodePath(SiteConfigInfo.MediaRootPath);
            return View(vm);
        }

        [HttpPost]
        public IActionResult List(string path)
        {
            var vm = new MediaScanVM();
            vm.ScanFolderAndFiles(path);

            return PartialView(vm);
        }

        [HttpPost]
        public IActionResult Play(MediaFileVM vm)
        {           
            return View(vm);
        }


        //public Task<IActionResult> DownloadFile(string url)
        //{
        //    return File()
        //}
    }
}

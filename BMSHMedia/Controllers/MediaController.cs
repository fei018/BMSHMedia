using BMSHMedia.ViewModel.MediaVMs;
using Microsoft.AspNetCore.Mvc;
using System;


namespace BMSHMedia.Controllers
{
    public class MediaController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult List(string path)
        {
            if (string.IsNullOrEmpty(path))
            {
                var vm = new MediaFileScanVM();
                vm.ScanFolders(SiteConfigInfo.MediaRootPath, true);

                return View(vm);
            }
            else
            {

                var vm = new MediaFileScanVM();
                vm.ScanFolders(path, false);

                return PartialView(vm);
            }
        }
    }
}

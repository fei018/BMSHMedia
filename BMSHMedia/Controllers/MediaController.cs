using BMSHMedia.ViewModel.MediaVMs;
using Microsoft.AspNetCore.Mvc;
using System;


namespace BMSHMedia.Controllers
{
    public class MediaController : Controller
    {
        public IActionResult Index(string path)
        {
            

            if (string.IsNullOrEmpty(path))
            {


                var vm = new MediaFileScanVM();
                vm.ScanFolders(SiteConfigInfo.MediaRootPath, true);

                return View(vm);
            }
            else
            {
                path = Uri.UnescapeDataString(path);

                var vm = new MediaFileScanVM();
                vm.ScanFolders(path, false);

                return View(vm);
            }

            
        }
    }
}

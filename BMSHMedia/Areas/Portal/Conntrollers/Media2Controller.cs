using BMSHMedia.Portal.ViewModel.MediaApiVMs;
using BMSHMedia.Portal.ViewModel.MediaVMs;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;


namespace BMSHMedia.Controllers
{
    public class Media2Controller : Controller
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


        public async Task<string> FolderListJson()
        {
            return await new MediaApiVM().GetJsonData();
        }
    }
}

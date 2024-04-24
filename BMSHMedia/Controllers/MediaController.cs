using BMSHMedia.ViewModel.MediaApiVMs;
using BMSHMedia.ViewModel.MediaVMs;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace BMSHMedia.Controllers
{
    public class MediaController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult List(string Id)
        {
            var vm = MediaApiVM.MediaFolderVM2List.SingleOrDefault(x => x.Id == Id);
            if (vm != null)
            {
                return PartialView(vm);
            }

            return View(vm);
        }

        [HttpPost]
        public IActionResult Play(MediaFileVM vm)
        {
            return View(vm);
        }
    }
}

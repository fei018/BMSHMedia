using BMSHMedia.Extentions;
using BMSHMedia.ViewModel.MediaVMs;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;

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
            try
            {
                var vm = MediaApiVM.GetMediaFolderList().SingleOrDefault(x => x.Id == Id);
                if (vm != null)
                {
                    return PartialView(vm);
                }
                else
                {
                    return this.ErrorView($"MediaContentList, id:({Id}) not found.");
                }
            }
            catch (Exception ex)
            {
                return this.ErrorView(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult Play(MediaFileVM vm)
        {
            return View(vm);
        }

        public IActionResult Reload()
        {
            try
            {
                Task.Run(MediaApiVM.ScanAllAsync);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return this.ErrorView(ex.Message);
            }
        }
    }
}

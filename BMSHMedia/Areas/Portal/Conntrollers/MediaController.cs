using BMSHMedia.Portal.ViewModel.MediaApiVMs;
using BMSHMedia.Portal.ViewModel.MediaVMs;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;
using BMSHMedia.Extentions;

namespace BMSHMedia.Controllers
{
    [Area("Portal")]
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
                var vm = MediaApiVM.GetMediaContentList().SingleOrDefault(x => x.Id == Id);
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

        public async Task<IActionResult> ReloadMedia()
        {
            try
            {
                await MediaApiVM.ScanAllAsync();
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return this.ErrorView(ex.Message);
            }
        }
    }
}

using BMSHMedia.Extentions;
using BMSHMedia.ViewModel.SRSVMs;
using Microsoft.AspNetCore.Mvc;
using System;
using WalkingTec.Mvvm.Core;

namespace BMSHMedia.Areas.Portal.Conntrollers
{
    [Area("Portal")]
    public class LiveController : Controller
    {
        private readonly WTMContext _wtm;

        public LiveController(WTMContext wtm)
        {
            _wtm = wtm;
        }

        public IActionResult Index()
        {
            try
            {
                var vm = _wtm.CreateVM<SRSOpenAPIVM>();
                return View(vm);
            }
            catch (Exception ex)
            {
                return this.ErrorView(ex.Message);
            }
        }
    }
}

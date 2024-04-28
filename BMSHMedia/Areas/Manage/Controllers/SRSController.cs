using BMSHMedia.Extentions;
using BMSHMedia.Model.Manage.SRS;
using BMSHMedia.ViewModel.SRSVMs;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Mvc;

namespace BMSHMedia.Manage.Controllers
{
    [Area("Manage")]
    [ActionDescription("SRS")]
    public class SRSController : BaseController
    {
        [ActionDescription("Index")]
        public IActionResult Index()
        {
            return PartialView();
        }

        [ActionDescription("直播Key")]
        public IActionResult LiveKey()
        {
            try
            {
                var vm = Wtm.CreateVM<SRSOpenAPIVM>();
                vm.GetLiveKey();
                return PartialView(vm);
            }
            catch (Exception ex)
            {
                return this.ErrorView(ex.Message);
            }
        }

        [ActionDescription("OPenAPI")]
        public IActionResult OPenAPI()
        {
            var vm = Wtm.CreateVM<SRSOpenAPIVM>();
            var en = DC.Set<SRSStackInfo>().FirstOrDefault();
            if (en == null)
            {
                return PartialView(vm);
            }
            else
            {
                vm.Entity = en;
                return PartialView(vm);
            }
            
        }

        [ActionDescription("OPenAPI")]
        [HttpPost]
        public IActionResult OPenAPI(SRSOpenAPIVM vm)
        {
            if (!ModelState.IsValid)
            {
                return PartialView(vm);
            }
            else
            {
                vm.SaveApiSecret();
                return Content("OK");
            }
        }
    }
}

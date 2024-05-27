using BMSHMedia.ViewModel.EmailSettingVMs;
using Microsoft.AspNetCore.Mvc;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Mvc;

namespace BMSHMedia.Manage.Controllers
{
    [Area("Manage")]
    [ActionDescription("Email配置")]
    public class EmailSettingController : BaseController
    {
        public IActionResult Index()
        {
            var vm = Wtm.CreateVM<EmailSettingVM>();
            return View(vm);
        }


        [ActionDescription("編輯")]
        public IActionResult Edit()
        {
            var vm = Wtm.CreateVM<EmailSettingVM>();
            return View(vm);
        }

        [ActionDescription("編輯")]
        [HttpPost]
        public IActionResult Edit(EmailSettingVM vm)
        {
            if (!ModelState.IsValid)
            {
                return PartialView(vm);
            }
            else
            {
                vm.DoAdd();

                if (!ModelState.IsValid)
                {
                    vm.DoReInit();
                    return PartialView(vm);
                }

                return FFResult().CloseDialog().Message("已保存.");
            }
        }
    }
}

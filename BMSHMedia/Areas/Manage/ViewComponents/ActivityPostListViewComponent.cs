using BMSHMedia.ViewModel.ActivityPostVMs;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;

namespace BMSHMedia.Manage.ViewComponents
{
    public class ActivityPostListViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(WTMContext Wtm ,int pageIndex = 1, int pageSize = 2)
        {
            var vm = Wtm.CreateVM<ActivityPostVM>();
            var list = await vm.GetPagedList(pageIndex, pageSize);

            return View(list);
        }
    }
}

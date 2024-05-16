using BMSHMedia.ViewModel.ActivityPostVMs;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Mvc;

namespace BMSHMedia.Manage.ApiControllers
{
    [ActionDescription("活動Post")]
    [ApiController]
    [Route("api/[controller]")]
    [Public]
    public class ActivityPostController : BaseController
    {
        [ActionDescription("PostList")]
        [HttpGet("[action]/{pageIndex}")]
        public async Task<IActionResult> PostList(int? pageIndex)
        {
            int pageSize = int.Parse(Wtm.ConfigInfo.AppSettings["ActivityPostPageSize"]);

            int index = pageIndex ?? 1;

            var vm = Wtm.CreateVM<ActivityPostVM>();
            var list = await vm.GetActivityPostApiResult(index, pageSize);

            return Json(list);
        }
    }
}

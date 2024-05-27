using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Mvc;
using WalkingTec.Mvvm.Core.Extensions;
using BMSHMedia.ViewModel.ActivityPostVMs;
using WalkingTec.Mvvm.Mvc.Binders;
using BMSHMedia.Model.Activity;
using System.Threading.Tasks;

namespace BMSHMedia.Manage.Controllers
{
    [Area("Manage")]
    [ActionDescription("活動消息")]
    public partial class ActivityPostController : BaseController
    {
        #region Search
        [ActionDescription("Sys.Search")]
        public ActionResult Index()
        {
            var vm = Wtm.CreateVM<ActivityPostListVM>();
            return PartialView(vm);
        }

        [ActionDescription("Sys.Search")]
        [HttpPost]
        public string Search(ActivityPostSearcher searcher)
        {
            var vm = Wtm.CreateVM<ActivityPostListVM>(passInit: true);
            if (ModelState.IsValid)
            {
                vm.Searcher = searcher;
                return vm.GetJson(false);
            }
            else
            {
                return vm.GetError();
            }
        }

        #endregion

        #region Create
        [ActionDescription("Sys.Create")]
        public ActionResult Create()
        {
            var vm = Wtm.CreateVM<ActivityPostVM>();
            return PartialView(vm);
        }

        [HttpPost]
        [ActionDescription("Sys.Create")]
        [StringNeedLTGT]
        public ActionResult Create(ActivityPostVM vm)
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
                else
                {
                    return FFResult().CloseDialog().RefreshGrid();
                    //return FFResult().AddCustomScript("ff.LoadPage('/manage/activitypost/index');");
                }
            }
        }
        #endregion

        #region Edit
        [ActionDescription("Sys.Edit")]
        public ActionResult Edit(string id)
        {
            var vm = Wtm.CreateVM<ActivityPostVM>(id);
            return PartialView(vm);
        }

        [ActionDescription("Sys.Edit")]
        [HttpPost]
        [ValidateFormItemOnly]
        [StringNeedLTGT]
        public ActionResult Edit(ActivityPostVM vm)
        {
            if (!ModelState.IsValid)
            {
                return PartialView(vm);
            }
            else
            {
                vm.DoEdit();
                if (!ModelState.IsValid)
                {
                    vm.DoReInit();
                    return PartialView(vm);
                }
                else
                {
                    return FFResult().CloseDialog().RefreshGridRow(vm.Entity.ID);
                }
            }
        }
        #endregion

        #region Delete
        [ActionDescription("Sys.Delete")]
        public ActionResult Delete(string id)
        {
            var vm = Wtm.CreateVM<ActivityPostVM>(id);
            return PartialView(vm);
        }

        [ActionDescription("Sys.Delete")]
        [HttpPost]
        public ActionResult Delete(string id, IFormCollection nouse)
        {
            var vm = Wtm.CreateVM<ActivityPostVM>(id);
            vm.DoDelete();
            if (!ModelState.IsValid)
            {
                return PartialView(vm);
            }
            else
            {
                return FFResult().CloseDialog().RefreshGrid();
            }
        }
        #endregion

        #region Details
        
        [Route("/activitypost/[action]/{id}")]
        //[ActionDescription("Sys.Details")]
        [Public]
        public ActionResult Details(string id)
        {
            var vm = Wtm.CreateVM<ActivityPostVM>(id);
            return PartialView(vm);
        }
        #endregion

        #region BatchDelete
        [HttpPost]
        [ActionDescription("Sys.BatchDelete")]
        public ActionResult BatchDelete(string[] IDs)
        {
            var vm = Wtm.CreateVM<ActivityPostBatchVM>(Ids: IDs);
            return PartialView(vm);
        }

        [HttpPost]
        [ActionDescription("Sys.BatchDelete")]
        public ActionResult DoBatchDelete(ActivityPostBatchVM vm, IFormCollection nouse)
        {
            if (!ModelState.IsValid || !vm.DoBatchDelete())
            {
                return PartialView("BatchDelete",vm);
            }
            else
            {
                return FFResult().CloseDialog().RefreshGrid().Alert(Localizer["Sys.BatchDeleteSuccess", vm.Ids.Length]);
            }
        }
        #endregion

        #region Publish
        [ActionDescription("發佈")]
        public IActionResult Publish(string id)
        {
            var vm = Wtm.CreateVM<ActivityPostVM>(id);
            return PartialView(vm);
        }

        [HttpPost]
        [ActionDescription("發佈")]
        public IActionResult Publish(string id, IFormCollection nouse)
        {
            try
            {
                var vm = DC.Set<ActivityPost>().Find(Guid.Parse(id));
                vm.IsPublish = true;
                DC.UpdateProperty(vm, x => x.IsPublish);
                DC.SaveChanges();
                return FFResult().CloseDialog().RefreshGrid();
            }
            catch (Exception ex)
            {
                return Content(ex.Message);
            }
        }
        #endregion

        #region PostList
        private int _pageSize = 10;

        [Route("/activitypost/[action]")]
        [Public]
        public async Task<IActionResult> PostList(int pageIndex = 1)
        {
            var vm = Wtm.CreateVM<ActivityPostVM>();
            var list = await vm.GetPagedList(pageIndex, _pageSize);

            return View(list);
        }

        //[Route("/activitypost/[action]")]
        //[Public]
        //public async Task<IActionResult> PostList2(int pageIndex = 1)
        //{
        //    var vm = Wtm.CreateVM<ActivityPostVM>();
        //    var list = await vm.GetPagedList(pageIndex, _pageSize);

        //    return PartialView(list);
        //}
        #endregion
    }
}

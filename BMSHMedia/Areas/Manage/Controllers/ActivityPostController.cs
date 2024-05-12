﻿using Microsoft.AspNetCore.Http;
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
    [ActionDescription("活動Post")]
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
        [ActionDescription("Sys.Details")]
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

        #region Preview
        [ActionDescription("預覽")]
        public IActionResult Preview(string id)
        {
            var vm = Wtm.CreateVM<ActivityPostVM>(id);
            return PartialView(vm);
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

        #region SavePublish
        [HttpPost]
        [ActionDescription("保存及發佈")]
        [StringNeedLTGT]
        public IActionResult SavePublish(ActivityPostVM vm)
        {
            if (!ModelState.IsValid)
            {
                return PartialView("Create", vm);
            }
            else
            {
                vm.DoAdd();
                if (!ModelState.IsValid)
                {
                    vm.DoReInit();
                    return PartialView("Create", vm);
                }
                else
                {
                    try
                    {
                        vm.Entity.IsPublish = true;
                        DC.UpdateProperty(vm.Entity, x => x.IsPublish);
                    }
                    catch (Exception ex)
                    {
                        vm.MSD.AddModelError("", ex.Message);
                        return PartialView("Create", vm);
                    }
                    return FFResult().CloseDialog().RefreshGrid();
                }
            }

        }
        #endregion

        #region MyRegion
        [Route("/activitypost/[action]")]
        [Public]
        public async Task<IActionResult> List(int pageIndex=1, int pageSize = 2)
        {
            var vm = Wtm.CreateVM<ActivityPostPagedListVM>();
            var list = await vm.GetPagedList(pageIndex, pageSize);
   
            return View(list);
        }
        #endregion
    }
}

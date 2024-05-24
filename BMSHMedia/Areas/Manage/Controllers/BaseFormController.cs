using BMSHMedia.Extentions;
using BMSHMedia.Model.Form;
using BMSHMedia.ViewModel.BaseFormVMs;
using BMSHMedia.ViewModel.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using WalkingTec.Mvvm.Mvc;
using WalkingTec.Mvvm.Mvc.Binders;

namespace BMSHMedia.Controllers
{
    [Area("Manage")]
    [ActionDescription("基本表單")]
    public partial class BaseFormController : BaseController
    {

        #region Search
        [ActionDescription("Sys.Search")]
        public ActionResult Index()
        {
            var vm = Wtm.CreateVM<BaseFormListVM>();
            return PartialView(vm);
        }

        [ActionDescription("Sys.Search")]
        [HttpPost]
        public string Search(BaseFormSearcher searcher)
        {
            var vm = Wtm.CreateVM<BaseFormListVM>(passInit: true);
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
            var vm = Wtm.CreateVM<BaseFormVM>();
            return PartialView(vm);
        }

        [HttpPost]
        [ActionDescription("Sys.Create")]
        [StringNeedLTGT]
        public ActionResult Create(BaseFormVM vm)
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
            try
            {
                var vm = Wtm.CreateVM<BaseFormVM>(id);
                vm.CheckEdit();
                return PartialView(vm);
            }
            catch (Exception ex)
            {
                return Content(ex.Message);
            }
        }

        [ActionDescription("Sys.Edit")]
        [HttpPost]
        [ValidateFormItemOnly]
        [StringNeedLTGT]
        public ActionResult Edit(BaseFormVM vm)
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
            var vm = Wtm.CreateVM<BaseFormVM>(id);
            return PartialView(vm);
        }

        [ActionDescription("Sys.Delete")]
        [HttpPost]
        public ActionResult Delete(string id, IFormCollection nouse)
        {
            var vm = Wtm.CreateVM<BaseFormVM>(id);

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
            var vm = Wtm.CreateVM<BaseFormVM>(id);
            return PartialView(vm);
        }
        #endregion

        #region BatchEdit
        [HttpPost]
        [ActionDescription("Sys.BatchEdit")]
        public ActionResult BatchEdit(string[] IDs)
        {
            var vm = Wtm.CreateVM<BaseFormBatchVM>(Ids: IDs);
            return PartialView(vm);
        }

        [HttpPost]
        [ActionDescription("Sys.BatchEdit")]
        public ActionResult DoBatchEdit(BaseFormBatchVM vm, IFormCollection nouse)
        {
            if (!ModelState.IsValid || !vm.DoBatchEdit())
            {
                return PartialView("BatchEdit", vm);
            }
            else
            {
                return FFResult().CloseDialog().RefreshGrid().Alert(Localizer["Sys.BatchEditSuccess", vm.Ids.Length]);
            }
        }
        #endregion

        #region BatchDelete
        [HttpPost]
        [ActionDescription("Sys.BatchDelete")]
        public ActionResult BatchDelete(string[] IDs)
        {
            var vm = Wtm.CreateVM<BaseFormBatchVM>(Ids: IDs);
            return PartialView(vm);
        }

        [HttpPost]
        [ActionDescription("Sys.BatchDelete")]
        public ActionResult DoBatchDelete(BaseFormBatchVM vm, IFormCollection nouse)
        {
            if (!ModelState.IsValid || !vm.DoBatchDelete())
            {
                return PartialView("BatchDelete", vm);
            }
            else
            {
                return FFResult().CloseDialog().RefreshGrid().Alert(Localizer["Sys.BatchDeleteSuccess", vm.Ids.Length]);
            }
        }
        #endregion

        #region Import
        //[ActionDescription("Sys.Import")]
        //      public ActionResult Import()
        //      {
        //          var vm = Wtm.CreateVM<BaseFormImportVM>();
        //          return PartialView(vm);
        //      }

        //      [HttpPost]
        //      [ActionDescription("Sys.Import")]
        //      public ActionResult Import(BaseFormImportVM vm, IFormCollection nouse)
        //      {
        //          if (vm.ErrorListVM.EntityList.Count > 0 || !vm.BatchSaveData())
        //          {
        //              return PartialView(vm);
        //          }
        //          else
        //          {
        //              return FFResult().CloseDialog().RefreshGrid().Alert(Localizer["Sys.ImportSuccess", vm.EntityList.Count.ToString()]);
        //          }
        //      }
        #endregion

        //[ActionDescription("Sys.Export")]
        //[HttpPost]
        //public IActionResult ExportExcel(BaseFormListVM vm)
        //{
        //    return vm.GetExportData();
        //}

        #region Publish
        [ActionDescription("發佈")]
        public IActionResult Publish(string id)
        {
            var vm = Wtm.CreateVM<BaseFormVM>(id);
            return PartialView(vm);
        }

        [HttpPost]
        [ActionDescription("發佈")]
        public IActionResult Publish(BaseFormVM vm)
        {
            try
            {
                vm.DoPublish();
                return FFResult().CloseDialog().RefreshGrid();
            }
            catch (Exception ex)
            {
                return Content(ex.Message);
            }
        }
        #endregion

        #region QuerySubmitList
        [ActionDescription("查看提交表單數據")]
        public async Task<IActionResult> QuerySubmitList(string id)
        {
            try
            {
                var vm = Wtm.CreateVM<BaseFormVM>(id);
                await vm.QueryFormSubmitList();

                return PartialView(vm);
            }
            catch (Exception ex)
            {
                return this.ErrorView(ex.Message);
            }
        }
        #endregion

        #region /forms/post/{id}
        [Public]
        [Route("/forms/[action]/{id}")]
        public IActionResult Submit(string id)
        {
            var vm = Wtm.CreateVM<BaseFormVM>(id);
            return View(vm);
        }
        #endregion

        #region HttpPost: /forms/Submit
        [Route("/forms/[action]")]
        [Public]
        [HttpPost]
        public IActionResult Submit(IFormCollection postForm)
        {
            try
            {
                var vm = Wtm.CreateVM<BaseFormVM>();
                vm.SubmitForm(postForm);

                return Ok("提交成功.");
            }
            catch (Exception ex)
            {
                return this.ErrorView(ex.Message);
            }
        }
        #endregion

        #region /forms/FormsIndex
        [Route("/forms/[action]")]
        [Public]
        public async Task<IActionResult> FormsIndex(int pageIndex = 1)
        {
            try
            {
                var vm = Wtm.CreateVM<BaseFormVM>();
                var result = await vm.GetBaseFormPagedList(pageIndex);
                return View(result);
            }
            catch (Exception ex)
            {
                return this.ErrorView(ex.Message);
            }
        }
        #endregion

        #region 
        [ActionDescription("下載提交數據Excel")]
        public async Task<IActionResult> FormSubmitExcel(string id)
        {
            try
            {
                var vm = Wtm.CreateVM<BaseFormVM>(id);
                var result = await vm.GetFormSubmitExcel();
                return File(result, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", vm.Entity.FormName + ".xlsx");
            }
            catch (Exception ex)
            {
                return this.ErrorView(ex.Message);
            }
        }
        #endregion
    }
}

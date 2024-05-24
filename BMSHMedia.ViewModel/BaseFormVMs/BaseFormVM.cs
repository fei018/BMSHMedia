using BMSHMedia.Model.Form;
using BMSHMedia.ViewModel.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Primitives;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using X.PagedList;


namespace BMSHMedia.ViewModel.BaseFormVMs
{
    public partial class BaseFormVM : BaseCRUDVM<BaseForm>
    {

        public BaseFormVM()
        {
        }

        protected override void InitVM()
        {
        }

        public override void DoAdd()
        {
            base.DoAdd();
        }

        public override void DoEdit(bool updateAllFields = false)
        {
            base.DoEdit(updateAllFields);
        }

        public override void DoDelete()
        {
            base.DoDelete();

            var submits = DC.Set<BaseFormSubmit>().CheckID(Entity.ID,x=>x.BaseFormId).ToList();
            DC.Set<BaseFormSubmit>().RemoveRange(submits);
            DC.SaveChanges();
        }

        #region CheckEdit
        /// <summary>
        /// 檢查表單是否已經有提交的數據，如有就不能再修改
        /// </summary>
        /// <exception cref="throw: 此表單已經有數據提交，拒絕修改"></exception>
        public void CheckEdit()
        {
            var submits = DC.Set<BaseFormSubmit>().CheckID(Entity.ID, x => x.ID).ToList();
            if (submits != null && submits.Count > 0)
            {
                throw new Exception("此表單已經有數據提交，拒絕修改.");
            }
        }
        #endregion

        #region QuerFormPostList
        public List<BaseFormSubmit> FormSubmitList { get; set; } = new();

        public async Task QueryFormSubmitList(string baseFormId)
        {
            var submits = await DC.Set<BaseFormSubmit>().AsNoTracking()
                                    .Include(x => x.FormSubmitDataList)
                                    .CheckID(baseFormId, x => x.BaseFormId)
                                    .OrderByDescending(x=>x.SubmitTime)
                                    .ToListAsync();

            if (submits.Count <= 0)
            {
                throw new Exception("查無數據.");
            }

            FormSubmitList = submits;
        }
        #endregion

        #region SubmitForm
        public void SubmitForm(IFormCollection postForm)
        {
            string id = postForm["baseFormId"].Single();

            var entity = DC.Set<BaseForm>().Where(x => x.ID.ToString().ToLower() == id.ToLower()).SingleOrDefault();

            var formDataJsonList = JsonConvert.DeserializeObject<List<BaseFormDataJson>>(entity.FormData);

            var submitDataList = new List<BaseFormSubmitData>();

            Guid newSubmitId = Guid.NewGuid();

            foreach (var item in formDataJsonList)
            {
                if (!string.IsNullOrEmpty(item.Name))
                {
                    if (postForm.TryGetValue(item.Name, out StringValues value))
                    {
                        var vm = new BaseFormSubmitData()
                        {
                            Name = item.Name,
                            Value = value,
                            Label = item.Label,
                            FormSubmitId = newSubmitId
                        };

                        submitDataList.Add(vm);
                    };
                }
            }

            var submit = new BaseFormSubmit()
            {
                SubmitTime = DateTime.Now,
                BaseFormId = Guid.Parse(id),
                BaseFormName = entity.FormName,
                ID = newSubmitId
            };

            DC.Set<BaseFormSubmit>().Add(submit);
            DC.Set<BaseFormSubmitData>().AddRange(submitDataList);
            DC.SaveChanges();
        }
        #endregion

        #region GetBaseFormList
        public List<BaseForm_View> BaseFormList { get; set; } = new();

        /// <summary>
        /// 顯示 form list 頁面數據
        /// </summary>
        public async Task<IPagedList<BaseForm_View>> GetBaseFormPagedList(int pageIndex)
        {
            var vm = await DC.Set<BaseForm>().Where(x => x.IsPublish)
                                        .Select(x => new BaseForm_View
                                        {
                                            ID = x.ID,
                                            FormName = x.FormName,
                                        })
                                        .ToPagedListAsync(pageIndex, 10);
            return vm;
        }
        #endregion
    }
}

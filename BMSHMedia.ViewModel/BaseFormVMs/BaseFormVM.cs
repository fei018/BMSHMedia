using BMSHMedia.Model.Form;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using MiniExcelLibs;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
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

            // 刪除 下面的提交數據
            var submits = DC.Set<BaseFormSubmit>().CheckID(Entity.ID, x => x.BaseFormId).ToList();
            DC.Set<BaseFormSubmit>().RemoveRange(submits);
            DC.SaveChanges();
        }

        #region DoPublish
        public void DoPublish()
        {
            DC.UpdateProperty(Entity, x => x.IsPublish);
            DC.SaveChanges();
        }
        #endregion

        #region CheckEdit
        /// <summary>
        /// 檢查表單是否已經有提交的數據，如有就不能再修改
        /// </summary>
        /// <exception cref="throw: 此表單已經有數據提交，拒絕修改"></exception>
        public void CheckEdit()
        {
            var submits = DC.Set<BaseFormSubmit>().CheckID(Entity.ID, x => x.BaseFormId).ToList();
            if (submits != null && submits.Count > 0)
            {
                throw new Exception("此表單已經有數據提交，拒絕修改.");
            }
        }
        #endregion

        #region QuerFormPostList
        public List<BaseFormSubmit> FormSubmitList { get; set; } = new();

        public async Task QueryFormSubmitList()
        {
            var submits = await DC.Set<BaseFormSubmit>().AsNoTracking()
                                    .Include(x => x.FormSubmitDataList)
                                    .CheckID(Entity.ID, x => x.BaseFormId)
                                    .OrderByDescending(x => x.SubmitTime)
                                    .ToListAsync();



            if (submits.Count <= 0)
            {
                throw new Exception("查無數據.");
            }

            FormSubmitList = submits;
        }
        #endregion

        #region SubmitForm
        /// <summary>
        /// 提交 Form
        /// </summary>
        /// <param name="postForm"></param>
        /// <returns></returns>
        public async Task SubmitForm(IFormCollection postForm)
        {
            string id = postForm["baseFormId"].Single();

            var entity = await DC.Set<BaseForm>().Where(x => x.ID.ToString().ToLower() == id.ToLower()).FirstOrDefaultAsync();

            if (entity == null)
            {
                throw new Exception("BaseForm id: " + id + " query null from database.");
            }

            var formDataFormatList = JsonConvert.DeserializeObject<List<BaseFormDataFormat>>(entity.FormData);

            var submitDataList = new List<BaseFormSubmitData>();

            Guid newSubmitId = Guid.NewGuid();

            foreach (var format in formDataFormatList)
            {
                if (!string.IsNullOrEmpty(format.Name))
                {
                    // 單元數據
                    var vm = new BaseFormSubmitData
                    {
                        Name = format.Name,
                        Label = format.Label,
                        FormSubmitId = newSubmitId,
                        Value = string.Empty,
                    };

                    // 提交的表單 name 可能比 format.Name 結尾多字符
                    foreach (var post in postForm)
                    {
                        // format.name 匹配 提交表單的單元 key 開頭, 
                        if (post.Key.StartsWith(format.Name, StringComparison.OrdinalIgnoreCase))
                        {
                            vm.Value = post.Value;
                            break;
                        }
                    }

                    submitDataList.Add(vm);
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

            //string subject = $"{entity.FormName} 有新數據提交, {submit.SubmitTime:yyyy-MM-dd HH:mm:ss}";
            //await Wtm.CreateVM<EmailSettingVM>().SendEmail(subject, subject);
        }
        #endregion

        #region GetBaseFormPagedList
        /// <summary>
        /// 顯示 form list 頁面數據
        /// </summary>
        public async Task<IPagedList<BaseForm_View>> GetBaseFormPagedList(int pageIndex)
        {
            var vm = await DC.Set<BaseForm>().Where(x => x.IsPublish)
                                        .OrderByDescending(x => x.CreateTime)
                                        .Select(x => new BaseForm_View
                                        {
                                            ID = x.ID,
                                            FormName = x.FormName,
                                        })
                                        .ToPagedListAsync(pageIndex, 10);
            return vm;
        }
        #endregion

        #region GetFormSubmitExcel
        public async Task<byte[]> GetFormSubmitExcel()
        {
            await QueryFormSubmitList();

            var entity = DC.Set<BaseForm>().AsNoTracking().CheckID(Entity.ID, x => x.ID).SingleOrDefault();

            var formDataFormatList = JsonConvert.DeserializeObject<List<BaseFormDataFormat>>(entity.FormData);

            var result = new List<Dictionary<string, object>>();

            // 添加 列名 和 第一行數據 ( name = 列名, lable = 第一行數據 )
            var column = new Dictionary<string, object>();
            foreach (var format in formDataFormatList)
            {
                if (!string.IsNullOrEmpty(format.Name))
                {
                    column.Add(format.Name, format.Label);
                }
            }

            result.Add(column);

            foreach (var submit in FormSubmitList)
            {
                var row = new Dictionary<string, object>();

                // 新增 row， 按照 列col 給 row 添加 cell 數據
                foreach (var col in column)
                {
                    var cell = submit.FormSubmitDataList.SingleOrDefault(x => x.Name == col.Key);
                    if (cell == null)
                    {
                        row.Add(col.Key, string.Empty);
                    }
                    else
                    {
                        row.Add(col.Key, cell.Value);
                    }
                }

                result.Add(row);
            }

            using var ms = new MemoryStream();
            await ms.SaveAsAsync(result);
            return ms.ToArray();
        }
        #endregion
    }
}

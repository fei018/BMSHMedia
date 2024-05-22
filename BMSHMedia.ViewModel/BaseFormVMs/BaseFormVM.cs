using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using BMSHMedia.Model.Form;
using Newtonsoft.Json;
using BMSHMedia.DataAccess;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Primitives;
using Microsoft.Extensions.Hosting;
using BMSHMedia.ViewModel.Services;


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
        }

        #region QuerFormPostList
        public List<BaseFormSubmit> SubmitFormList { get; set; } = new();

        public void QuerySubmitFormList(string baseFormId, BaseFormSubmitDbService formSubmitDbService)
        {
            var posts = formSubmitDbService.GetByBaseFormID(baseFormId);

            if (posts.Count <= 0)
            {
                throw new Exception(nameof(BaseForm) + "ID:(" + baseFormId + ") is null in LiteDb.");
            }

            SubmitFormList = posts;
        }
        #endregion

        #region SubmitForm
        public void SubmitForm(IFormCollection postForm, BaseFormSubmitDbService formSubmitDbService)
        {
            string id = postForm["baseFormId"].Single();

            var entity = DC.Set<BaseForm>().Where(x => x.ID.ToString().ToLower() == id.ToLower()).SingleOrDefault();

            var formDataJsonList = JsonConvert.DeserializeObject<List<BaseFormDataJson>>(entity.FormData);

            var list = new List<BaseFormSubmitNameValue>();

            foreach (var item in formDataJsonList)
            {
                if (!string.IsNullOrEmpty(item.Name))
                {
                    if (postForm.TryGetValue(item.Name, out StringValues value))
                    {
                        var vm = new BaseFormSubmitNameValue()
                        {
                            Name = item.Name,
                            Value = value,
                            Label = item.Label,
                        };
                        list.Add(vm);
                    };
                }              
            }

            var post = new BaseFormSubmit()
            {
                SubmitTime = DateTime.Now,
                BaseFormId = id,
                FormPostData = list
            };

            formSubmitDbService.Insert(post);
        }
        #endregion

        #region GetBaseFormList
        public List<BaseForm_View> BaseFormList { get; set; } = new();

        public void GetBaseFormList()
        {
            var vm = Wtm.CreateVM<BaseFormListVM>();
            BaseFormList = vm.GetEntityList().ToList();
        }
        #endregion
    }
}

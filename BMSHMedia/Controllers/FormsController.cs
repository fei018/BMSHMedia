using BMSHMedia.DataAccess;
using BMSHMedia.Model.Form;
using BMSHMedia.ViewModel.BaseFormVMs;
using Elsa.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;

namespace BMSHMedia.Controllers
{
    public class FormsController : Controller
    {
        private readonly WTMContext _wtm;

        private readonly IDataContext _dc;

        private LiteDbContext _LiteDb { get; }

        public FormsController(WTMContext wtm, LiteDbContext liteDb)
        {
            _wtm = wtm;
            _LiteDb = liteDb;
            _dc = wtm.DC;
        }

        

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Post(string id)
        {
            //var vm = _dc.Set<BaseForm>().Where(x=>x.ID.ToString().ToLower() == id.ToLower());
            var vm = _wtm.CreateVM<BaseFormVM>(id);
            return View(vm);
        }

        [HttpPost]
        public IActionResult Post(IFormCollection postForm)
        {
            string id = postForm["baseFormId"].Single();

            var entity = _dc.Set<BaseForm>().Where(x => x.ID.ToString().ToLower() == id.ToLower()).SingleOrDefault();

            var formDataJsonList = JsonConvert.DeserializeObject<List<BaseFormDataJson>>(entity.FormData);

            var list = new List<FormPostNameValue>();

            foreach (var item in formDataJsonList)
            {
                if (string.IsNullOrEmpty(item.Name))
                {
                    continue;
                }
                if(postForm.TryGetValue(item.Name, out Microsoft.Extensions.Primitives.StringValues value))
                {
                    var vm = new FormPostNameValue()
                    {
                        Name = item.Name,
                        Value = value,
                        Label = item.Label,
                    };
                    list.Add(vm);
                };

                var cg = _LiteDb.GetDb_FormPost();
                var post = new FormPost()
                {
                    BaseFormId = id,
                    FormPostData = list
                };
                cg.Insert(post);
            }

            return Ok();
        }

    }
}

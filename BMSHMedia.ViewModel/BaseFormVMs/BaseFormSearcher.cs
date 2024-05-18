using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using BMSHMedia.Model.Form;


namespace BMSHMedia.ViewModel.BaseFormVMs
{
    public partial class BaseFormSearcher : BaseSearcher
    {
        [Display(Name = "表單名")]
        public String FormName { get; set; }

        protected override void InitVM()
        {
        }

    }
}

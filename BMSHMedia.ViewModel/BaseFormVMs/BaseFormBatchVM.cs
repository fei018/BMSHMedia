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
    public partial class BaseFormBatchVM : BaseBatchVM<BaseForm, BaseForm_BatchEdit>
    {
        public BaseFormBatchVM()
        {
            ListVM = new BaseFormListVM();
            LinkedVM = new BaseForm_BatchEdit();
        }

    }

	/// <summary>
    /// Class to define batch edit fields
    /// </summary>
    public class BaseForm_BatchEdit : BaseVM
    {

        protected override void InitVM()
        {
        }

    }

}

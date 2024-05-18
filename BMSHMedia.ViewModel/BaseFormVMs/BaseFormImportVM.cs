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
    public partial class BaseFormTemplateVM : BaseTemplateVM
    {

	    protected override void InitVM()
        {
        }

    }

    public class BaseFormImportVM : BaseImportVM<BaseFormTemplateVM, BaseForm>
    {

    }

}

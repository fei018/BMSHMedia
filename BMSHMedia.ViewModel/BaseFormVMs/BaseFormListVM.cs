using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using BMSHMedia.Model.Form;


namespace BMSHMedia.ViewModel.BaseFormVMs
{
    public partial class BaseFormListVM : BasePagedListVM<BaseForm_View, BaseFormSearcher>
    {
        protected override List<GridAction> InitGridAction()
        {
            return new List<GridAction>
            {
                this.MakeStandardAction("BaseForm", GridActionStandardTypesEnum.Create, Localizer["Sys.Create"],"Manage", dialogWidth: 800).SetIsRedirect().SetShowDialog(false),
                this.MakeStandardAction("BaseForm", GridActionStandardTypesEnum.Edit, Localizer["Sys.Edit"], "Manage", dialogWidth: 800),
                this.MakeStandardAction("BaseForm", GridActionStandardTypesEnum.Delete, Localizer["Sys.Delete"], "Manage", dialogWidth: 800),
                this.MakeStandardAction("BaseForm", GridActionStandardTypesEnum.Details, Localizer["Sys.Details"], "Manage", dialogWidth: 800),
                this.MakeStandardAction("BaseForm", GridActionStandardTypesEnum.BatchEdit, Localizer["Sys.BatchEdit"], "Manage", dialogWidth: 800),
                this.MakeStandardAction("BaseForm", GridActionStandardTypesEnum.BatchDelete, Localizer["Sys.BatchDelete"], "Manage", dialogWidth: 800),
                this.MakeStandardAction("BaseForm", GridActionStandardTypesEnum.Import, Localizer["Sys.Import"], "Manage", dialogWidth: 800),
                this.MakeStandardAction("BaseForm", GridActionStandardTypesEnum.ExportExcel, Localizer["Sys.Export"], "Manage"),
            };
        }


        protected override IEnumerable<IGridColumn<BaseForm_View>> InitGridHeader()
        {
            return new List<GridColumn<BaseForm_View>>{
                this.MakeGridHeader(x => x.FormName),
                this.MakeGridHeaderAction(width: 200)
            };
        }

        public override IOrderedQueryable<BaseForm_View> GetSearchQuery()
        {
            var query = DC.Set<BaseForm>()
                .CheckContain(Searcher.FormName, x=>x.FormName)
                .Select(x => new BaseForm_View
                {
				    ID = x.ID,
                    FormName = x.FormName,
                })
                .OrderBy(x => x.ID);
            return query;
        }

    }

    public class BaseForm_View : BaseForm{

    }
}

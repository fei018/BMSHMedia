using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using BMSHMedia.Model.PostNews;


namespace BMSHMedia.ViewModel.Manage.PostInfoVMs
{
    public partial class PostInfoListVM : BasePagedListVM<PostInfo_View, PostInfoSearcher>
    {
        protected override List<GridAction> InitGridAction()
        {
            return new List<GridAction>
            {
                this.MakeStandardAction("PostInfo", GridActionStandardTypesEnum.Create, Localizer["Sys.Create"],"Manage", dialogWidth: 800).SetIsRedirect().SetShowDialog(),
                this.MakeStandardAction("PostInfo", GridActionStandardTypesEnum.Edit, Localizer["Sys.Edit"], "Manage", dialogWidth: 800).SetIsRedirect().SetShowDialog(),
                this.MakeStandardAction("PostInfo", GridActionStandardTypesEnum.Delete, Localizer["Sys.Delete"], "Manage", dialogWidth: 800).SetIsRedirect().SetShowDialog(),
                this.MakeStandardAction("PostInfo", GridActionStandardTypesEnum.Details, Localizer["Sys.Details"], "Manage", dialogWidth: 800).SetIsRedirect().SetShowDialog(),
                this.MakeStandardAction("PostInfo", GridActionStandardTypesEnum.BatchEdit, Localizer["Sys.BatchEdit"], "Manage", dialogWidth: 800),
                this.MakeStandardAction("PostInfo", GridActionStandardTypesEnum.BatchDelete, Localizer["Sys.BatchDelete"], "Manage", dialogWidth: 800),
                this.MakeStandardAction("PostInfo", GridActionStandardTypesEnum.Import, Localizer["Sys.Import"], "Manage", dialogWidth: 800),
                this.MakeStandardAction("PostInfo", GridActionStandardTypesEnum.ExportExcel, Localizer["Sys.Export"], "Manage"),
            };
        }


        protected override IEnumerable<IGridColumn<PostInfo_View>> InitGridHeader()
        {
            return new List<GridColumn<PostInfo_View>>{
                this.MakeGridHeader(x => x.Title),
                this.MakeGridHeaderAction(width: 200)
            };
        }

        public override IOrderedQueryable<PostInfo_View> GetSearchQuery()
        {
            var query = DC.Set<PostInfo>()
                .CheckContain(Searcher.Title, x=>x.Title)
                .Select(x => new PostInfo_View
                {
				    ID = x.ID,
                    Title = x.Title,
                })
                .OrderBy(x => x.ID);
            return query;
        }

    }

    public class PostInfo_View : PostInfo{

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using BMSHMedia.Model.Activity;
using WalkingTec.Mvvm.Core.Support.FileHandlers;


namespace BMSHMedia.ViewModel.ActivityPostVMs
{
    public partial class ActivityPostListVM : BasePagedListVM<ActivityPost_View, ActivityPostSearcher>
    {
        protected override List<GridAction> InitGridAction()
        {
            return new List<GridAction>
            {
                this.MakeStandardAction("ActivityPost", GridActionStandardTypesEnum.Create, Localizer["Sys.Create"],"Manage", dialogWidth: 800, dialogHeight:800).SetIsRedirect().SetShowDialog(),
                this.MakeStandardAction("ActivityPost", GridActionStandardTypesEnum.Edit, Localizer["Sys.Edit"], "Manage", dialogWidth: 800,dialogHeight:800).SetIsRedirect().SetShowDialog(),
                this.MakeAction("ActivityPost","publish","發佈","發佈", GridActionParameterTypesEnum.SingleId,"Manage").SetShowInRow().SetHideOnToolBar(),
                this.MakeAction("ActivityPost","preview","預覽","預覽", GridActionParameterTypesEnum.SingleId,"Manage").SetShowInRow().SetHideOnToolBar().SetOnClickScript("postPreview"),
                this.MakeStandardAction("ActivityPost", GridActionStandardTypesEnum.Delete, Localizer["Sys.Delete"], "Manage", dialogWidth: 800),
                //this.MakeStandardAction("ActivityPost", GridActionStandardTypesEnum.Details, Localizer["Sys.Details"], "Manage", dialogWidth: 800).SetIsRedirect().SetShowDialog(),
                
                this.MakeStandardAction("ActivityPost", GridActionStandardTypesEnum.BatchDelete, Localizer["Sys.BatchDelete"], "Manage", dialogWidth: 800),
            };
        }


        protected override IEnumerable<IGridColumn<ActivityPost_View>> InitGridHeader()
        {
            return new List<GridColumn<ActivityPost_View>>{
                this.MakeGridHeader(x=>x.CreateTime,width:150),
                this.MakeGridHeader(x => x.Title),
                this.MakeGridHeader(x=> x.Published),
                //this.MakeGridHeader(x => x.IsPublish).SetHide().SetFormat((e, v) => e.IsPublish),
                this.MakeGridHeaderAction(width: 250)
            };
        }

        public override IOrderedQueryable<ActivityPost_View> GetSearchQuery()
        {
            var query = DC.Set<ActivityPost>()
                .CheckContain(Searcher.Title, x=>x.Title)
                .Select(x => new ActivityPost_View
                {
				    ID = x.ID,
                    Title = x.Title,
                    IsPublish = x.IsPublish,
                    
                    CreateTime = x.CreateTime,
                })
                .OrderBy(x => x.CreateTime);
            return query;
        }

    }

    public class ActivityPost_View : ActivityPost
    { 
        public string GetCreateDate()
        {
            var days = CreateTime.Value.Subtract(DateTime.Now).Days;
            if (days >= 7)
            {
                return CreateTime.Value.ToString("yyyy-MM-dd");
            }
            if (days == 0)
            {
                return "今天";
            }
            else
            {
                return days.ToString() + " 天前";
            }
        }
    }
}

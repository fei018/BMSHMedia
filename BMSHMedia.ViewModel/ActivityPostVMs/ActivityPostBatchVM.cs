using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using BMSHMedia.Model.Activity;


namespace BMSHMedia.ViewModel.ActivityPostVMs
{
    public partial class ActivityPostBatchVM : BaseBatchVM<ActivityPost, ActivityPost_BatchEdit>
    {
        public ActivityPostBatchVM()
        {
            ListVM = new ActivityPostListVM();
            LinkedVM = new ActivityPost_BatchEdit();
        }

    }

	/// <summary>
    /// Class to define batch edit fields
    /// </summary>
    public class ActivityPost_BatchEdit : BaseVM
    {

        protected override void InitVM()
        {
        }

    }

}

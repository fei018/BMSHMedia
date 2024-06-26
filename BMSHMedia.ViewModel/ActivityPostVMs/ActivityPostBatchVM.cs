﻿using BMSHMedia.Model.Activity;
using WalkingTec.Mvvm.Core;


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

using System;
using System.ComponentModel.DataAnnotations;
using WalkingTec.Mvvm.Core;


namespace BMSHMedia.ViewModel.ActivityPostVMs
{
    public partial class ActivityPostSearcher : BaseSearcher
    {
        [Display(Name = "標題")]
        public String Title { get; set; }

        protected override void InitVM()
        {
        }

    }
}

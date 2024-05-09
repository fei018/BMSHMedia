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
    public partial class ActivityPostSearcher : BaseSearcher
    {
        [Display(Name = "標題")]
        public String Title { get; set; }

        protected override void InitVM()
        {
        }

    }
}

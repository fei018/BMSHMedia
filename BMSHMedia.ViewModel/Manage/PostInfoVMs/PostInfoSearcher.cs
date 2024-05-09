using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using BMSHMedia.Model.PostNews;


namespace BMSHMedia.ViewModel.Manage.PostInfoVMs
{
    public partial class PostInfoSearcher : BaseSearcher
    {
        [Display(Name = "標題")]
        public String Title { get; set; }

        protected override void InitVM()
        {
        }

    }
}

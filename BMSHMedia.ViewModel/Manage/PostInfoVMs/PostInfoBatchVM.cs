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
    public partial class PostInfoBatchVM : BaseBatchVM<PostInfo, PostInfo_BatchEdit>
    {
        public PostInfoBatchVM()
        {
            ListVM = new PostInfoListVM();
            LinkedVM = new PostInfo_BatchEdit();
        }

    }

	/// <summary>
    /// Class to define batch edit fields
    /// </summary>
    public class PostInfo_BatchEdit : BaseVM
    {

        protected override void InitVM()
        {
        }

    }

}

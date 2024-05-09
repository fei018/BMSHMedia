﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using BMSHMedia.Model.PostNews;


namespace BMSHMedia.ViewModel.Manage.PostInfoVMs
{
    public partial class PostInfoTemplateVM : BaseTemplateVM
    {

	    protected override void InitVM()
        {
        }

    }

    public class PostInfoImportVM : BaseImportVM<PostInfoTemplateVM, PostInfo>
    {

    }

}

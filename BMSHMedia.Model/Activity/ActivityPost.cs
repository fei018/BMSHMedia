﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WalkingTec.Mvvm.Core;

namespace BMSHMedia.Model.Activity
{
    [Table("Info_ActivityPost")]
    [Display(Name = "活動帖子")]
    public class ActivityPost : BasePoco
    {
        [Display(Name = "標題")]
        [Required(ErrorMessage = "{0}必填")]
        public string Title { get; set; }

        [Display(Name = "說明")]
        //[Required(ErrorMessage = "{0}必填")]
        public string Text { get; set; }

        public bool IsPublish { get; set; } = false;

        [Display(Name = "圖片")]
        public List<ActivityPostAttach> PostAttachList { get; set; } = new();


        public string Published => IsPublish ? "已發佈" : "未發佈";
    }
}

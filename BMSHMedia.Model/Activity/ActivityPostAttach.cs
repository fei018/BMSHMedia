using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WalkingTec.Mvvm.Core;

namespace BMSHMedia.Model.Activity
{
    [Table("Info_ActivityPostAttach")]
    [Display(Name = "活動帖子附件")]
    public class ActivityPostAttach : TopBasePoco, ISubFile
    {

        [Display(Name = "帖子Id")]
        [Required(ErrorMessage = "{0}必填")]
        public Guid PostId { get; set; }

        public ActivityPost Post { get; set; }

        [Display(Name = "附件Id")]
        [Required(ErrorMessage = "{0}必填")]
        public Guid FileId { get; set; }

        public FileAttachment File { get; set; }

        [Display(Name = "序號")]
        public int Order { get; set; }

    }
}

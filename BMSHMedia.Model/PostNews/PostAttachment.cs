using System;
using System.ComponentModel.DataAnnotations;
using WalkingTec.Mvvm.Core;

namespace BMSHMedia.Model.PostNews
{
    public class PostAttachment : TopBasePoco, ISubFile
    {
        [Display(Name = "附件類別")]
        [Required(ErrorMessage = "{0}必填")]
        public PostAttachmentCategoryEnum FileCotegory { get; set; }

        [Display(Name = "序號")]
        public int Order { get; set; }


        [Display(Name = "帖子Id")]
        [Required(ErrorMessage = "{0}必填")]
        public Guid PostId { get; set; }

        public PostInfo Post { get; set; }

        [Display(Name = "附件Id")]
        [Required(ErrorMessage = "{0}必填")]
        public Guid FileId { get; set; }

        public FileAttachment File { get; set; }

    }
}

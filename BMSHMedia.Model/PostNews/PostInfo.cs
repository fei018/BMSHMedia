using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WalkingTec.Mvvm.Core;

namespace BMSHMedia.Model.PostNews
{
    [Table("Info_Post")]
    [Display(Name = "帖子")]
    public class PostInfo : BasePoco
    {
        [Display(Name = "標題")]
        [Required(ErrorMessage = "{0}必填")]
        public string Title { get; set; }

        [Display(Name = "内容")]
        [Required(ErrorMessage = "{0}必填")]
        public string Content { get; set; }

        //public List<PostAttachment> PostAttachmentList { get; set; } = new();
    }
}

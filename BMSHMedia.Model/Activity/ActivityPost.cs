using System.Collections.Generic;
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

        public List<ActivityPostAttach> AttachList { get; set; } = new();
    }
}

using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using WalkingTec.Mvvm.Core;

namespace BMSHMedia.Model.NavPage
{
    [Table("Info_Post")]
    [Display(Name = "文章頁面")]
    public class PostInfo : BasePoco
    {
        [Display(Name = "標題")]
        [Required(ErrorMessage = "{0}必填")]
        public string Title { get; set; }

        [Display(Name = "内容")]
        //[Required(ErrorMessage = "{0}必填")]
        public string Content { get; set; }

    }
}

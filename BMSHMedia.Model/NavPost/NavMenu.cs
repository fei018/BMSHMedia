using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WalkingTec.Mvvm.Core;

namespace BMSHMedia.Model.NavPage
{
    [Table("Info_NavMenu")]
    [Display(Name = "導航菜單")]
    public class NavMenu : TreePoco<NavMenu>
    {
        [Display(Name = "菜單名")]
        [Required(ErrorMessage = "{0}必填")]
        public string MenuName { get; set; }

        [Display(Name = "序號")]
        [Required(ErrorMessage = "{0}必填")]
        public int? Sequence { get; set; }

        [Display(Name = "鏈接地址")]
        public string Link { get; set; }
    }
}

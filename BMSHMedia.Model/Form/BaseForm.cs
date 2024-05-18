using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WalkingTec.Mvvm.Core;

namespace BMSHMedia.Model.Form
{
    [Table("Info_BaseForm")]
    public class BaseForm : BasePoco
    {
        [Display(Name = "表單名")]
        [Required(ErrorMessage = "{0}必填")]
        public string FormName { get; set; }

        [Display(Name = "表單數據")]
        [Required(ErrorMessage = "{0}必填")]
        public string FormData { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WalkingTec.Mvvm.Core;

namespace BMSHMedia.Model.Email
{
    [Table("Info_EmailSetting")]
    public class EmailSetting : TopBasePoco
    {
        [Display(Name = "Smtp主機")]
        [Required(ErrorMessage = "{0}必填")]
        public string SmtpHost { get; set; }

        [Display(Name = "Smtp端口")]
        [Required(ErrorMessage = "{0}必填")]
        public int SmtpPort { get; set; }

        [Display(Name = "Email.From")]
        [Required(ErrorMessage = "{0}必填")]
        public string EmailFrom { get; set; }

        [Display(Name = "Email.To")]
        [Required(ErrorMessage = "{0}必填")]
        public string EmailTo { get; set; }

        [Display(Name = "Account")]
        [Required(ErrorMessage = "{0}必填")]
        public string Account { get; set; }

        [Display(Name = "Password")]
        [Required(ErrorMessage = "{0}必填")]
        public string Password { get; set; }
    }
}

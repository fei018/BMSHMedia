using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WalkingTec.Mvvm.Core;

namespace BMSHMedia.Model.Manage.SRS
{
    [Table("Info_SRSStack")]
    public class SRSStackInfo : TopBasePoco
    {
        [Display(Name = "PlayUrl")]
        [Required(ErrorMessage = "{0}必填")]
        public string PlayUrl { get; set; }

        [Display(Name = "RTMPUrl")]
        [Required(ErrorMessage = "{0}必填")]
        public string RTMPUrl { get; set; }

        [Display(Name = "ApiSecret")]
        [Required(ErrorMessage = "{0}必填")]
        public string ApiSecret { get; set; }

        [Display(Name = "HostUrl")]
        [Required(ErrorMessage = "{0}必填")]
        public string PublishKeyApiUrl { get; set; }
    }
}

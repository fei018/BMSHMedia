using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WalkingTec.Mvvm.Core;

namespace BMSHMedia.Model.Manage.SRS
{
    [Table("Info_SRSStack")]
    public class SRSStackInfo : TopBasePoco
    {
        [Display(Name = "直播PlayUrl")]
        [Required(ErrorMessage = "{0}必填")]
        public string PlayUrl { get; set; }

        [Display(Name = "RTMPUrl")]
        [Required(ErrorMessage = "{0}必填")]
        public string RTMPUrl { get; set; }

        [Display(Name = "OpenAPIKey")]
        [Required(ErrorMessage = "{0}必填")]
        public string ApiSecret { get; set; }

        [Display(Name = "ApiUrl_PublishKey")]
        [Required(ErrorMessage = "{0}必填")]
        public string ApiUrl_PublishKey { get; set; }
    }
}

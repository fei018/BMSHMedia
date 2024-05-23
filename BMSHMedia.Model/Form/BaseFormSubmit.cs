using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;
using WalkingTec.Mvvm.Core;

namespace BMSHMedia.Model.Form
{
    /// <summary>
    /// 遞交的一條表單記錄
    /// </summary>
    [Table("Info_BaseFormSubmit")]
    public class BaseFormSubmit : TopBasePoco
    {
        [Display(Name = "提交時間")]
        public DateTime SubmitTime { get; set; }
        
        public Guid BaseFormId { get; set; }

        [Display(Name = "表單名")]
        public string BaseFormName { get; set; }

        public List<BaseFormSubmitData> FormSubmitDataList { get; set; } = new();

    }
}

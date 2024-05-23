using System;
using System.ComponentModel.DataAnnotations.Schema;
using WalkingTec.Mvvm.Core;

namespace BMSHMedia.Model.Form
{
    /// <summary>
    /// 遞交的一條表單記錄的詳細數據
    /// </summary>
    [Table("Info_BaseFormSubmitData")]
    public class BaseFormSubmitData : TopBasePoco
    {
        public string Label { get; set; }

        public string Name { get; set; }

        public string Value { get; set; }

        public Guid FormSubmitId { get; set; }

        public BaseFormSubmit FormSubmit { get; set; }
    }
}

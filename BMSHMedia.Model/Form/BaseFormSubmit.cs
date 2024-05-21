using System;
using System.Collections.Generic;

namespace BMSHMedia.Model.Form
{
    /// <summary>
    /// LiteDb
    /// </summary>
    public class BaseFormSubmit
    {
        public DateTime SubmitTime { get; set; }

        public string BaseFormId { get; set; }

        public List<BaseFormSubmitNameValue> FormPostData { get; set; }

    }
}

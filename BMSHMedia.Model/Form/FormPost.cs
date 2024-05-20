using System;
using System.Collections.Generic;

namespace BMSHMedia.Model.Form
{
    /// <summary>
    /// LiteDb
    /// </summary>
    public class FormPost
    {
        public string BaseFormId { get; set; }

        public List<FormPostNameValue> FormPostData { get; set; }
    }
}

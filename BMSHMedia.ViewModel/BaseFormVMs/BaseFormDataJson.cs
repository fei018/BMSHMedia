using System.Collections.Generic;

namespace BMSHMedia.ViewModel.BaseFormVMs
{
    public class BaseFormDataJson
    {
        public string Type { get; set; }
        public bool Required { get; set; }
        public string Label { get; set; }
        public string ClassName { get; set; }
        public string Name { get; set; }
        public bool Access { get; set; }
        public string Subtype { get; set; }
        public bool? Inline { get; set; }
        public bool? Other { get; set; }
        public List<BaseFormJsonRootOptionValue> Values { get; set; }
        public bool? Toggle { get; set; }
        public bool? Multiple { get; set; }
    }

    public class BaseFormJsonRootOptionValue
    {
        public string Label { get; set; }
        public string Value { get; set; }
        public bool Selected { get; set; }
    }
}

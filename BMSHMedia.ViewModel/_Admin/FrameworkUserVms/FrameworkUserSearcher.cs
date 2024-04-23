using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using WalkingTec.Mvvm.Core;
namespace BMSHMedia.ViewModel._Admin.FrameworkUserVMs
{
    public partial class FrameworkUserSearcher : BaseSearcher
    {

        public List<string> _AdminFrameworkUserSTempSelected { get; set; }
        [Display(Name = "_Model._FrameworkUser._ITCode")]
        public string ITCode { get; set; }
        [Display(Name = "_Model._FrameworkUser._Name")]
        public string Name { get; set; }
        [Display(Name = "_Model._FrameworkUser._IsValid")]
        public bool? IsValid { get; set; }

        protected override void InitVM()
        {

        }
    }

}
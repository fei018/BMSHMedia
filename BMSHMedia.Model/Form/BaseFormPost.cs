using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;

namespace BMSHMedia.Model.Form
{
    [Table("Info_BaseFormPost")]
    public class BaseFormPost : BasePoco
    {
        public string Data { get; set; }

        public Guid BaseFormId { get; set; }

        public BaseForm BaseForm { get; set; }
    }
}

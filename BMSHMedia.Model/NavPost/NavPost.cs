using System;
using System.ComponentModel.DataAnnotations.Schema;
using WalkingTec.Mvvm.Core;

namespace BMSHMedia.Model.NavPage
{
    [Table("Relate_NavPost")]
    public class NavPost : BasePoco
    {
        public Guid NavMenuId { get; set; }

        public Guid PostId { get; set; }
    }
}

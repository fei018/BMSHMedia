using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using BMSHMedia.Model.Activity;
using System.IO;


namespace BMSHMedia.ViewModel.ActivityPostVMs
{
    public partial class ActivityPostVM : BaseCRUDVM<ActivityPost>
    {
        #region MyRegion
        public List<FileAttachment> FileAttach { get; set; }

        #endregion

        public ActivityPostVM()
        {
            SetInclude(x=>x.AttachList);
        }

        protected override void InitVM()
        {
        }

        public override void DoAdd()
        {           
            base.DoAdd();
        }

        public override void DoEdit(bool updateAllFields = false)
        {
            base.DoEdit(updateAllFields);
        }

        public override void DoDelete()
        {
            base.DoDelete();
        }

        #region MyRegion
        public void GetFileAttachment()
        {
            FileAttach = new();

            foreach (var item in Entity.AttachList)
            {
                var file = DC.Set<FileAttachment>().Where(x => x.ID == item.FileId).SingleOrDefault();
                FileAttach.Add(file);
            }
        }
        #endregion
    }
}

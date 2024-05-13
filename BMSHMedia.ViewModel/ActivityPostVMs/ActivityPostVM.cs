using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using BMSHMedia.Model.Activity;
using System.IO;
using Microsoft.EntityFrameworkCore;
using X.PagedList;


namespace BMSHMedia.ViewModel.ActivityPostVMs
{
    public partial class ActivityPostVM : BaseCRUDVM<ActivityPost>
    {
        public string UploadSubDir => "ActivityPost\\image";
        public string PreviewUrl => "/manage/activitypost/preview";
        public string DoPubilshUrl => "/manage/activitypost/dopublish";
        public string SavePublishUrl => "/manage/activitypost/savepublish";
        #region MyRegion
        public List<FileAttachment> FileAttachmentList { get; set; }

        #endregion

        public ActivityPostVM()
        {
            SetInclude(x=>x.PostAttachList);
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

        #region GetFileAttachment
        public void GetFileAttachment()
        {
            FileAttachmentList = new();

            foreach (var item in Entity.PostAttachList)
            {
                var file = DC.Set<FileAttachment>().Where(x => x.ID == item.FileId).SingleOrDefault();
                FileAttachmentList.Add(file);
            }
        }
        #endregion

        #region GetPagedList
        public Task<IPagedList<ActivityPost_View>> GetPagedList(int index, int pageSize)
        {
            var list = DC.Set<ActivityPost>().AsNoTracking()
                                  .Include(x => x.PostAttachList)
                                  .OrderByDescending(x => x.CreateTime)
                                  .Select(x => new ActivityPost_View
                                  {
                                      ID = x.ID,
                                      Title = x.Title,
                                      Text = x.Text,
                                      IsPublish = x.IsPublish,
                                      CreateTime = x.CreateTime,
                                      PostAttachList = x.PostAttachList,
                                  })
                                  .ToPagedListAsync(index, pageSize);

            return list;
        }
        #endregion
    }
}

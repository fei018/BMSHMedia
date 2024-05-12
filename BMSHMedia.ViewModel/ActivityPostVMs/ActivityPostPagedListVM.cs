using BMSHMedia.Model.Activity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using X.PagedList;

namespace BMSHMedia.ViewModel.ActivityPostVMs
{
    public class ActivityPostPagedListVM : BaseVM
    {
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
    }
}

using BMSHMedia.Model.Activity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMSHMedia.ViewModel.ActivityPostVMs
{
    public class ActivityPost_View : ActivityPost
    {
        public string GetCreateDate()
        {
            var days = DateTime.Now.Subtract(CreateTime.Value).Days;
            if (days >= 7)
            {
                return CreateTime.Value.ToString("yyyy-MM-dd");
            }
            if (days == 0)
            {
                return "今天";
            }
            else
            {
                return days.ToString() + " 天前";
            }
        }
    }
}

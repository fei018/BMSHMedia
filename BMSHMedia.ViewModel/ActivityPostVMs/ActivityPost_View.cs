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
        public string GetCreateTime()
        {
            var days = DateTime.Now.Subtract(CreateTime.Value).Days;

            if (days < 1)
            {
                var hours = DateTime.Now.Subtract(CreateTime.Value).Hours;
                if (hours < 1)
                {
                    var minutes = DateTime.Now.Subtract(CreateTime.Value).Minutes;
                    return minutes < 1 ? "1分鐘內" : minutes.ToString() + "分鐘前";
                }
                else
                {
                    return hours.ToString() + "小時前";
                }
            }
            else if (days < 7)
            {
                return days.ToString() + "日前";
            }
            else
            {
                return CreateTime.Value.ToString("yyyy-MM-dd");
            }
        }
    }
}

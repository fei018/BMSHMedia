using System.Text.Json.Serialization;

namespace BMSHMedia.Common.Activity
{
    public class ActivityPostApiVM
    {
        public string ID { get; set; }

        public DateTime CreateTime { get; set; }

        public string Title { get; set; }

        public string Text { get; set; }

        public bool IsPublish { get; set; } = false;

        public List<string> FileIDList { get; set; } = new();

        [JsonIgnore]
        public string Published => IsPublish ? "已發佈" : "未發佈";

        public string GetCreateTime()
        {
            var days = DateTime.Now.Subtract(CreateTime).Days;

            if (days < 1)
            {
                var hours = DateTime.Now.Subtract(CreateTime).Hours;
                if (hours < 1)
                {
                    var minutes = DateTime.Now.Subtract(CreateTime).Minutes;
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
                return CreateTime.ToString("yyyy-MM-dd");
            }
        }
    }
}

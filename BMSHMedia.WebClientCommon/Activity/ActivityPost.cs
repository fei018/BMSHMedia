using System.Text.Json.Serialization;

namespace BMSHMedia.WebClientCommon.Activity
{
    public class ActivityPost
    {
        public string ID { get; set; }

        public DateTime CreateTime { get; set; }

        public string Title { get; set; }

        public string Text { get; set; }

        public bool IsPublish { get; set; } = false;

        public List<string> FileIDList { get; set; } = new();

        [JsonIgnore]
        public string Published => IsPublish ? "已發佈" : "未發佈";
        [JsonIgnore]
        public string CreateDate => CreateTime.ToString("yyyy-MM-dd");
    }
}

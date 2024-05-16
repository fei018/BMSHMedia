namespace BMSHMedia.WebClientCommon.Activity
{
    public class ActivityPostApiResult
    {
        public List<ActivityPost> PostList { get; set; } = new();
        public int PageIndex { get; set; }
        public int PageCount { get; set; }
    }
}

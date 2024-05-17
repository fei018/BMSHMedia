namespace BMSHMedia.Common.Activity
{
    public class ActivityPostApiResult
    {
        public List<ActivityPostApiVM> PostList { get; set; } = new();

        public int PageCount { get; set; }
    }
}

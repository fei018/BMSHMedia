namespace BMSHMedia.Common.Services
{
    public static class WtmFrameworkApiHelper
    {
        public static string GetFileUrl(string fileId, int? width = null, int? height = null)
        {
            return $"/_Framework/GetFile?id={fileId}&stream=true&width={width}&height={height}";
        }
    }
}

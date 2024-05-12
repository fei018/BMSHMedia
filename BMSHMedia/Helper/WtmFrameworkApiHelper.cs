using System;

namespace BMSHMedia.Helper
{
    public static class WtmFrameworkApiHelper
    {
        public static string GetFileUrl(Guid fileId, int? width=null, int? height = null )
        {
            return $"/_Framework/GetFile?id={fileId}&stream=true&width={width}&height={height}";
        }
    }
}

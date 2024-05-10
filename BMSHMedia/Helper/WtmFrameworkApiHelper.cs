using System;

namespace BMSHMedia.Helper
{
    public static class WtmFrameworkApiHelper
    {
        public static string GetFile(Guid fileId)
        {
            return $"/_Framework/GetFile?id={fileId}&stream=true";
        }
    }
}

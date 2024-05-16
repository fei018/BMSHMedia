using BMSHMedia.Common.Media;
using System.Collections.Generic;

namespace BMSHMedia.ViewModel.MediaVMs
{
    public class MediaFolderVM : IMediaFolder
    {
        public string Id { get; set; }

        public string ParentId { get; set; }

        public bool IsTop { get; set; }

        public List<IMediaFile> Files { get; set; } = new();

        public string FolderName { get; set; }

        /// <summary>
        /// 系統FullPath
        /// </summary>
        public string SysFullPath { get; set; }

        /// <summary>
        /// 系統父路徑
        /// </summary>
        public string SysParentPath { get; set; }

        /// <summary>
        /// 取掉設置的根路徑的 相對路徑
        /// </summary>
        public string RelativeEncodePath { get; set; }


        public MediaFolderVM(string fullPath)
        {
            FolderName = fullPath.Substring(fullPath.TrimEnd('\\').LastIndexOf('\\') + 1);

            SysFullPath = fullPath;

            SysParentPath = GetSysParentPath(fullPath);

            RelativeEncodePath = GetEncodeListPagePath(fullPath);
        }


        public static string GetSysParentPath(string fullPath)
        {
            return fullPath.Substring(0, fullPath.TrimEnd('\\').LastIndexOf("\\")).TrimEnd('\\');
        }

        /// <summary>
        /// 取掉設置的根路徑的 然後編碼 相對路徑, 放在List頁面裡
        /// </summary>
        /// <param name="fullPath"></param>
        /// <returns></returns>
        public static string GetEncodeListPagePath(string sysFullPath)
        {
            return MediaVMHelper.EncodePath(MediaVMHelper.CutMediaRootPath(sysFullPath));
        }
    }
}

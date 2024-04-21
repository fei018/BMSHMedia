using System;
using System.ComponentModel.DataAnnotations;
using System.IO;

namespace BMSHMedia.ViewModel.MediaVMs
{
    public class MediaFolderVM : MediaBaseVM
    {
        [Display(Name = "文件夾名")]
        public string FolderName { get; set; }

        /// <summary>
        /// 系統FullPath
        /// </summary>
        public string FullPath { get; set; }

        /// <summary>
        /// 系統父路徑
        /// </summary>
        public string ParentPath { get; set; }

        /// <summary>
        /// 取掉設置的根路徑的 相對路徑, 已編碼, 放在List頁面裡
        /// </summary>
        public string RelativeRequestPath { get; set; }


        public MediaFolderVM(string fullPath)
        {
            FolderName = fullPath.Substring(fullPath.TrimEnd('\\').LastIndexOf('\\') + 1);

            FullPath = fullPath;

            ParentPath = GetParentPath(fullPath);

            RelativeRequestPath = GetEncodeListPagePath(fullPath);
        }


        public static string GetParentPath(string fullPath)
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
            return EncodePath(CutMediaRootPath(sysFullPath));
        }
    }
}

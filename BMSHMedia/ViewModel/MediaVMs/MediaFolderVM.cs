using System;
using System.ComponentModel.DataAnnotations;
using System.IO;

namespace BMSHMedia.ViewModel.MediaVMs
{
    public class MediaFolderVM
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
        public string RelativePath_Encode { get; set; }


        public MediaFolderVM(string fullPath)
        {
            FolderName = fullPath.Substring(fullPath.TrimEnd('\\').LastIndexOf('\\') + 1);

            FullPath = fullPath;

            ParentPath = GetParentPath(fullPath);

            RelativePath_Encode = GetEncodeRelativePath(fullPath);
        }


        public static string GetParentPath(string fullPath)
        {
            return fullPath.Substring(0, fullPath.TrimEnd('\\').LastIndexOf("\\")).TrimEnd('\\');
        }

        /// <summary>
        /// 取掉設置的根路徑的 相對路徑, 已編碼, 放在List頁面裡
        /// </summary>
        /// <param name="fullPath"></param>
        /// <returns></returns>
        public static string GetEncodeRelativePath(string fullPath)
        {
            return Uri.EscapeDataString(fullPath.Substring(SiteConfigInfo.MediaRootPath.Length).TrimStart('\\'));
        }

        /// <summary>
        /// 由相對目錄獲得系統全路徑, relativePath 是已 encode
        /// </summary>
        /// <param name="relativePath"></param>
        /// <returns></returns>
        public static string UncodeAndGetSysFullPath(string relativePath)
        {
            return Path.Combine(SiteConfigInfo.MediaRootPath, Uri.UnescapeDataString(relativePath));
        }

        public static bool IsMediaRootPath(string path)
        {
            if (SiteConfigInfo.IsMediaRootPath(path))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}

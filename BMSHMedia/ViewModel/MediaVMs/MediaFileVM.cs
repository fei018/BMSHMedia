using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;
using System.IO;

namespace BMSHMedia.ViewModel.MediaVMs
{
    public class MediaFileVM
    {
        [Display(Name = "文件名")]
        //[Required(ErrorMessage = "Validate.{0}required")]
        public string FileName { get; set; }

        [Display(Name = "文件擴展名")]
        //[Required(ErrorMessage = "Validate.{0}required")]
        public string FileExtention { get; set; }

        /// <summary>
        /// 相對父路徑, 不包含根路徑
        /// </summary>
        [Display(Name = "相對父路徑")]
        //[Required(ErrorMessage = "Validate.{0}required")]
        public string FileRelativeParentPath { get; set; }

        [Display(Name = "媒體文件類別")]
        //[Required(ErrorMessage = "Validate.{0}required")]
        public MediaFileTypeEnum FileType { get; set; }

        public string MineType { get; set; }

        public string Url { get; set; }

        /// <summary>
        /// 獲取 相對父路徑
        /// </summary>
        /// <param name="fileFullName"></param>
        /// <returns></returns>
        public static string GetFileRelativeParentPath(string fileFullName)
        {
            var path = fileFullName.Replace(SiteConfigInfo.MediaRootPath, "", StringComparison.OrdinalIgnoreCase);

            var filename = Path.GetFileName(fileFullName);

            path = path.Replace(filename, "", StringComparison.OrdinalIgnoreCase);

            return path;
        }
    }
}

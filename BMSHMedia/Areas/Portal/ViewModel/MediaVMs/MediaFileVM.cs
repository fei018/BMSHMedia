using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace BMSHMedia.Portal.ViewModel.MediaVMs
{
    public class MediaFileVM : MediaBaseVM
    {
        [Display(Name = "文件名")]
        //[Required(ErrorMessage = "Validate.{0}required")]
        public string FileName { get; set; }

        [Display(Name = "文件Full名")]
        //[Required(ErrorMessage = "Validate.{0}required")]
        public string FileFullName { get; set; }

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

        public MediaFileVM() { }


        public MediaFileVM(string fullName, MediaFileTypeEnum fileType, string mineType = null)
        {
            FileFullName = fullName;
            FileName = Path.GetFileName(fullName);
            FileRelativeParentPath = GetFileRelativeParentPath(fullName);
            FileType = fileType;
            FileExtention = Path.GetExtension(fullName);
            MineType = mineType;
            Url = GetUrl(fullName);
        }


        public string ToJsonString()
        {
            return JsonSerializer.Serialize(this);
        }

        public static string GetUrl(string fullName)
        {
            // 去掉 MediaRootPath
            var path = CutMediaRootPath(fullName);

            return $"{SiteConfigInfo.CustomStaticWebPath}/" + EncodeFilePathUrl(path);
        }

        /// <summary>
        /// 獲取 相對父路徑, 不包含根路徑
        /// </summary>
        /// <param name="fileFullName"></param>
        /// <returns></returns>
        public static string GetFileRelativeParentPath(string fileFullName)
        {
            // 去掉 MediaRootPath
            var path = CutMediaRootPath(fileFullName);

            var filename = Path.GetFileName(fileFullName);

            path = path.Replace(filename, "", StringComparison.OrdinalIgnoreCase).TrimEnd('\\');

            return path;
        }


    }
}

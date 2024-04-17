using System.ComponentModel.DataAnnotations;

namespace BMSHMedia.ViewModel.MediaVMs
{
    public class MediaFolderVM
    {
        [Display(Name = "文件夾名")]
        public string FolderName { get; set; }

        [Display(Name = "路徑")]
        public string FullPath { get; set; }

        [Display(Name = "父目錄")]
        public string ParentPath { get; set; }

        /// <summary>
        /// 相對路徑
        /// </summary>
        public string RelativePath { get; set; }
    }
}

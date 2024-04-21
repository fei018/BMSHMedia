using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;


namespace BMSHMedia.ViewModel.MediaVMs
{
    public class MediaScanVM
    {
        public List<MediaFileVM> MediaFileList { get; set; } = new();

        public List<MediaFolderVM> MediaFolderList { get; set; } = new();

        public string UpLevelFolderPath { get; set; }

        /// <summary>
        /// 是否顯示 上一級目錄Icon
        /// </summary>
        public bool IsShowUpLevelLinkIcon {  get; set; } = true;

        #region contr
        public MediaScanVM() { }
        #endregion

        #region MyRegion

        #endregion

        #region Scan Folder
        public void ScanFolders(string postRelativePath)
        {
            string sysFullPath;

            if (!string.IsNullOrEmpty(postRelativePath))
            {
                sysFullPath = MediaBaseVM.GetSysFullPath(postRelativePath);

                //// 判斷是否 mediarootpath
                if (MediaBaseVM.IsMediaRootPath(sysFullPath))
                {
                    IsShowUpLevelLinkIcon = false;
                    UpLevelFolderPath = MediaBaseVM.EncodePath(SiteConfigInfo.MediaRootPath); //上一級目錄                
                }
                else
                {
                    IsShowUpLevelLinkIcon = true;

                    // 獲取父目錄路徑
                    string path = MediaFolderVM.GetParentPath(sysFullPath);

                    if (!MediaBaseVM.IsMediaRootPath(path))
                    {
                        // cut meadia root path
                        path = MediaBaseVM.CutMediaRootPath(path);
                    }
                    
                    // encode path
                    UpLevelFolderPath = MediaBaseVM.EncodePath(path); //上一級目錄              
                }
            }
            else
            {
                throw new Exception("ScanFolders(string encodePath): encodePath IsNullOrEmpty");
            }

            var dirs = Directory.EnumerateDirectories(sysFullPath).Order().ToList();

            MediaFolderList = new();

            if (dirs.Count == 0)
            {
                return;
            }

            if (dirs.Count > 0)
            {
                foreach (var dir in dirs)
                {
                    var f = new MediaFolderVM(dir);

                    MediaFolderList.Add(f);
                }
            }
        }
        #endregion

        #region Scan File
        public void ScanFiles(string postRelativePath)
        {
            MediaFileList = new();

            string sysfolderPath = MediaBaseVM.GetSysFullPath(postRelativePath);

            if (!Directory.Exists(sysfolderPath)) { throw new Exception(postRelativePath + " 不存在."); }

            var mp4s = Directory.EnumerateFiles(sysfolderPath, "*.mp4", SearchOption.TopDirectoryOnly).Order().ToList();

            if (mp4s.Count > 0)
            {
                foreach (var item in mp4s)
                {
                    var mp4 = new MediaFileVM(item, MediaFileTypeEnum.Video, "video/mp4");

                    MediaFileList.Add(mp4);
                }
            }

            var mp3s = Directory.EnumerateFiles(sysfolderPath, "*.mp3", SearchOption.TopDirectoryOnly).Order().ToList();

            if (mp3s.Count > 0)
            {

                foreach (var item in mp3s)
                {
                    var mp3 = new MediaFileVM(item, MediaFileTypeEnum.Audio, "audio/mpeg");

                    MediaFileList.Add(mp3);
                }
            }
        }
        #endregion

        #region ScanFolderAndFiles
        public void ScanFolderAndFiles(string encodePostPath)
        {
            string path = MediaBaseVM.DecodePath(encodePostPath);

            ScanFolders(path);

            ScanFiles(path);
        }
        #endregion
    }
}

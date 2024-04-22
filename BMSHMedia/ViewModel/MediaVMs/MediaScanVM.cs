using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;


namespace BMSHMedia.ViewModel.MediaVMs
{
    public class MediaScanVM
    {
        public List<MediaFileVM> MediaFileList { get; set; }

        public List<MediaFolderVM> MediaFolderList { get; set; }

        public string UpLevelFolderPath { get; set; }

        /// <summary>
        /// 是否顯示 上一級目錄Icon
        /// </summary>
        public bool IsShowUpLevelLinkIcon { get; set; } = true;

        #region contr
        public MediaScanVM() { }
        #endregion

        #region CheckRootPath
        private void CheckRootPath(string sysFullPath)
        {
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
                string path = MediaFolderVM.GetSysParentPath(sysFullPath);

                if (!MediaBaseVM.IsMediaRootPath(path))
                {
                    // cut meadia root path
                    path = MediaBaseVM.CutMediaRootPath(path);
                }

                // encode path
                UpLevelFolderPath = MediaBaseVM.EncodePath(path); //上一級目錄              
            }
        }
        #endregion

        #region Scan Folder
        public void ScanFolders(string sysFullPath)
        {
            MediaFolderList = new();

            var dirs = Directory.EnumerateDirectories(sysFullPath).Order().ToList();

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
        public void ScanFiles(string sysfolderPath)
        {
            MediaFileList = new();

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
            if (string.IsNullOrEmpty(encodePostPath))
            {
                throw new Exception("ScanFolderAndFiles(string encodePostPath) IsNullOrEmpty.");
            }

            string path = MediaBaseVM.DecodePath(encodePostPath);

            string sysFullPath = MediaBaseVM.GetSysFullPath(path);

            if (!Directory.Exists(sysFullPath)) { throw new Exception(path + " 不存在."); }

            CheckRootPath(sysFullPath);

            ScanFolders(sysFullPath);

            ScanFiles(sysFullPath);
        }
        #endregion
    }
}

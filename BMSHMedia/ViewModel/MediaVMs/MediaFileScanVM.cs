using System;
using System.Buffers.Text;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace BMSHMedia.ViewModel.MediaVMs
{
    public class MediaFileScanVM
    {
        public List<MediaFileVM> MediaFileList { get; set; } = new();

        public List<MediaFolderVM> MediaFolderList { get; set; } = new();

        public string UpLevelPath { get; set; }

        #region contr
        public MediaFileScanVM(string encodePath)
        {
            if (!string.IsNullOrEmpty(encodePath))
            {
                string fullpath = MediaFolderVM.UncodeAndGetSysFullPath(encodePath);

                if (MediaFolderVM.IsMediaRootPath(fullpath))
                {
                    UpLevelPath = null;
                }
                else
                {
                    string path = MediaFolderVM.GetParentPath(fullpath);
                    UpLevelPath = MediaFolderVM.GetEncodeRelativePath(path);
                }
            }
        }
        #endregion


        #region Scan Folder
        public void ScanFolders(string encodePath, bool first=false)
        {
            string folderPath;

            if (first)
            {
                folderPath = SiteConfigInfo.MediaRootPath;
            }
            else
            {
                folderPath = MediaFolderVM.UncodeAndGetSysFullPath(encodePath);

                if (SiteConfigInfo.IsMediaRootPath(folderPath))
                {
                    return;
                }
            }

            var dirs = Directory.EnumerateDirectories(folderPath).Order().ToList();

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
        public void ScanFiles(string path)
        {
            string folderPath = Path.Combine(SiteConfigInfo.MediaRootPath, path);

            var mp4s = Directory.EnumerateFiles(folderPath, "*.mp4", SearchOption.TopDirectoryOnly).Order().ToList();

            MediaFileList = new();

            if (mp4s.Count > 0)
            {
                foreach (var item in mp4s)
                {
                    var mp4 = new MediaFileVM(item, "video/mp4");

                    MediaFileList.Add(mp4);
                }
            }

            var mp3s = Directory.EnumerateFiles(folderPath, "*.mp3", SearchOption.TopDirectoryOnly).Order().ToList();

            if (mp3s.Count > 0)
            {

                foreach (var item in mp3s)
                {
                    var mp3 = new MediaFileVM(item, "audio/mpeg");

                    MediaFileList.Add(mp3);
                }
            }
        }
        #endregion

        #region ScanFolderAndFiles
        public void ScanFolderAndFiles(string encodePath, bool first)
        {
            ScanFolders(encodePath, first);
            string path = Uri.UnescapeDataString(encodePath);
            ScanFiles(path);
        }
        #endregion
    }
}

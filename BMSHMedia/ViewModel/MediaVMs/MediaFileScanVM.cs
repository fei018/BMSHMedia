using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace BMSHMedia.ViewModel.MediaVMs
{
    public class MediaFileScanVM
    {
        public List<MediaFileVM> MediaFileList { get; set; } = new();

        public List<MediaFolderVM> MediaFolderList { get; set; } = new();


        #region Scan Folder
        public void ScanFolders(string path, bool first)
        {
            string folderPath;

            if (first)
            {
                folderPath = path;
            }
            else
            {
                folderPath = Path.Combine(SiteConfigInfo.MediaRootPath, path);

                if (SiteConfigInfo.IsMediaRootPath(folderPath))
                {
                    return;
                }
            }

            var dirs = Directory.EnumerateDirectories(folderPath).Order().ToList();

            if (dirs.Count == 0)
            {
                MediaFolderList.Clear();
                return;
            }

            if (dirs.Count > 0)
            {
                MediaFolderList.Clear();

                foreach (var dir in dirs)
                {
                    var f = new MediaFolderVM()
                    {
                        FolderName = dir.Substring(dir.LastIndexOf('\\') + 1),
                        FullPath = dir,
                    };

                    f.ParentPath = f.FullPath.Substring(0, f.FullPath.LastIndexOf("\\"));

                    f.RelativePath = f.FullPath.Substring(SiteConfigInfo.MediaRootPath.Length).TrimStart('\\');

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

            MediaFileList?.Clear();

            if (mp4s.Count > 0)
            {
                foreach (var item in mp4s)
                {
                    var mp4 = new MediaFileVM()
                    {
                        FileName = Path.GetFileName(item),
                        FileRelativeParentPath = MediaFileVM.GetFileRelativeParentPath(item),
                        FileType = MediaFileTypeEnum.Video,
                        FileExtention = Path.GetExtension(item),
                        MineType = "video/mp4",
                    };

                    mp4.Url = $"{SiteConfigInfo.SiteHostName}{SiteConfigInfo.CustomStaticWebPath}" + Uri.EscapeUriString($"{mp4.FileRelativeParentPath}{mp4.FileName}".Replace('\\', '/'));

                    MediaFileList.Add(mp4);
                }
            }

            var mp3s = Directory.EnumerateFiles(folderPath, "*.mp3", SearchOption.TopDirectoryOnly).Order().ToList();

            if (mp3s.Count > 0)
            {

                foreach (var item in mp3s)
                {
                    var mp3 = new MediaFileVM()
                    {
                        FileName = Path.GetFileName(item),
                        FileRelativeParentPath = MediaFileVM.GetFileRelativeParentPath(item),
                        FileType = MediaFileTypeEnum.Audio,
                        FileExtention = Path.GetExtension(item),
                        MineType = "audio/mpeg",
                    };

                    mp3.Url = $"{SiteConfigInfo.SiteHostName}{SiteConfigInfo.CustomStaticWebPath}" + Uri.EscapeUriString($"{mp3.FileRelativeParentPath}{mp3.FileName}".Replace('\\', '/'));

                    MediaFileList.Add(mp3);
                }
            }
        }
        #endregion
    }
}

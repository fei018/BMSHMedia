using BMSHMedia.ViewModel.MediaVMs;
using Microsoft.AspNetCore.WebUtilities;
using NPOI.OpenXmlFormats.Wordprocessing;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace BMSHMedia.ViewModel.MediaApiVMs
{
    public class MediaApiVM
    {
        public List<MediaContentVM> MediaContentList { get; set; }

        private readonly MediaScanVM _scan;

        public MediaApiVM()
        {
            _scan = new MediaScanVM();
        }

        public void ScanAll()
        {
            MediaContentList = new List<MediaContentVM>();

            var scan = new MediaScanVM();

            scan.ScanFolders(SiteConfigInfo.MediaRootPath);
            scan.ScanFiles(SiteConfigInfo.MediaRootPath);

            var topContentVM = new MediaContentVM
            {
                FolderList = scan.MediaFolderList,
                FileList = scan.MediaFileList,
                IsTop = true,
                Key = SiteConfigInfo.MediaRootPath,
            };

            MediaContentList.Add(topContentVM);
            
            foreach (var topSubDir in topContentVM.FolderList)
            {
                var subDir = Directory.EnumerateDirectories(topSubDir.SysFullPath);

                foreach (var dir in subDir)
                {
                    if (!Directory.Exists(dir)) continue;

                    
                }
            }
        }

        private void DiGuiDir(string currentDir, string parentKey)
        {
            _scan.ScanFolders(currentDir);
            _scan.ScanFiles(currentDir);

            string key = Guid.NewGuid().ToString();

            var vm = new MediaContentVM
            {
                FolderList = _scan.MediaFolderList,
                FileList = _scan.MediaFileList,
                IsTop = false,
                Key = key,
                ParentKey = parentKey,
                SysFolderPath = currentDir
            };

            if (_scan.MediaFolderList.Count <= 0)
            {
                return;
            }
            
            MediaContentList.Add(vm);

            foreach (var f in vm.FolderList)
            {
                DiGuiDir(f.SysFullPath, key);
            }
        }
    }
}

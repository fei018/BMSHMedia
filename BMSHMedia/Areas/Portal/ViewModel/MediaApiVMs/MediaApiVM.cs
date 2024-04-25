using BMSHMedia.Portal.ViewModel.MediaVMs;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;

namespace BMSHMedia.Portal.ViewModel.MediaApiVMs
{
    public class MediaApiVM
    {

        public static List<MediaFolderVM2> MediaContentList { get; set; } = new();

        public bool Success { get; set; }

        private readonly MediaScanVM _scan;

        public MediaApiVM()
        {
            _scan = new MediaScanVM();
        }

        #region ScanAll
        public void ScanAll()
        {
            MediaContentList = new();

            string root = SiteConfigInfo.MediaRootPath;

            if (!Directory.Exists(root))
            {
                Success = false;
                return;
            }

            _scan.ScanFolders(root);
            _scan.ScanFiles(root);

            var subDirs = _scan.MediaFolderList;
            var subFiles = _scan.MediaFileList;

            var folder = new MediaFolderVM2(root)
            {
                Id = Guid.NewGuid().ToString(),
                IsTop = true,
                Files = subFiles
            };

            MediaContentList.Add(folder);

            foreach (var dir in subDirs)
            {
                RecursiveDir(dir.SysFullPath, folder.Id);
            }

            Success = true;
        }
        #endregion

        #region RecursiveDir
        private void RecursiveDir(string currentDir, string parentId)
        {
            if (!Directory.Exists(currentDir))
            {
                return;
            }

            _scan.ScanFolders(currentDir);
            _scan.ScanFiles(currentDir);

            var subDirs = _scan.MediaFolderList;
            var files = _scan.MediaFileList;

            var vm = new MediaFolderVM2(currentDir)
            {
                Id = Guid.NewGuid().ToString(),
                IsTop = false,
                Files = files,
                ParentId = parentId,
            };

            MediaContentList.Add(vm);

            if (subDirs.Count > 0)
            {
                foreach (var dir in subDirs)
                {
                    RecursiveDir(dir.SysFullPath, vm.Id);
                }
            }
        }
        #endregion

        #region GetJsonData
        public async Task<string> GetJsonData()
        {
            string json = string.Empty;
            await Task.Run(() =>
            {
                ScanAll();
                json = JsonSerializer.Serialize(MediaContentList, new JsonSerializerOptions(JsonSerializerDefaults.Web));

            });

            return json;
        }
        #endregion

        #region async ScanAll
        public static async Task ScanAllAsync()
        {
            await Task.Run(() =>
            {
                new MediaApiVM().ScanAll();
            });
        }
        #endregion

    }
}

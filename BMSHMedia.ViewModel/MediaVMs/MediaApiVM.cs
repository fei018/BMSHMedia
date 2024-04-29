using BMSHMedia.Helper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core.Extensions;

namespace BMSHMedia.ViewModel.MediaVMs
{
    public class MediaApiVM
    {

        private List<MediaContentVM> MediaContentList { get; set; } = new();

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

            var folder = new MediaContentVM(root)
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

            var vm = new MediaContentVM(currentDir)
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
        private const string cacheKey = "MediaContentList";

        public static async Task ScanAllAsync()
        {
            await Task.Run(() =>
            {
                var vm = new MediaApiVM();
                vm.ScanAll();
                MediaCacheHelper.Cache.Add(cacheKey, vm.MediaContentList);
            });
        }
        #endregion

        #region GetMediaContentList
        public static List<MediaContentVM> GetMediaContentList()
        {
            return MediaCacheHelper.Cache.Get<List<MediaContentVM>>(cacheKey);
        }
        #endregion
    }
}

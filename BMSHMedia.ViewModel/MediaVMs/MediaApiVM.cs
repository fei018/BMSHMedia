using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.Memory;
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
        private IMemoryCache _cache { get; set; }

        private List<MediaFolderVM> MediaFoldeVMList { get; set; } = new();

        public bool Success { get; set; }

        private readonly MediaScanVM _scan;

        public MediaApiVM(IMemoryCache memoryCache)
        {
            _cache = memoryCache;
            _scan = new MediaScanVM();
        }

        #region ScanAll
        public void ScanAll()
        {
            MediaFoldeVMList = new();

            string root = MediaConfigInfo.MediaRootPath;

            if (!Directory.Exists(root))
            {
                Success = false;
                return;
            }

            _scan.ScanFolders(root);
            _scan.ScanFiles(root);

            var subDirs = _scan.MediaFolderList;
            var subFiles = _scan.MediaFileList;

            var folder = new MediaFolderVM(root)
            {
                Id = Guid.NewGuid().ToString(),
                IsTop = true,
                Files = subFiles
            };

            MediaFoldeVMList.Add(folder);

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

            var vm = new MediaFolderVM(currentDir)
            {
                Id = Guid.NewGuid().ToString(),
                IsTop = false,
                Files = files,
                ParentId = parentId,
            };

            MediaFoldeVMList.Add(vm);

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
                json = JsonSerializer.Serialize(MediaFoldeVMList, new JsonSerializerOptions(JsonSerializerDefaults.Web));

            });

            return json;
        }
        #endregion

        #region async ScanAll
        private const string cacheKey = "MediaFolderList";

        public async Task ScanAllAsync()
        {
            await Task.Run(() =>
            {
                Console.WriteLine($"[{DateTime.Now}] : {nameof(MediaApiVM)} ScanAllAsync Start.");
                this.ScanAll();

                _cache.Set(cacheKey, MediaFoldeVMList);
                Console.WriteLine($"[{DateTime.Now}] : {nameof(MediaApiVM)} ScanAllAsync Completed.");
            });
        }
        #endregion

        #region GetMediaFolderList
        public List<MediaFolderVM> GetMediaCacheList()
        {
            if (_cache.TryGetValue(cacheKey, out List<MediaFolderVM> list))
            {
                return list;
            }
            else
            {
                Task.Run(ScanAllAsync).Wait();

                return _cache.Get<List<MediaFolderVM>>(cacheKey);
            }
        }
        #endregion
    }
}

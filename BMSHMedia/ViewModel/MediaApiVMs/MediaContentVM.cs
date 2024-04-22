using BMSHMedia.ViewModel.MediaVMs;
using System.Collections.Generic;

namespace BMSHMedia.ViewModel.MediaApiVMs
{
    public class MediaContentVM
    {
        public List<MediaFileVM> FileList { get; set; } = new();

        public List<MediaFolderVM> FolderList { get; set; } = new();

        public string SysFolderPath { get; set; }

        public string Key { get; set; }

        public string ParentKey { get; set; }

        //public string ChilderKey { get; set; }

        public bool IsTop { get; set; } = false;
    }
}

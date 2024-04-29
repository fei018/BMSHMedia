using System.Collections.Generic;

namespace BMSHMedia.ViewModel.MediaVMs
{
    public class MediaContentVM(string sysFullPath) : MediaFolderVM(sysFullPath)
    {
        public string Id { get; set; }

        public string ParentId { get; set; }

        public bool IsTop { get; set; }

        public List<MediaFileVM> Files { get; set; } = new();
    }
}

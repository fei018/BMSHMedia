using BMSHMedia.Portal.ViewModel.MediaVMs;
using System.Collections.Generic;

namespace BMSHMedia.Portal.ViewModel.MediaApiVMs
{
    public class MediaContentVM(string sysFullPath) : MediaFolderVM(sysFullPath)
    {
        public string Id { get; set; }

        public string ParentId { get; set; }

        public bool IsTop { get; set; }

        public List<MediaFileVM> Files { get; set; } = new();
    }
}

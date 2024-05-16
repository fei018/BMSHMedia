namespace BMSHMedia.Common.Media
{
    public interface IMediaFolder
    {
        public string Id { get; set; }

        public string ParentId { get; set; }

        public bool IsTop { get; set; }

        public List<IMediaFile> Files { get; set; }
        public string FolderName { get; set; }
    }
}

namespace BMSHMedia.Common.Media
{
    public interface IMediaFile
    {
        public string FileName { get; set; }

        public string FileExtention { get; set; }

        public MediaFileTypeEnum FileType { get; set; }

        public string MineType { get; set; }

        public string Url { get; set; }
    }
}
